using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaVacunas.Models;
using System.Web.Mvc;

namespace SistemaVacunas.Controllers
{
    public class CitasController : Controller
    {
        private Tipo_Dosis objTipo = new Tipo_Dosis();
        private Centro objCentro = new Centro();
        private Paciente objPaciente= new Paciente();
        private Medico objMedico = new Medico();
        private Citas objCitas = new Citas();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objCitas.Listar());
            }
            else
            {
                return View(objCitas.Buscar(criterio));
            }
        }
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tipo = objTipo.Listar();
            ViewBag.Centro = objCentro.Listar();
            ViewBag.Paciente = objPaciente.Listar();
            ViewBag.Medico = objMedico.Listar();

            return View(id == 0 ?
                   new Citas() :
                   objCitas.Obtener(id));

        }
        public ActionResult Registrar(Citas model)
        {
            if (ModelState.IsValid)
            {
                model.Registrar();
                TempData["AlertMessage"] = "Cita Creado con éxito ...!";
                return Redirect("~/Citas/Index");
            }
            else
            {
                return View("~/Citas/Agregar");
            }
        }
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ?
                objCitas.Listar() :
                objCitas.Buscar(criterio));
        }



    }
}