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
        private Rol objRol = new Rol();
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
        }
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tipo = objRol.Listar();
            return View(id == 0 ?
                   new Usuarios() :
                   objUsu.Obtener(id));

        }
        public ActionResult Registrar(Usuarios model)
        {
            if (ModelState.IsValid)
            {
                model.Registrar();
                return Redirect("~/Usuarios/Index");
            }
            else
            {
                return View("~/Usuarios/Agregar");
            }
        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ?
                objUsu.Listar() :
                objUsu.Buscar(criterio));
        }
    }
}