/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Rol - 3*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*TODO: Llamando a la clase de  Rol */
using SistemaVacunas.Models;

namespace SistemaVacunas.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        private Rol objRol = new Rol();
        //*Todo: Metodo de Buscar y Listar Rol
        public ActionResult Index(string criterio)
        {
            //* Si es Vacio o Nulo el Metodo Lista Todo los datos de Rol*/
            if (criterio == null || criterio == "")
            {
                return View(objRol.Listar());
            }
            //* Si No,Busca el Dato que Ingreso el Usuario
            else
            {
                return View(objRol.Buscar(criterio));
            }
        }
        //*Todo: Metodo de Agregar  Rol
        public ActionResult Agregar(int id = 0)
        {
            //* Si el ID del Rol es 0,Agrega,si no Obtiene el Rol para Actualizar
            return View(id == 0 ?
                   new Rol() :
                   objRol.Obtener(id));

        }
        //*Todo: Metodo de Registrar Rol
        public ActionResult Registrar(Rol model)
        {
            //*Si es Valido Procede a Registrar en la Base de Datos*/
            if (ModelState.IsValid)
            {
                model.Registrar();
                //*Todo: Mensaje de Alert */
                TempData["AlertMessage"] = "Rol ha sido registrado exitosamente!";
                /*TODO: Si todo esta correcto indexar en Index  Rol*/
                return Redirect("~/Rol/Index");
            }
            else
            {
                /*TODO: En todo caso si no devolver al metodo Agregar */
                return View("~/Rol/Agregar");
            }
        }
        //*Todo: Metodo de Buscar Rol
        public ActionResult Buscar(string criterio)
        {
            //*TODO: Si es Vacio o Nulo el Metodo Lista todos los datos,si no busca por el criterio Puesto*/
            return View(criterio == null || criterio == "" ?
                objRol.Listar() :
                objRol.Buscar(criterio));
        }

    }
}