using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fr.Emmanuel.TracabilityUI.Models;
using Fr.Emmanuel.TracabilityUI.Tools;
using Fr.Emmanuel.TracabilityUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fr.Emmanuel.TracabilityUI.Controllers
{
    public class RetourControleurController : Controller
    {


        public async Task<IActionResult> Index()
        {
            using (var client = new TracabilityHTTPClient())
            {
                string uri = ("RetourControleur/RetourControleur/GetAllIncluding");
                List<RetourControleur> ListRetourControleur = await client.GetAsync<List<RetourControleur>>(uri);
                ListRetourControleur = ListRetourControleur.OrderBy(x => x.DateRetour).ToList();
                RetourControleurViewModel retourControleur = new RetourControleurViewModel
                {
                    listRetourControleur = ListRetourControleur,
                };
                return View("../Tracability/RetourControleur/Index", retourControleur);
            }
        }



        /*
        public async Task<IActionResult> AddCompte()
        {
            using (var client = new TracabilityHTTPClient())
            {
                RetourControleurViewModel retourControleur = new RetourControleurViewModel
                {
                    listControleur = await client.GetAsync<List<Controleur>>("Controleur/Controleur/GetAll/"),
            
                };
                return PartialView("../Tracability/RetourControleur/_addRetourControleurModal", retourControleur);
            }
        }


        #region Operation BDD
        public async Task Create(DateTime dateRetour, string libelleRetour, int IdControleur, int IdTypeControleur)
        {
            using (var client = new TracabilityHTTPClient())
            {               
                string uri = ("RetourControleur/RetourControleur/Create/" + dateRetour + "/" + libelleRetour.Trim() + "/" + IdControleur + "/" + IdTypeControleur);
                client.DefaultRequestHeaders.Accept.Clear();
                var stringContent = new StringContent(dateRetour.ToString());
                var reponse = await client.PostAsync(uri, stringContent);
                var result = await reponse.Content.ReadAsStringAsync();
            }
        }
        #endregion*/
    }
}
        