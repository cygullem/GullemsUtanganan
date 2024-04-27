using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GULLEM_NEW_MVC.Entities;
using GULLEM_NEW_MVC.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace GULLEM_NEW_MVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly GullemsUtangananContext _context;

        public ClientController(GullemsUtangananContext context)
        {
            _context = context;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            var clientInfos = await (
                from clientInfo in _context.ClientInfos
                join usertype in _context.UserTypes
                on clientInfo.UerType equals usertype.Id
                select new ClientInfoViewModel
                {
                    Id = clientInfo.Id,
                    UerType = clientInfo.UerType,
                    UserTypeName = usertype.Name,
                    FirstName = clientInfo.FirstName,
                    MiddleName = clientInfo.MiddleName,
                    LastName = clientInfo.LastName,
                    Address = clientInfo.Address,
                    ZipCode = clientInfo.ZipCode,
                    Birthday = clientInfo.Birthday,
                    Age = clientInfo.Age,
                    NameOfFather = clientInfo.NameOfFather,
                    NameOfMother = clientInfo.NameOfMother,
                    CivilStatus = clientInfo.CivilStatus,
                    Religion = clientInfo.Religion,
                    Occupation = clientInfo.Occupation,
                }
            ).ToListAsync();

            return View(clientInfos);
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Loan(int? id)
        {
            if (id == null || _context.ClientInfos == null)
            {
                return NotFound();
            }

            var clientInfo = await _context.ClientInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientInfo == null)
            {
                return NotFound();
            }

            return View(clientInfo);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            var userTypes = _context.UserTypes.ToList();
            ViewData["UserTypes"] = userTypes;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddClient(ClientInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var clientInfo = new ClientInfo
                {
                    // Map properties accordingly
                };

                _context.ClientInfos.Add(clientInfo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        // GET: Client/AddLoan/5
        public IActionResult AddLoan(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["ClientId"] = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientInfoViewModel clientInfo)
        {
            if (ModelState.IsValid)
            {
                ClientInfo c = new ClientInfo
                {
                    Id = clientInfo.Id,
                    UerType = clientInfo.UerType,
                    FirstName = clientInfo.FirstName,
                    MiddleName = clientInfo.MiddleName,
                    LastName = clientInfo.LastName,
                    Address = clientInfo.Address,
                    ZipCode = clientInfo.ZipCode,
                    Birthday = clientInfo.Birthday,
                    Age = clientInfo.Age,
                    NameOfFather = clientInfo.NameOfFather,
                    NameOfMother = clientInfo.NameOfMother,
                    CivilStatus = clientInfo.CivilStatus,
                    Religion = clientInfo.Religion,
                    Occupation = clientInfo.Occupation,
                };
                _context.ClientInfos.Add(c);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientInfo);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> UpdateClient(int? id)
        {
            if (id == null || _context.ClientInfos == null)
            {
                return NotFound();
            }

            var userTypes = await _context.UserTypes.ToListAsync();

            ViewData["UserTypes"] = userTypes;

            var clientInfoViewModel = await _context.ClientInfos
                .Where(q => q.Id == id)
                .Select(q => new ClientInfoViewModel
                {
                    Id = q.Id,
                    UerType = q.UerType,
                    FirstName = q.FirstName,
                    MiddleName = q.MiddleName,
                    LastName = q.LastName,
                    Address = q.Address,
                    ZipCode = q.ZipCode,
                    Birthday = q.Birthday,
                    Age = q.Age,
                    NameOfFather = q.NameOfFather,
                    NameOfMother = q.NameOfMother,
                    CivilStatus = q.CivilStatus,
                    Religion = q.Religion,
                    Occupation = q.Occupation,
                })
                .FirstOrDefaultAsync();

            if (clientInfoViewModel == null)
            {
                return NotFound();
            }

            return View(clientInfoViewModel);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateClient(int id, ClientInfoViewModel clientInfo)
        {
            if (id != clientInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var client = await _context.ClientInfos.FirstOrDefaultAsync(x => x.Id == id);
                    client.UerType = clientInfo.UerType;
                    client.FirstName = clientInfo.FirstName;
                    client.MiddleName = clientInfo.MiddleName;
                    client.LastName = clientInfo.LastName;
                    client.Address = clientInfo.Address;
                    client.ZipCode = clientInfo.ZipCode;
                    client.Birthday = clientInfo.Birthday;
                    client.Age = clientInfo.Age;
                    client.NameOfFather = clientInfo.NameOfFather;
                    client.NameOfMother = clientInfo.NameOfMother;
                    client.CivilStatus = clientInfo.CivilStatus;
                    client.Religion = clientInfo.Religion;
                    client.Occupation = clientInfo.Occupation;

                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientInfoExists(clientInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clientInfo);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientInfos == null)
            {
                return NotFound();
            }

            var clientInfo = await _context.ClientInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientInfo == null)
            {
                return NotFound();
            }

            return View(clientInfo);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientInfos == null)
            {
                return Problem("Entity set 'GullemsUtangananContext.ClientInfos'  is null.");
            }
            var clientInfo = await _context.ClientInfos.FindAsync(id);
            if (clientInfo != null)
            {
                _context.ClientInfos.Remove(clientInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientInfoExists(int id)
        {
            return (_context.ClientInfos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
