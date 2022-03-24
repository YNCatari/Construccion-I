/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Citas*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*TODO: Llamando a la clase de  Citas */
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
        //*Todo: Metodo de Buscar y Listar Citas
        public ActionResult Index(string criterio)
        {
            //* Si es Vacio o Nulo el Metodo Lista Todo los datos de Citas*/
            if (criterio == null || criterio == "")
            {
                return View(objCitas.Listar());
            }
            //* Si No,Busca el Dato que Ingreso el Usuario
            else
            {
                return View(objCitas.Buscar(criterio));
            }
        }
        //*Todo: Metodo de Agregar  Citas
        public ActionResult Agregar(int id = 0)
        {
            //*Viewbag Listando todo los datos de  las tablas tipo dosis,centro,paciente,Medicos*/
            ViewBag.Tipo = objTipo.Listar();
            ViewBag.Centro = objCentro.Listar();
            ViewBag.Paciente = objPaciente.Listar();
            ViewBag.Medico = objMedico.Listar();
            //* Si el ID de Citas es 0,Agrega,si no Obtiene el Cita para Actualizar
            return View(id == 0 ?
                   new Citas() :
                   objCitas.Obtener(id));

        }
        //*Todo: Metodo de Registrar Citas
        public ActionResult Registrar(Citas model)
        {
            //*Si es Valido Procede a Registrar en la Base de Datos*/
            if (ModelState.IsValid)
            {
                model.Registrar();
                //*Todo: Mensaje de Alert */
                TempData["AlertMessage"] = "Cita Creado con éxito ...!";
                /*TODO: Si todo esta correcto indexar en Index  Citas*/
                return Redirect("~/Citas/Index");
            }
            else
            {
                /*TODO: En todo caso si no devolver al metodo Agregar */
                return View("~/Citas/Agregar");
            }
        }
        //*Todo: Metodo de Buscar Citas donde se Filtrara Citas Pendientes o Confirmados
        public ActionResult Buscar(string criterio)
        {
            //*TODO: Si es Vacio o Nulo el Metodo Lista todos los datos,si no busca por el criterio Puesto*/
            return View(criterio == null || criterio == "" ?
                objCitas.Listar() :
                objCitas.Buscar(criterio));
        }



    }
}