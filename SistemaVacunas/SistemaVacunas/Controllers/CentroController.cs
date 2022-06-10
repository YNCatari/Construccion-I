/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Centro - 10*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*TODO: Llamando a la clase de  Centro */
using SistemaVacunas.Models;
namespace SistemaVacunas.Controllers
{
    public class CentroController : Controller
    {
        // GET: Centro
        private Tipo_Salud objSalud = new Tipo_Salud();
        private Centro objCentro = new Centro();
        //*Todo: Metodo de Buscar y Listar Centros
        public ActionResult Index(string criterio)
        {
            //* Si es Vacio o Nulo el Metodo Lista Todo los datos de Centros de Salud*/
            if (criterio == null || criterio == "")
            {
                return View(objCentro.Listar());
            }
            //* Si No,Busca el Dato que Ingreso el Usuario
            else
            {
                return View(objCentro.Buscar(criterio));
            }
        }
        //*Todo: Metodo de Agregar  Centro
        public ActionResult Agregar(int id = 0)
        {
            //*Viewbag Listando todo los datos de  la tabla Tipo Salud*/
            ViewBag.Tipo = objSalud.Listar();
            //* Si el ID del Centro de Salud  es 0,Agrega,si no Obtiene el Centro Salud para Actualizar
            return View(id == 0 ?
                   new Centro() :
                   objCentro.Obtener(id));

        }
        //*Todo: Metodo de Registrar Centros de Salud
        public ActionResult Registrar(Centro model)
        {
            //*Si es Valido Procede a Registrar en la Base de Datos*/
            if (ModelState.IsValid)
            {
                model.Registrar();
                //*Todo: Mensaje de Alert */
                TempData["AlertMessage"] = "Centro de Salud ha sido registrado exitosamente!";
                /*TODO: Si todo esta correcto indexar en Index  Centro*/
                return Redirect("~/Centro/Index");
            }
            else
            {
                /*TODO: En todo caso si no devolver al metodo Agregar */
                return View("~/Centro/Agregar");
            }
        }
        //*Todo: Metodo de Buscar Centro
        public ActionResult Buscar(string criterio)
        {
            //*TODO: Si es Vacio o Nulo el Metodo Lista todos los datos,si no busca por el criterio Puesto*/
            return View(criterio == null || criterio == "" ?
                objCentro.Listar() :
                objCentro.Buscar(criterio));
        }
    }
}