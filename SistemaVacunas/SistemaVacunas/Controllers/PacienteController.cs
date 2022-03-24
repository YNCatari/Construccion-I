/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Paciente*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*TODO: Llamando a la clase de  Paciente */
using SistemaVacunas.Models;
namespace SistemaVacunas.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        private Paciente objPaciente = new Paciente();
        //*Todo: Metodo de Buscar y Listar Paciente
        public ActionResult Index(string criterio)
        {
            //* Si es Vacio o Nulo el Metodo Lista Todo los datos de Pacientes*/
            if (criterio == null || criterio == "")
            {
                return View(objPaciente.Listar());
            }
            //* Si No,Busca el Dato que Ingreso el Usuario
            else
            {
                return View(objPaciente.Buscar(criterio));
            }
        }
        //*Todo: Metodo de Agregar  Paciente
        public ActionResult Agregar(int id = 0)
        {
            //* Si el ID del Paciente es 0,Agrega,si no Obtiene el Paciente para Actualizar
            return View(id == 0 ?
                   new Paciente() :
                   objPaciente.Obtener(id));

        }
        //*Todo: Metodo de Registrar Pacientes
        public ActionResult Registrar(Paciente model)
        {
            //*Si es Valido Procede a Registrar en la Base de Datos*/
            if (ModelState.IsValid)
            {
                model.Registrar();
                //*Todo: Mensaje de Alert */
                TempData["AlertMessage"] = "Paciente Creado con éxito ...!";
                /*TODO: Si todo esta correcto indexar en Index  Paciente*/
                return Redirect("~/Paciente/Index");
            }
            else
            {
                /*TODO: En todo caso si no devolver al metodo Agregar */
                return View("~/Paciente/Agregar");
            }
        }
        //*Todo: Metodo de Buscar Pacientes
        public ActionResult Buscar(string criterio)
        {
            //*TODO: Si es Vacio o Nulo el Metodo Lista todos los datos,si no busca por el criterio Puesto*/
            return View(criterio == null || criterio == "" ?
                objPaciente.Listar() :
                objPaciente.Buscar(criterio));
        }
    }
}