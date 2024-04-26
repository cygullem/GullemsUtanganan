using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GULLEM_NEW_MVC.Models;

namespace GULLEM_NEW_MVC.Controllers;

public class PageController : Controller
{
    public IActionResult Index(){
        return View();
    }
}
