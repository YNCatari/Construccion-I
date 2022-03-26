/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Login*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*TODO: Llamando a la libreria de  Security*/
using System.Web.Security;
/*TODO: Llamando a la clase de  usuario */
using SistemaVacunas.Models;

namespace SistemaVacunas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(Usuarios usuarios, string ReturnUrl)
        {
            HomeController obj = new HomeController();
            if (IsValid(usuarios))
            {
                Session["Usuarios"] = usuarios.Id_usuario;

                FormsAuthentication.SetAuthCookie(usuarios.Email, false);
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                /*TODO: Si todo esta correcto indexar en Index  Home que es el principal dashboard*/
                return RedirectToAction("Index", "Home");
            }
            //*Todo: Mensaje de Alert  */
            TempData["mensaje"] = "El correo electrónico o contraseña que ingresaste no está correcto a una cuenta. Encuentra tu cuenta e inicia sesión.";

            return View(usuarios);
        }
        private bool IsValid(Usuarios usuarios)
        {

            return usuarios.Autenticar();
        }
        /*TODO: Metodo de  Cerrar Sesion */
        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            /*TODO: Si todo esta correcto indexar en Index  Login que  es el acceso a sistema principal */
            return RedirectToAction("Index", "Login");
        }
    }
}