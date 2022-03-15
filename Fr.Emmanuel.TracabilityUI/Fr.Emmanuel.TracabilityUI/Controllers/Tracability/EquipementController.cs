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
    public class EquipementController : Controller
    {

        public async Task<IActionResult> Index()
        {
            using (var client = new TracabilityHTTPClient())
            {
                string uri = ("Equipement/Equipement/GetAllIncluding");
                List<Equipement> ListEquipement = await client.GetAsync<List<Equipement>>(uri);
                ListEquipement = ListEquipement.OrderBy(x => x.NomEquipement).ToList();
                EquipementViewModel equipement = new EquipementViewModel
                {
                    listEquipement = ListEquipement,
                };
                return View("../Tracability/Equipement/Index", equipement);
            }
        }
    }


}