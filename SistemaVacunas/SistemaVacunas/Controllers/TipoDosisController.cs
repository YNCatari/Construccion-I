/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Tipo Dosis - 8*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*TODO: Llamando a la clase de  Tipo Dosis*/
using SistemaVacunas.Models;
namespace SistemaVacunas.Controllers
{
    public class TipoDosisController : Controller
    {
        // GET: TipoDosis
        private Tipo_Dosis objTipo = new Tipo_Dosis();
        //*Todo: Metodo de Buscar y Listar Tipo Dosis
        public ActionResult Index(string criterio)
        {
            //* Si es Vacio o Nulo el Metodo Lista Todo los datos de Tipo Dosis*/
            if (criterio == null || criterio == "")
            {
                return View(objTipo.Listar());
            }
            //* Si No,Busca el Dato que Ingreso el Usuario
            else
            {
                return View(objTipo.Buscar(criterio));
            }
        }
        //*Todo: Metodo de Agregar  Tipo Dosis
        public ActionResult Agregar(int id = 0)
        {
            //* Si el ID del Tipo Dosis es 0,Agrega,si no Obtiene el Tipo Dosis para Actualizar
            return View(id == 0 ?
                   new Tipo_Dosis() :
                   objTipo.Obtener(id));

        }
        //*Todo: Metodo de Registrar Tipo Dosis
        public ActionResult Registrar(Tipo_Dosis model)
        {
            //*Si es Valido Procede a Registrar en la Base de Datos*/
            if (ModelState.IsValid)
            {
                model.Registrar();
                //*Todo: Mensaje de Alert */
                TempData["AlertMessage"] = "Tipo Dosis ha sido registrado exitosamente!";
                /*TODO: Si todo esta correcto indexar en Index  Tipo Dosis*/
                return Redirect("~/TipoDosis/Index");
            }
            else
            {
                /*TODO: En todo caso si no devolver al metodo Agregar */
                return View("~/TipoDosis/Agregar");
            }
        }
        //*Todo: Metodo de Buscar Tipo Dosis
        public ActionResult Buscar(string criterio)
        {
            //*TODO: Si es Vacio o Nulo el Metodo Lista todos los datos,si no busca por el criterio Puesto*/
            return View(criterio == null || criterio == "" ?
                objTipo.Listar() :
                objTipo.Buscar(criterio));
        }
    }
}