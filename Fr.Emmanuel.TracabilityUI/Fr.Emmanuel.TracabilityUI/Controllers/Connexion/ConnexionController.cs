using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fr.Emmanuel.TracabilityUI.Web.Controllers.Connexion
{
    public class ConnexionController : Controller
    {
        public IActionResult Index()
        {
            return View("../Connexion/Index");
        }
    }
}
