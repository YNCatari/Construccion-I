using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVacunas.Models;
namespace SistemaVacunas.Controllers
{
    public class DosisController : Controller
    {
        // GET: Dosis
        private Tipo_Dosis objTipo = new Tipo_Dosis();
        private Dosis objDosis = new Dosis();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
               
                return View(objDosis.Listar());
            }
            else
            {
                return View(objDosis.Buscar(criterio));
            }
        }
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tipo = objTipo.Listar();
            return View(id == 0 ?
                   new Dosis() :
                   objDosis.Obtener(id));

        }
        public ActionResult Registrar(Dosis model)
        {
            if (ModelState.IsValid)
            {
                model.Registrar();
                TempData["AlertMessage"] = "Dosis Created Successfully ..!";
                return Redirect("~/Dosis/Index");
            }
            else
            {
                return View("~/Dosis/Agregar");
            }
        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ?
                objDosis.Listar() :
                objDosis.Buscar(criterio));
        }
        public ActionResult Eliminar(int id)
        {
            objDosis.Id_dosis = id;
            objDosis.Eliminar();
            TempData["AlertMessage"] = "Dosis Delete Successfully ..!";
            return Redirect("~/Dosis/Index");
        }
    }
}