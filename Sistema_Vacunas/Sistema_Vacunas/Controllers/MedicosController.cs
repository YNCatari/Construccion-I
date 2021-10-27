using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Vacunas.Models;

namespace Sistema_Vacunas.Controllers
{
    public class MedicosController : Controller
    {
        // GET: Medicos
        private Rol objRol = new Rol();
        private Horario objHor = new Horario();
        private Medicos objMed = new Medicos();
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objMed.Listar());
            }
            else
            {
                return View(objMed.Buscar(criterio));
            }
        }
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tipo = objRol.Listar();
            ViewBag.Horario = objHor.Listar();
            return View(id == 0 ?
                   new Medicos() :
                   objMed.Obtener(id));

        }
        public ActionResult Registrar(Medicos model)
        {
            if (ModelState.IsValid)
            {
                model.Registrar();
                return Redirect("~/Medicos/Index");
            }
            else
            {
                return View("~/Medicos/Agregar");
            }
        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ?
                objMed.Listar() :
                objMed.Buscar(criterio));
        }
    }
}