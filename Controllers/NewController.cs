using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GULLEM_NEW_MVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GULLEM_NEW_MVC.Controllers
{
    public class NewController : Controller
    {

        private readonly GullemsUtangananContext _context;

        public NewController(GullemsUtangananContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.UserTypes.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserType b)
        {
            if (ModelState.IsValid)
            {
                _context.UserTypes.Add(b);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(b); 
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var book = _context.UserTypes.Where(q => q.Id == id).FirstOrDefault();
            return View(book);
        }

        [HttpPost]
        public IActionResult Update(UserType b)
        {
            if (ModelState.IsValid)
            {
                _context.UserTypes.Update(b);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(b); // 
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Client = _context.UserTypes.Where(q => q.Id == id).FirstOrDefault();
            
            _context.UserTypes.Remove(Client);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}