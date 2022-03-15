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
    public class TypeControleurController : Controller
    {

        public async Task<IActionResult> Index()
        {
            using (var client = new TracabilityHTTPClient())
            {
                string uri = ("TypeControleur/TypeControleur/GetAll/");
                TypeControleurViewModel typeControleur = new TypeControleurViewModel
                {
                    listTypeControleur = await client.GetAsync<List<TypeControleur>>(uri)
                };
                return View("../Tracability/TypeControleur/Index", typeControleur);
            }
        }
    }
}
