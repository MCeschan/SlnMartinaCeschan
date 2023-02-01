using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaWebMisRecetas.Data;
using SistemaWebMisRecetas.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaWebMisRecetas.Controllers
{
    public class RecetaController : Controller
    {
        private readonly RecetasDBContext context;
        public RecetaController(RecetasDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //lista de recetas
            var recetas = context.Recetas.ToList();
            //enviar la lista a la vista.
            return View(recetas);
        }

        //---------AGREGAR
        //GET recetas/Create
        [HttpGet]
        public ActionResult Create()
        {
            Receta receta = new Receta();

            return View("Create", receta); 
        }
        //POST receta/Create
        [HttpPost]
        public ActionResult Create(Receta receta)
        {
            if (ModelState.IsValid)
            {
                context.Recetas.Add(receta); //guardas en memoria
                context.SaveChanges();// guardas en la db.
                return RedirectToAction("Index");
            }
            return View(receta);
        }
        //------ELIMINAR
        //GET
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Receta receta = context.Recetas.Find(id);
            if (receta == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", receta);
            }
        }

        //POST
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Receta receta = context.Recetas.Find(id);
            if (receta == null)
            {
                return NotFound();
            }
            else
            {
                context.Recetas.Remove(receta);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        //------OBTENER DETALLES
        [HttpGet]
        public ActionResult Details(int id)
        {
            var receta = context.Recetas.Find(id);
            if (receta == null)
            {
                return NotFound();
            }
            else
            {

                return View("Details", receta);
            }
        }
        //-----EDITAR
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var receta = context.Recetas.Find(id);
            if (receta == null)
            {
                return NotFound();
            }
            else
            {
                return View("Edit", receta);
            }
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Receta receta)
        {
            if (ModelState.IsValid)
            {
                context.Entry(receta).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(receta);
        }
        [HttpGet("apellido/{apellido}")]
        public ActionResult<Receta> GetByApellido(string apellido)
        {

            List<Receta> recetas = (from e in context.Recetas
                                    where e.Apellido == apellido
                                    select e).ToList();
            return View("GetByApellido", recetas);
        }

        [HttpGet("autor/{autor}")]
        public ActionResult<Receta> GetByAutor(string autor)
        {

            List<Receta> autores = (from a in context.Recetas
                                    where a.Autor == autor
                                    select a).ToList();
            return View("GetByAutor", autores);
        }
    }
}
