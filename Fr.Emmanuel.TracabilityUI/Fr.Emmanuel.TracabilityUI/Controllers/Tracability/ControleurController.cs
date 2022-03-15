using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fr.Emmanuel.TracabilityUI.Models;
using Fr.Emmanuel.TracabilityUI.Tools;
using Fr.Emmanuel.TracabilityUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fr.Emmanuel.TracabilityUI.Controllers
{
    public class ControleurController : Controller
    {

        public async Task<IActionResult> Index()
        {
            using (var client = new TracabilityHTTPClient())
            {
                string uri = ("Controleur/Controleur/GetAllIncluding");
                List<Controleur> ListControleur = await client.GetAsync<List<Controleur>>(uri);
                ListControleur = ListControleur.OrderBy(x => x.LotProd).ToList();
                ControleurViewModel controleur = new ControleurViewModel
                {
                    listControleur = ListControleur,
                };
                return View("../Tracability/Controleur/Index", controleur);
            }
        }
    }
}
