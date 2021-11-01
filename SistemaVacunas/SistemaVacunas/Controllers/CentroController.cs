using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVacunas.Models;
namespace SistemaVacunas.Controllers
{
    public class CentroController : Controller
    {
        // GET: Centro
        private Tipo_Salud objSalud = new Tipo_Salud();
        private Centro objCentro = new Centro();
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objCentro.Listar());
            }
            else
            {
                return View(objCentro.Buscar(criterio));
            }
        }
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tipo = objSalud.Listar();
            return View(id == 0 ?
                   new Centro() :
                   objCentro.Obtener(id));

        }
        public ActionResult Registrar(Centro model)
        {
            if (ModelState.IsValid)
            {
                model.Registrar();
                return Redirect("~/Centro/Index");
            }
            else
            {
                return View("~/Centro/Agregar");
            }
        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ?
                objCentro.Listar() :
                objCentro.Buscar(criterio));
        }
    }
}