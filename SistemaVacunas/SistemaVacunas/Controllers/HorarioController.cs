/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Horarios - 5*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*TODO: Llamando a la clase de  Horarios */
using SistemaVacunas.Models;
namespace SistemaVacunas.Controllers
{
    [Authorize]
    public class HorarioController : Controller
    {
        // GET: Horario
        private Horario objHora = new Horario();
        //*Todo: Metodo de Buscar y Listar Horarios
        public ActionResult Index(string criterio)
        {
            //* Si es Vacio o Nulo el Metodo Lista Todo los datos de Horarios*/
            if (criterio == null || criterio == "")
            {
                return View(objHora.Listar());
            }
            //* Si No,Busca el Dato que Ingreso el Usuario
            else
            {
                return View(objHora.Buscar(criterio));
            }
        }
        //*Todo: Metodo de Agregar  Horarios
        public ActionResult Agregar(int id = 0)
        {
            //* Si el ID del Horario es 0,Agrega,si no Obtiene el Horario para Actualizar
            return View(id == 0 ?
                   new Horario() :
                   objHora.Obtener(id));

        }
        //*Todo: Metodo de Registrar Horarios
        public ActionResult Registrar(Horario model)
        {
            //*Si es Valido Procede a Registrar en la Base de Datos*/
            if (ModelState.IsValid)
            {
                model.Registrar();
                //*Todo: Mensaje de Alert */
                TempData["AlertMessage"] = "Horario ha sido registrado exitosamente!";
                /*TODO: Si todo esta correcto indexar en Index  Horario*/
                return Redirect("~/Horario/Index");
            }
            else
            {
                /*TODO: En todo caso si no devolver al metodo Agregar */
                return View("~/Horario/Agregar");
            }
        }
        //*Todo: Metodo de Buscar Horarios
        public ActionResult Buscar(string criterio)
        {
            //*TODO: Si es Vacio o Nulo el Metodo Lista todos los datos,si no busca por el criterio Puesto*/
            return View(criterio == null || criterio == "" ?
                objHora.Listar() :
                objHora.Buscar(criterio));
        }
    }
}