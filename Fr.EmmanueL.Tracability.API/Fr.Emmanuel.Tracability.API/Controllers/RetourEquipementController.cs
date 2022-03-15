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
    public class RetourEquipementController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly IRetourEquipementRepository DbContext;
        private readonly IRetourEquipementRepository _retourEquipementRepository;


        public RetourEquipementController(
            ILogger<RetourEquipementController> logger,
            IRetourEquipementRepository dbContext,
            IRetourEquipementRepository retourEquipementRepository
  
            )
        {
            Logger = logger;
            DbContext = dbContext;
            _retourEquipementRepository = retourEquipementRepository;
     

        }


        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        #region GetAll


        [HttpGet("RetourEquipement/GetAll")]
        public async Task<IEnumerable<RetourEquipement>> GetAllRetourEquipement()
        {
            return await _retourEquipementRepository.GetAllAsyn();
        }

        [HttpGet("RetourEquipement/GetAllIncluding")]
        public async Task<IEnumerable<RetourEquipement>> GetRetourEquipementIncluding()
        {
            return await _retourEquipementRepository.GetRetourEquipementIncluding();
        }
        #endregion GetAll

        #region GET ById 

        // GET Method
        /// <response code="200">retourne un site</response>
        /// <response code="404">si le site n'existe pas</response>
        /// <response code="500">si il y a eu une erreur interne</response>

        [HttpGet("RetourEquipement/GetById/{IdRetourEquipement?}")]
        public async Task<RetourEquipement> GetRetourEquipementById(int IdRetourEquipement)
        {
            return await _retourEquipementRepository.GetAsyn(IdRetourEquipement);
        }


        #endregion GET ById

        #region Put

        // POST
        /// <response code="200">l'opération c'est passé correcement</response>
        /// <response code="400">mauvaise requete</response>
        /// <response code="500">erreur serveur interne</response>

        [HttpPut("RetourEquipement/Create/{equipementId?}/{dateRetour}/{libelleRetour}")]
        public async Task AddRetourEquipement(int equipementId, DateTime dateRetour, string libelleRetour)
        {

            RetourEquipement retourEquipement = new RetourEquipement
            {
                IdEquipement = equipementId,
                DateRetour = dateRetour,
                LibelleRetour = libelleRetour
            };
            await _retourEquipementRepository.Create(retourEquipement);
        }


        #endregion Put


        #region Post
        [HttpPost("RetourEquipement/Update/{IdRetourEquipement}/{IdEquipement}/{dateRetour}/{libelleRetour}")]
        public async Task UpdateRetourEqiupement(int IdRetourEquipement, int IdEquipement, DateTime dateRetour, string libelleRetour)
        {
            List<RetourEquipement> ReferentielRetourEquipement = _retourEquipementRepository.GetAll().ToList();
            //si il existe un das avec cet id
            if (ReferentielRetourEquipement.Where(cc => cc.IdRetourEquipement == Int32.Parse(IdRetourEquipement.ToString().Trim())).Any())
            {
                RetourEquipement retourEquipement = new RetourEquipement
                {
                    IdEquipement = IdEquipement,
                    DateRetour = dateRetour,
                    LibelleRetour = libelleRetour.Trim(),
                    IdRetourEquipement = Int32.Parse(IdRetourEquipement.ToString().Trim())
                };
                await _retourEquipementRepository.Update(retourEquipement.IdRetourEquipement, retourEquipement);
            }
        }

        #endregion Post

        #region Delete

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        [HttpDelete("RetourEquipement/Delete/{idRetourEquipement?}")]
        public async Task DeleteRetourEquipements(string idRetourEquipement)
        {
            await _retourEquipementRepository.Delete(_retourEquipementRepository.Get(Int32.Parse(idRetourEquipement.ToString().Trim())));
        }

        #endregion Delete
    }
}