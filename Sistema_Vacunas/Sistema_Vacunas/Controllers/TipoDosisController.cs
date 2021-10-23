using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Vacunas.Models;

namespace Sistema_Vacunas.Controllers
{
    public class TipoDosisController : Controller
    {
        // GET: TipoDosis
        private Tipo_Dosis objTipo = new Tipo_Dosis();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objTipo.Listar());
            }
            else
            {
                return View(objTipo.Buscar(criterio));
            }
        }
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ?
                   new Tipo_Dosis() :
                   objTipo.Obtener(id));

        }
        
        public ActionResult Registrar(Tipo_Dosis model)
        {
            if (ModelState.IsValid)
            {
                model.Registrar();
                return Redirect("~/TipoDosis/Index");
            }
            else
            {
                return View("~/TipoDosis/Agregar");
            }
        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ?
                objTipo.Listar() :
                objTipo.Buscar(criterio));
        }
      
       
    }
}