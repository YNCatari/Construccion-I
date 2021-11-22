using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVacunas.Models;

namespace SistemaVacunas.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        private Rol objRol = new Rol();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objRol.Listar());
            }
            else
            {
                return View(objRol.Buscar(criterio));
            }
        }

        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ?
                   new Rol() :
                   objRol.Obtener(id));

        }

        public ActionResult Registrar(Rol model)
        {
            if (ModelState.IsValid)
            {
                model.Registrar();
                TempData["AlertMessage"] = "Rol Created Successfully ..!";
                return Redirect("~/Rol/Index");
            }
            else
            {

                return View("~/Rol/Agregar");
            }
        }

        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ?
                objRol.Listar() :
                objRol.Buscar(criterio));
        }

    }
}