using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Fr.Emmanuel.TracabilityUI.Models;
using Fr.Emmanuel.TracabilityUI.Tools;
using Fr.Emmanuel.TracabilityUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fr.Emmanuel.TracabilityUI.Controllers
{
    public class RetourEquipementController : Controller
    {
   
        public async Task<IActionResult> Index()
        {
            using (var client = new TracabilityHTTPClient())
            {
                string uri = ("RetourEquipement/RetourEquipement/GetAllIncluding");
                List<RetourEquipement> ListRetourEquipement = await client.GetAsync<List<RetourEquipement>>(uri);
                ListRetourEquipement = ListRetourEquipement.OrderBy(x => x.DateRetour).ToList();
                RetourEquipementViewModel retourEquipement = new RetourEquipementViewModel
                {
                    listRetourEquipement = ListRetourEquipement,
                };
                return View("../Tracability/RetourEquipement/Index", retourEquipement);
            }
        }
    }
}

