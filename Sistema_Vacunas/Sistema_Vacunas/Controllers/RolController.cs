using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Vacunas.Models;

namespace Sistema_Vacunas.Controllers
{
   
    public class RolController : Controller
    {
        // GET: Rol
        private Rol objRol = new Rol();
        // GET: Rol

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

        public ActionResult Actualizar()
        {
            return View();
        }

        public ActionResult Guardar(Rol model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
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