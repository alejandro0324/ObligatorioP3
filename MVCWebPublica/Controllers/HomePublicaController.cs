using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPublica.Helpers;

namespace WebPublica.Controllers
{
    [UserPublicoAuthentication]
    public class HomePublicaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}