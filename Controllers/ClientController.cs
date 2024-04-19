using System.Linq;
using GULLEM_NEW_MVC.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GULLEM_NEW_MVC.Controllers
{
  public class ClientController : Controller
  {
    private readonly GullemsUtangananContext _context;

    public ClientController(GullemsUtangananContext context)
    {
      _context = context;
    }

    public IActionResult loan()
    {
      return View();
    }

    public IActionResult Index()
    {
      var clients = _context.ClientInfos.ToList();
      ViewData["types"] = _context.UserTypes.ToList();
      return View(clients);
    }


    // ADD CLIENT
    [HttpGet]
    public IActionResult AddClient()
    {
      var userTypes = _context.UserTypes.ToList();
      ViewData["UserTypes"] = userTypes;
      return View(new List<ClientInfo>()); //
    }

    [HttpPost]
    public IActionResult AddClient(ClientInfo client)
    {
      if (ModelState.IsValid)
      {
        _context.ClientInfos.Add(client);
        _context.SaveChanges();
        return RedirectToAction("Index");
      }
      var userTypes = _context.UserTypes.ToList();
      ViewData["UserTypes"] = userTypes;
      return View(new List<ClientInfo>()); //
    }


    // UPDATE CLIENT
    [HttpGet]
    public IActionResult UpdateClient(int id)
    {
      var client = _context.ClientInfos.FirstOrDefault(q => q.Id == id);
      if (client == null)
      {
        return NotFound();
      }

      var userTypes = _context.UserTypes.ToList();
      ViewData["UserTypes"] = userTypes;
      return View(client);
    }

    [HttpPost]
    public IActionResult UpdateClient(ClientInfo client)
    {
      if (ModelState.IsValid)
      {
        _context.ClientInfos.Update(client);
        _context.SaveChanges();
        return RedirectToAction("Index");
      }

      var userTypes = _context.UserTypes.ToList();
      ViewData["UserTypes"] = userTypes;

      return View(client);
    }

    // DELETE CLIENT
    [HttpGet]
    public IActionResult Delete(int id)
    {
      var client = _context.ClientInfos.FirstOrDefault(q => q.Id == id);
      if (client == null)
      {
        return NotFound();
      }

      _context.ClientInfos.Remove(client);
      _context.SaveChanges();

      return RedirectToAction("Index");
    }
  }
}
