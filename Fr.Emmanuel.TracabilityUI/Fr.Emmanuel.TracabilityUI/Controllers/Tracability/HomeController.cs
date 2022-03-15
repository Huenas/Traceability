using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Fr.Emmanuel.TracabilityUI.Models;
using Fr.Emmanuel.TracabilityUI.Tools;
using Fr.Emmanuel.TracabilityUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fr.Emmanuel.TracabilityUI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using var client2 = new TracabilityHTTPClient();


            string uriAffaire = ("Affaire/Affaire/GetAll");
            List<Affaire> affaire = await client2.GetAsync<List<Affaire>>(uriAffaire);
            var orderedAffaire = affaire.OrderBy(af => af.IdAffaire).ToList();

            string uriAssoc = ("AssocEqCont/AssocEqCont/GetAllIncluding");
            List<AssocEqCont> assocEqCont = await client2.GetAsync<List<AssocEqCont>>(uriAssoc);
            var orderedAssoc = assocEqCont.OrderBy(assc => assc.IdAssocEqCont).ToList();

            string uriControleur = ("Controleur/Controleur/GetAllIncluding");
            List<Controleur> controleur = await client2.GetAsync<List<Controleur>>(uriControleur);
            var orderedControleur = controleur.OrderBy(ctrl => ctrl.IdControleur).ToList();

            string uriEquipement = ("Equipement/Equipement/GetAllIncluding");
            List<Equipement> equipement = await client2.GetAsync<List<Equipement>>(uriEquipement);
            var orderedEquipement = equipement.OrderBy(eq => eq.IdEquipement).ToList();

            string uriParametrage = ("Parametrage/Parametrage/GetAllIncluding");
            List<Parametrage> parametrage = await client2.GetAsync<List<Parametrage>>(uriParametrage);
            var orderedParametrage = parametrage.OrderBy(param => param.IdParametrage).ToList();

            string uriRetourControleur = ("RetourControleur/RetourControleur/GetAllIncluding");
            List<RetourControleur> retourControleur = await client2.GetAsync<List<RetourControleur>>(uriRetourControleur);
            var orderedRetourControleur = retourControleur.OrderBy(retourctrl => retourctrl.IdRetourControleur).ToList();

            string uriRetourEquipement = ("RetourEquipement/RetourEquipement/GetAllIncluding");
            List<RetourEquipement> retourEquipement = await client2.GetAsync<List<RetourEquipement>>(uriRetourEquipement);
            var orderedRetourEquipement = retourEquipement.OrderBy(retourEquipement => retourEquipement.IdRetourEquipement).ToList();

            string uriTypeControleur = ("TypeControleur/TypeControleur/GetAll");
            List<TypeControleur> typeControleur = await client2.GetAsync<List<TypeControleur>>(uriTypeControleur);
            var orderedTypeControleur = typeControleur.OrderBy(typectrl => typectrl.IdTypeControleur).ToList();

            HomeViewModel homeVM = new HomeViewModel
            {
                Affaire = orderedAffaire,
                AssocEqCont = orderedAssoc,
                Controleur = orderedControleur,
                Equipement = orderedEquipement,
                Parametrage = orderedParametrage,
                RetourControleur = orderedRetourControleur,
                RetourEquipement = orderedRetourEquipement,
                TypeControleur = orderedTypeControleur
            };
            return View("../Home/Index", homeVM);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
