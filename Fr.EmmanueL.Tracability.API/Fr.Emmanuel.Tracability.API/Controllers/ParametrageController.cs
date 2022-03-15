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
    public class ParametrageController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly IParametrageRepository DbContext;
        private readonly IParametrageRepository _parametrageRepository;
  

        public ParametrageController(
            ILogger<ParametrageController> logger,
            IParametrageRepository dbContext,
            IParametrageRepository parametrageRepository

            )
        {
            Logger = logger;
            DbContext = dbContext;   
            _parametrageRepository = parametrageRepository;
  

        }


        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        #region GetAll      

        [HttpGet("Parametrage/GetAll")]
        public async Task<IEnumerable<Parametrage>> GetAllParametrage()
        {
            return await _parametrageRepository.GetAllAsyn();
        }

        [HttpGet("Parametrage/GetAllIncluding")]
        public async Task<IEnumerable<Parametrage>> GetParametrageIncluding()
        {
            return await _parametrageRepository.GetParametrageIncluding();
        }
        #endregion GetAll

        #region GET ById 

        // GET Method
        /// <response code="200">retourne un site</response>
        /// <response code="404">si le site n'existe pas</response>
        /// <response code="500">si il y a eu une erreur interne</response>

        [HttpGet("Parametrage/GetById/{IdParametrage?}")]
        public async Task<Parametrage> GetParametrageById(int IdParametrage)
        {
            return await _parametrageRepository.GetAsyn(IdParametrage);
        }


        #endregion GET ById

        #region Put

        // POST
        /// <response code="200">l'opération c'est passé correcement</response>
        /// <response code="400">mauvaise requete</response>
        /// <response code="500">erreur serveur interne</response>

       

        [HttpPut("Parametrage/Create/{fichiers?}/{versionSoft}/{controleurId}")]
        public async Task AddParametrage(string fichiers, string versionSoft, int controleurId)
        {

            Parametrage parametrage = new Parametrage
            {
                Fichier = fichiers,
                Version = versionSoft,
                IdControleur = controleurId
            };
            await _parametrageRepository.Create(parametrage);
        }



        #endregion Put


        #region Post
        

        [HttpPost("Parametrage/Update/{IdParametrage?}/{IdControleur}/{Version?}/{Fichier}")]
        public async Task UpdateParametrage(int IdParametrage, int IdControleur, string version, string fichier)
        {
            List<Parametrage> ReferentielParametrage = _parametrageRepository.GetAll().ToList();
            //si il existe un das avec cet id
            if (ReferentielParametrage.Where(cc => cc.IdParametrage == Int32.Parse(IdParametrage.ToString().Trim())).Any())
            {
                Parametrage parametrage = new Parametrage
                {
                    IdControleur = IdControleur,
                    Version = version.Trim(),
                    Fichier = fichier.Trim(),
                    IdParametrage = Int32.Parse(IdParametrage.ToString().Trim())
                };
                await _parametrageRepository.Update(parametrage.IdParametrage, parametrage);
            }
        }

        #endregion Post

        #region Delete


        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        [HttpDelete("Parametrage/Delete/{idParametrage?}")]
        public async Task DeleteParametrages(string idParametrage)
        {
            await _parametrageRepository.Delete(_parametrageRepository.Get(Int32.Parse(idParametrage.ToString().Trim())));
        }

        #endregion Delete
    }
}