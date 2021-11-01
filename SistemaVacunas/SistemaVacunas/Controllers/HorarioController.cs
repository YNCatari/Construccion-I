using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVacunas.Models;
namespace SistemaVacunas.Controllers
{
    public class HorarioController : Controller
    {
        // GET: Horario
        private Horario objHora = new Horario();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objHora.Listar());
            }
            else
            {
                return View(objHora.Buscar(criterio));
            }
        }
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ?
                   new Horario() :
                   objHora.Obtener(id));

        }
        public ActionResult Registrar(Horario model)
        {
            if (ModelState.IsValid)
            {
                model.Registrar();
                return Redirect("~/Horario/Index");
            }
            else
            {
                return View("~/Horario/Agregar");
            }
        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ?
                objHora.Listar() :
                objHora.Buscar(criterio));
        }
    }
}