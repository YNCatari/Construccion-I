/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Dosis*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*TODO: Llamando a la clase de  Dosis */
using SistemaVacunas.Models;
namespace SistemaVacunas.Controllers
{
    public class DosisController : Controller
    {
        // GET: Dosis
        private Tipo_Dosis objTipo = new Tipo_Dosis();
        private Dosis objDosis = new Dosis();
        //*Todo: Metodo de Buscar y Listar Dosis
        public ActionResult Index(string criterio)
        {
            //* Si es Vacio o Nulo el Metodo Lista Todo los datos de Dosis*/
            if (criterio == null || criterio == "")
            {
                return View(objDosis.Listar());
            }
            //* Si No,Busca el Dato que Ingreso el Usuario
            else
            {
                return View(objDosis.Buscar(criterio));
            }
        }
        //*Todo: Metodo de Agregar  Dosis
        public ActionResult Agregar(int id = 0)
        {
            //*Viewbag Listando todo los datos de  la tabla Tipo Dosis*/
            ViewBag.Tipo = objTipo.Listar();
            //* Si el ID del Dosis es 0,Agrega,si no Obtiene el Dosis para Actualizar
            return View(id == 0 ?
                   new Dosis() :
                   objDosis.Obtener(id));

        }
        //*Todo: Metodo de Registrar Dosis
        public ActionResult Registrar(Dosis model)
        {
            //*Si es Valido Procede a Registrar en la Base de Datos*/
            if (ModelState.IsValid)
            {
                model.Registrar();
                //*Todo: Mensaje de Alert */
                TempData["AlertMessage"] = "Dosis Creado con éxito ...!";
                /*TODO: Si todo esta correcto indexar en Index  Dosis*/
                return Redirect("~/Dosis/Index");
            }
            else
            {
                /*TODO: En todo caso si no devolver al metodo Agregar */
                return View("~/Dosis/Agregar");
            }
        }
        //*Todo: Metodo de Buscar Dosis
        public ActionResult Buscar(string criterio)
        {
            //*TODO: Si es Vacio o Nulo el Metodo Lista todos los datos,si no busca por el criterio Puesto*/
            return View(criterio == null || criterio == "" ?
                objDosis.Listar() :
                objDosis.Buscar(criterio));
        }
        //*Todo: Metodo de Eliminar Dosis 
        public ActionResult Eliminar(int id)
        {
            objDosis.Id_dosis = id;
            objDosis.Eliminar();
            //*Todo: Mensaje de Alert */
            TempData["AlertMessage"] = "Dosis Eliminado con éxito ...!";
            /*TODO: Si todo esta correcto indexar en Index  Dosis*/
            return Redirect("~/Dosis/Index");
        }
    }
}