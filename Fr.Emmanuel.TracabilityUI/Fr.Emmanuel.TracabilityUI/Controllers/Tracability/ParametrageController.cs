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
    public class ParametrageController : Controller
    {

        public async Task<IActionResult> Index()
        {
            using (var client = new TracabilityHTTPClient())
            {


                string uri = ("Parametrage/Parametrage/GetAll/");
                ParametrageViewModel parametrage = new ParametrageViewModel
                {
                    listParametrage = await client.GetAsync<List<Parametrage>>(uri)
                };
                return View("../Tracability/Parametrage/Index", parametrage);
            }
        }
    }
}