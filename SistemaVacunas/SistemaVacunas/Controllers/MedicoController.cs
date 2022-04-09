/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Medico*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*TODO: Llamando a la clase de  Modelos */
using SistemaVacunas.Models;
namespace SistemaVacunas.Controllers
{
    public class MedicoController : Controller
    {
        // GET: Medico
        private Rol objRol = new Rol();
        private Horario objHor = new Horario();
        private Medico objMed = new Medico();
        //*Todo: Metodo de Buscar y Listar Medicos
        public ActionResult Index(string criterio)
        {
            //* Si es Vacio o Nulo el Metodo Lista Todo los datos de Medicos*/
            if (criterio == null || criterio == "")
            {
                return View(objMed.Listar());
            }
            //* Si No,Busca el Dato que Ingreso el Usuario
            else
            {
                return View(objMed.Buscar(criterio));
            }
        }
        //*Todo: Metodo de Agregar  Medicos
        public ActionResult Agregar(int id = 0)
        {
            //*Viewbag Listando todo los datos de  las tablas Rol,Horarios*/
            ViewBag.Tipo = objRol.Listar();
            ViewBag.Horario = objHor.Listar();
            //* Si el ID del Medico es 0,Agrega,si no Obtiene el Medico para Actualizar
            return View(id == 0 ?
                   new Medico() :
                   objMed.Obtener(id));

        }
        //*Todo: Metodo de Registrar Medicos
        public ActionResult Registrar(Medico model)
        {
            //*Si es Valido Procede a Registrar en la Base de Datos*/
            if (ModelState.IsValid)
            {
                model.Registrar();
                //*Todo: Mensaje de Alert */
                TempData["AlertMessage"] = "Medico ha sido registrado exitosamente!";
                /*TODO: Si todo esta correcto indexar en Index  Medico*/
                return Redirect("~/Medico/Index");
            }

            else
            {
                /*TODO: En todo caso si no devolver al metodo Agregar */
                return View("~/Medico/Agregar");
            }
        }
        //*Todo: Metodo de Buscar Medicos
        public ActionResult Buscar(string criterio)
        {
            //*TODO: Si es Vacio o Nulo el Metodo Lista todos los datos,si no busca por el criterio Puesto*/
            return View(criterio == null || criterio == "" ?
                objMed.Listar() :
                objMed.Buscar(criterio));
        }
        //*Todo: Metodo de Reportes
        public ActionResult ReportPie()
        {
            return View(objMed.ObtenerMedico());
        }
    }
}