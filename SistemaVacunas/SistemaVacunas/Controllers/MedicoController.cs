using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVacunas.Models;
namespace SistemaVacunas.Controllers
{
    public class MedicoController : Controller
    {
        // GET: Medico
        private Rol objRol = new Rol();
        private Horario objHor = new Horario();
        private Medico objMed = new Medico();
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
                   new Medico() :
                   objMed.Obtener(id));

        }
        public ActionResult Registrar(Medico model)
        {
            if (ModelState.IsValid)
            {
                model.Registrar();
                TempData["AlertMessage"] = "Medico Creado con éxito ...!";
                return Redirect("~/Medico/Index");
            }
            else
            {
                return View("~/Medico/Agregar");
            }
        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ?
                objMed.Listar() :
                objMed.Buscar(criterio));
        }
        public ActionResult ReportPie()
        {
            return View(objMed.ObtenerMedico());
        }
    }
}