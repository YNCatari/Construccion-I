using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Vacunas.Models;

namespace Sistema_Vacunas.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        //private Rol objRol = new Rol();
        private Usuarios objUsu = new Usuarios();
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objUsu.Listar());
            }
            else
            {
                return View(objUsu.Buscar(criterio));
            }
            return View();
        }
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ?
                   new Usuarios() :
                   objUsu.Obtener(id));

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
    }
}