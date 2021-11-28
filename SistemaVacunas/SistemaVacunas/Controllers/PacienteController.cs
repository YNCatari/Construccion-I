using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVacunas.Models;
namespace SistemaVacunas.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        private Paciente objPaciente = new Paciente();
      
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objPaciente.Listar());
            }
            else
            {
                return View(objPaciente.Buscar(criterio));
            }
        }
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ?
                   new Paciente() :
                   objPaciente.Obtener(id));

        }
        public ActionResult Registrar(Paciente model)
        {
            if (ModelState.IsValid)
            {
                model.Registrar();
                TempData["AlertMessage"] = "Paciente Creado con éxito ...!";
                return Redirect("~/Paciente/Index");
            }
            else
            {
                return View("~/Paciente/Agregar");
            }
        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ?
                objPaciente.Listar() :
                objPaciente.Buscar(criterio));
        }
    }
}