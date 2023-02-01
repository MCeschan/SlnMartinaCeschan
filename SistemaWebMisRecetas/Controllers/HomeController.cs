using Microsoft.AspNetCore.Mvc;
using System;

namespace SistemaWebMisRecetas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Nombre = "¡Bienvenidos al mejor sitio web de recetas!";
            return View();
        }
    }
}
