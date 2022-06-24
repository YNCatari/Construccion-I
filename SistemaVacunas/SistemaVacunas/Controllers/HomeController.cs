/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*Dashboard Principal*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVacunas.Models;
namespace SistemaVacunas.Controllers
{
    [Authorize]
    [HandleError]
    public class HomeController : Controller
    {
        // GET: Home
        public string email;
        public ActionResult Index()
        {
            return View();
        }
    }
}