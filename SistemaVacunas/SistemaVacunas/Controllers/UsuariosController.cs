/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Usuarios*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*TODO: Llamando a la clase de  usuario */
using SistemaVacunas.Models;
namespace SistemaVacunas.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        private Rol objRol = new Rol();
        private Usuarios objUsu = new Usuarios();
        //*Todo: Metodo de Buscar y Listar Usuarios
        public ActionResult Index(string criterio)
        {
            //* Si es Vacio o Nulo el Metodo Lista Todo los datos de Usuarios*/
            if (criterio == null || criterio == "")
            {
                return View(objUsu.Listar());
            }
            //* Si No,Busca el Dato que Ingreso el Usuario
            else
            {
                return View(objUsu.Buscar(criterio));
            }
        }
        //*Todo: Metodo de Agregar  Usuarios
        public ActionResult Agregar(int id = 0)
        {
            //*Viewbag Listando todo los datos de  la tabla roles*/
            ViewBag.Tipo = objRol.Listar();
            //* Si el ID del Usuario es 0,Agrega,si no Obtiene el Usuario para Actualizar
            return View(id == 0 ?
                   new Usuarios() :
                   objUsu.Obtener(id));

        }
        //*Todo: Metodo de Registrar Usuarios
        public ActionResult Registrar(Usuarios model)
        {
            //*Si es Valido Procede a Registrar en la Base de Datos*/
            if (ModelState.IsValid)
            {
                model.Registrar();
                //*Todo: Mensaje de Alert */
                TempData["AlertMessage"] = "Usuario Creado con éxito ...!";
                /*TODO: Si todo esta correcto indexar en Index  Usuario*/
                return Redirect("~/Usuarios/Index");
            }

            else
            {
                /*TODO: En todo caso si no devolver al metodo Agregar */
                return View("~/Usuarios/Agregar");
            }
        }
        //*Todo: Metodo de Buscar Usuarios
        public ActionResult Buscar(string criterio)
        {
            //*TODO: Si es Vacio o Nulo el Metodo Lista todos los datos,si no busca por el criterio Puesto*/
            return View(criterio == null || criterio == "" ?
                objUsu.Listar() :
                objUsu.Buscar(criterio));
        }
    }
}