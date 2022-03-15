using Fr.Emmanuel.Tracability.Domain.Model;
using Fr.Emmanuel.Tracability.Domain.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.Emmanuel.Tracability.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControleurController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly IControleurRepository DbContext;
        private readonly IControleurRepository _controleurRepository;
 

        public ControleurController(
            ILogger<ControleurController> logger,
            IControleurRepository dbContext,
            IControleurRepository controleurRepository

            )
        {
            Logger = logger;
            DbContext = dbContext;
            _controleurRepository = controleurRepository;
  

        }


        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        #region GetAll

        [HttpGet("Controleur/GetAll")]
        public async Task<IEnumerable<Controleur>> GetAllControleur()
        {
            return await _controleurRepository.GetAllAsyn();
        }

        [HttpGet("Controleur/GetAllIncluding")]
        public async Task<IEnumerable<Controleur>> GetEquipementIncluding()
        {
            return await _controleurRepository.GetControleurIncluding();
        }
        #endregion GetAll

        #region GET ById 

        // GET Method
        /// <response code="200">retourne un site</response>
        /// <response code="404">si le site n'existe pas</response>
        /// <response code="500">si il y a eu une erreur interne</response>

        [HttpGet("Controleur/GetById/{IdControleur?}")]
        public async Task<Controleur> GetProfitLossById(int IdControleur)
        {
            return await _controleurRepository.GetAsyn(IdControleur);
        }

        #endregion GET ById

        #region Put

        // POST
        /// <response code="200">l'opération c'est passé correcement</response>
        /// <response code="400">mauvaise requete</response>
        /// <response code="500">erreur serveur interne</response>


        [HttpPut("Controleur/Create/{typeControleurId?}/{serial?}/{lotProd}/{adresseDansArmoire}")]
        public async Task AddControleur(int typeControleurId, string serial, string lotProd, string adresseDansArmoire)
        {

            Controleur controleur = new Controleur
            {

                Serial = serial,
                LotProd = lotProd,
                AdresseDansArmoire = adresseDansArmoire,
                IdTypeControleur = typeControleurId
                
            };
            await _controleurRepository.Create(controleur);
        }

 

        #endregion Put


        #region Post

        [HttpPost("Controleur/Update/{IdTypeControleur?}/{serial?}/{lotProd}/{adresseDansArmoire}")]
        public async Task UpdateControleur(int IdControleur, int typeControleurId, string serial, string lotProd, string adresseDansArmoire)
        {
            List<Controleur> ReferentielControleur = _controleurRepository.GetAll().ToList();
            //si il existe un das avec cet id
            if (ReferentielControleur.Where(cc => cc.IdControleur == Int32.Parse(IdControleur.ToString().Trim())).Any())
            {
                Controleur controleur = new Controleur
                {
                    IdTypeControleur = typeControleurId,

                    Serial = serial.Trim(),
                    LotProd = lotProd.Trim(),
                    AdresseDansArmoire = adresseDansArmoire.Trim(),
                    IdControleur = Int32.Parse(IdControleur.ToString().Trim())
                };
                await _controleurRepository.Update(controleur.IdControleur, controleur);
            }
        }

        #endregion Post

        #region Delete
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        [HttpDelete("Controleur/Delete/{idControleur?}")]
        public async Task DeleteControleurs(string idControleur)
        {
            await _controleurRepository.Delete(_controleurRepository.Get(Int32.Parse(idControleur.ToString().Trim())));
        }


        #endregion Delete
    }
}