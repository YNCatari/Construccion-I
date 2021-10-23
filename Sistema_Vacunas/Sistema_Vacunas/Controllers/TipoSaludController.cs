using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Vacunas.Models;
namespace Sistema_Vacunas.Controllers
{
    public class TipoSaludController : Controller
    {
        // GET: TipoSalud
        private Tipo_Salud objTipo = new Tipo_Salud();

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
                   new Tipo_Salud() :
                   objTipo.Obtener(id));

        }
       
        public ActionResult Registrar(Tipo_Salud model)
        {
            if (ModelState.IsValid)
            {
                model.Registrar();
                return Redirect("~/TipoSalud/Index");
            }
            else
            {
                return View("~/TipoSalud/Agregar");
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