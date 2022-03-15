using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fr.Emmanuel.TracabilityUI.Models;
using Fr.Emmanuel.TracabilityUI.Tools;
using Fr.Emmanuel.TracabilityUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fr.Emmanuel.TracabilityUI.Controllers
{
    public class AffaireController : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            using (var client = new TracabilityHTTPClient())
            {
                string uri = ("Affaire/Affaire/GetAll/");
                AffaireViewModel numAffaire = new AffaireViewModel
                {
                    listAffaire = await client.GetAsync<List<Affaire>>(uri)
                };
                return View("../Tracability/Affaire/Index", numAffaire);
            }
        }

        /*
        public IActionResult AddAffaire()
        {
            return PartialView("../Tracability/Affaire/_addAffaireModal");
        }

        public async Task<IActionResult> EditAffaire(int id)
        {
            using (var client = new TracabilityHTTPClient())
            {
                string uri = ("Tracability/Affaire/GetById/" + id.ToString().Trim());
                AffaireViewModel catAffaire = new AffaireViewModel
                {
                    currentAffaire = await client.GetAsync<Affaire>(uri)
                };
                return PartialView("../Tracability/Affaire/_editAffaireModal", catAffaire);
            }
        }

        public async Task<IActionResult> DelAffaire(int id)
        {
            using (var client = new TracabilityHTTPClient())
            {
                string uri = ("Tracability/Affaire/GetById/" + id.ToString().Trim());
                AffaireViewModel catAffaire = new AffaireViewModel
                {
                    currentAffaire = await client.GetAsync<Affaire>(uri)
                };
                return PartialView("../Tracability/Affaire/_delAffaireModal", catAffaire);
            }
        }
        #endregion  

        #region Operation BDD
        public async Task Create(string numeroAffaire)
        {
            using (var client = new TracabilityHTTPClient())
            {
                string uri = ("Tracability/Affaire/Create/" + numeroAffaire.Trim());
                //client.DefaultRequestHeaders.Accept.Clear();
                var reponse = await client.PostAsync(uri, new StringContent(numeroAffaire.ToString()));
                //var result = await reponse.Content.ReadAsStringAsync();
            }
        }

        public async Task Update(string idAffaire, string numeroAffaire)
        {
            using (var client = new TracabilityHTTPClient())
            {
                string uri = ("Tracability/Affaire/Update/" + idAffaire.Trim() + "/" + numeroAffaire.Trim());
                var reponse = await client.PostAsync(uri, new StringContent(numeroAffaire.ToString()));
            }
        }

        public async Task Delete(int id)
        {
            using (var client = new TracabilityHTTPClient())
            {
                string uri = ("Tracability/Affaire/Delete/" + id.ToString().Trim());
                var reponse = await client.DeleteAsync(uri);
            }
        }
        #endregion
        */
    }
}
