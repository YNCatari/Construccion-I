/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Tipo Salud*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*TODO: Llamando a la clase de  Tipo Salud */
using SistemaVacunas.Models;
namespace SistemaVacunas.Controllers
{
    public class TipoSaludController : Controller
    {
        // GET: TipoSalud
        private Tipo_Salud objTipo = new Tipo_Salud();
        //*Todo: Metodo de Buscar y Listar Tipo Salud
        public ActionResult Index(string criterio)
        {
            //* Si es Vacio o Nulo el Metodo Lista Todo los datos de Tipo Salud*/
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
        //*Todo: Metodo de Agregar  Tipo Salud
        public ActionResult Agregar(int id = 0)
        {
            //* Si el ID del Tipo Salud es 0,Agrega,si no Obtiene el Tipo Salud para Actualizar
            return View(id == 0 ?
                   new Tipo_Salud() :
                   objTipo.Obtener(id));

        }
        //*Todo: Metodo de Registrar Tipos Salud
        public ActionResult Registrar(Tipo_Salud model)
        {
            //*Si es Valido Procede a Registrar en la Base de Datos*/
            if (ModelState.IsValid)
            {
                model.Registrar();
                //*Todo: Mensaje de Alert */
                TempData["AlertMessage"] = "Tipo de Salud Creado con éxito ...!";
                /*TODO: Si todo esta correcto indexar en Index  Tipo Salud*/
                return Redirect("~/TipoSalud/Index");
            }
            else
            {
                /*TODO: En todo caso si no devolver al metodo Agregar */
                return View("~/TipoSalud/Agregar");
            }
        }
        //*Todo: Metodo de Buscar Tipo Salud
        public ActionResult Buscar(string criterio)
        {
            //*TODO: Si es Vacio o Nulo el Metodo Lista todos los datos,si no busca por el criterio Puesto*/
            return View(criterio == null || criterio == "" ?
                objTipo.Listar() :
                objTipo.Buscar(criterio));
        }

    }
}