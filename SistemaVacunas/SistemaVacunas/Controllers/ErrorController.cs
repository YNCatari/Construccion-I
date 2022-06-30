using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaVacunas.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error configuracion de pagina de Error 404
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}