

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
    public class EquipementController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly IEquipementRepository DbContext;
        private readonly IEquipementRepository _equipementRepository;

        public EquipementController(
            ILogger<EquipementController> logger,
            IEquipementRepository dbContext,
            IEquipementRepository equipementRepository
   
            )
        {
            Logger = logger;
            DbContext = dbContext;
            _equipementRepository = equipementRepository;


        }
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        #region GetAll
        [HttpGet("Equipement/GetAll")]
        public async Task<IEnumerable<Equipement>> GetAllEquipement()
        {
            return await _equipementRepository.GetAllAsyn();
        }


        #endregion GetAll

        #region GET ById 

        // GET Method
        /// <response code="200">retourne un site</response>
        /// <response code="404">si le site n'existe pas</response>
        /// <response code="500">si il y a eu une erreur interne</response>

        [HttpGet("Equipement/GetById/{IdEquipement?}")]
        public async Task<Equipement> GetCategorieCompteById(int IdEquipement)
        {
            return await _equipementRepository.GetAsyn(IdEquipement);
        }

        [HttpGet("Equipement/GetAllIncluding")]
        public async Task<IEnumerable<Equipement>> GetEquipementIncluding()
        {
            return await _equipementRepository.GetEquipementIncluding();
        }

        #endregion GET ById

        #region Put

        // POST
        /// <response code="200">l'opération c'est passé correcement</response>
        /// <response code="400">mauvaise requete</response>
        /// <response code="500">erreur serveur interne</response>


        [HttpPut("Equipement/Create/{nomEquipement?}/{affaireId}")]
        public async Task AddEquipement(string nomEquipement, int affaireId)
        {

            Equipement equipement = new Equipement
            {
                NomEquipement = nomEquipement,
                IdAffaire = affaireId
            };
            await _equipementRepository.Create(equipement);
        }

        #endregion Put


        #region Post
        [HttpPost("Equipement/Update/{IdEquipement?}/{IdAffaire?}/{nomEquipement}")]
        public async Task UpdateEquipement(int IdEquipement, int IdAffaire, string NomEquipement)
        {
            List<Equipement> ReferentielEquipement = _equipementRepository.GetAll().ToList();
            //si il existe un das avec cet id
            if (ReferentielEquipement.Where(cc => cc.IdEquipement == Int32.Parse(IdEquipement.ToString().Trim())).Any())
            {
                Equipement equipement = new Equipement
                {
                    IdAffaire = IdAffaire,
                    NomEquipement = NomEquipement.Trim(),
                    IdEquipement = Int32.Parse(IdEquipement.ToString().Trim())
                };
                await _equipementRepository.Update(equipement.IdEquipement, equipement);
            }
        }


        #endregion Post

        #region Delete


        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        [HttpDelete("Equipement/Delete/{idEquipement?}")]
        public async Task DeleteEquipements(string idEquipement)
        {
            await _equipementRepository.Delete(_equipementRepository.Get(Int32.Parse(idEquipement.ToString().Trim())));
        }



        #endregion Delete
    }
}