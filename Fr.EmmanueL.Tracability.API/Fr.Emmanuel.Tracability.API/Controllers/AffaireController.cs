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
    public class AffaireController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly IAffaireRepository DbContext;
        private readonly IAffaireRepository _affaireRepository;


        public AffaireController(
            ILogger<AffaireController> logger,
            IAffaireRepository dbContext,
            IAffaireRepository affaireRepository
            )
        {
            Logger = logger;
            DbContext = dbContext;
            _affaireRepository = affaireRepository;

        }

     

        #region GetAll
        [HttpGet("Affaire/GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<Affaire>> GetAllAffaire()
        {
            return await _affaireRepository.GetAllAsyn();
        }

        #endregion GetAll

        #region GET ById 

        // GET Method

        /// 
        [HttpGet("Affaire/GetById/{IdAffaire?}")]
        public async Task<Affaire> GetAffaireById(int IdAffaire)
        {
            Affaire affaires = await _affaireRepository.GetAsyn(IdAffaire);
            if (affaires == null)
            {
                throw new ArgumentException($"No Affaires with ID {IdAffaire}.");
            }
            return affaires;
        }

        [HttpGet("Affaire/GetByNumber/{affaireNumber?}")]
        public async Task<Affaire> GetAffaireByNumber(string affaireNumber)
        {
            var nAffaire = _affaireRepository.GetAffaireByNumber(affaireNumber);
            return nAffaire;
        }

        #endregion GET ById

        #region Put


        /// <response code="200">l'opération c'est passé correcement</response>
        /// <response code="400">mauvaise requete</response>
        /// <response code="500">erreur serveur interne</response>

        [HttpPut("Affaire/Create/{numeroAffaire?}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task AddNumeroAffaire(string numeroAffaire)
        {
            Affaire nAffaire = new Affaire
            {
                NumeroAffaire = numeroAffaire,
            };
            await _affaireRepository.Create(nAffaire);
        }

        #endregion Put

        #region Post
        [HttpPost("Affaire/Update/{IdAffaire?}/{numeroAffaire?}")]
        public async Task UpdateAffaire(int IdAffaire, string numeroAffaire)
        {
            List<Affaire> ReferentielAffaire = _affaireRepository.GetAll().ToList();
            //si il existe un das avec cet id
            if (ReferentielAffaire.Where(cc => cc.IdAffaire == Int32.Parse(IdAffaire.ToString().Trim())).Any())
            {
                Affaire affaire = new Affaire
                {
                    NumeroAffaire = numeroAffaire.Trim(),
                    IdAffaire = Int32.Parse(IdAffaire.ToString().Trim())
                };
                await _affaireRepository.Update(affaire.IdAffaire, affaire);
            }
        }

        #endregion Post

        #region Delete


        [HttpDelete("Affaire/Delete/{idAffaire?}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task DeleteAffaires(string idAffaire)
        {

            await _affaireRepository.Delete(_affaireRepository.Get(Int32.Parse(idAffaire.ToString().Trim())));
        }
        #endregion Delete
    }
}