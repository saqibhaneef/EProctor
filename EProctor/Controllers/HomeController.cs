using EProctor.Models;
using EProctor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EProctor.Controllers
{
    public class HomeController : Controller
    {
        
        
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Details()
        {
            return View();
        }
    }
}
