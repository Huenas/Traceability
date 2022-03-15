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
    public class AssocEqContController : Controller
    {

        public async Task<IActionResult> Index()
        {
            using (var client = new TracabilityHTTPClient())
            {
                string uri = ("AssocEqCont/AssocEqCont/GetAll");
                List<AssocEqCont> ListAssocEqCont = await client.GetAsync<List<AssocEqCont>>(uri);

                ListAssocEqCont = ListAssocEqCont.OrderBy(x => x.DateAssoc).ToList();
                AssocEqContViewModel assocEqCont = new AssocEqContViewModel
                {
                    listAssocEqCont = ListAssocEqCont,
                };
                return View("../Tracability/AssocEqCont/Index", assocEqCont);
            }
        }


        
    }
}