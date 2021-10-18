using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Vacunas.Models;

namespace Sistema_Vacunas.Controllers
{
    public class PacienteController : Controller
    {
        private Pacientes objPaciente = new Pacientes();
        // GET: Pacientes
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
                   new Pacientes() :
                   objPaciente.Obtener(id));

        }
        public ActionResult Guardar(Pacientes model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
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
        public ActionResult Eliminar(int id)
        {
            objPaciente.id_pacientes = id;
            objPaciente.Eliminar();
            return Redirect("~/Paciente/Index");
        }
        
    }
}