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
    public class RetourControleurController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly IRetourControleurRepository DbContext;
        private readonly IRetourControleurRepository _retourControleurRepository;

        public RetourControleurController(
            ILogger<RetourControleurController> logger,
            IRetourControleurRepository dbContext,
            IRetourControleurRepository retourControleurRepository

            )
        {
            Logger = logger;
            DbContext = dbContext;
            _retourControleurRepository = retourControleurRepository;

        }


        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        #region GetAll

        [HttpGet("RetourControleur/GetAll")]
        public async Task<IEnumerable<RetourControleur>> GetAllRetourControleur()
        {
            return await _retourControleurRepository.GetAllAsyn();
        }

        [HttpGet("RetourControleur/GetAllIncluding")]
        public async Task<IEnumerable<RetourControleur>> GetRetourControleurIncluding()
        {
            return await _retourControleurRepository.GetRetourControleurIncluding();
        }

        #endregion GetAll

        #region GET ById 

        // GET Method
        /// <response code="200">retourne un site</response>
        /// <response code="404">si le site n'existe pas</response>
        /// <response code="500">si il y a eu une erreur interne</response>
        [HttpGet("RetourControleur/GetById/{IdRetourControleur?}")]
        public async Task<RetourControleur> GetRetourControleurtById(int IdRetourControleur)
        {
            return await _retourControleurRepository.GetAsyn(IdRetourControleur);
        }


        #endregion GET ById

        #region Put

        // POST
        /// <response code="200">l'opération c'est passé correcement</response>
        /// <response code="400">mauvaise requete</response>
        /// <response code="500">erreur serveur interne</response>

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
 
        [HttpPut("RetourControleur/Create/{controleurId?}/{dateRetour}/{libelleRetour}/{typeControleur}")]
        public async Task AddRetourControleur(int controleurId, DateTime dateRetour, string libelleRetour, string typeControleur)
        {

            RetourControleur retourControleur = new RetourControleur
            {
                IdControleur = controleurId,
                DateRetour = dateRetour,
                LibelleRetour = libelleRetour,
                
            };
            await _retourControleurRepository.Create(retourControleur);
        }


        #endregion Put


        #region Post
        [HttpPost("RetourControleur/Update/{IdRetourControleur}/{IdControleur}/{dateRetour}/{libelleRetour}")]
        public async Task UpdateRetourControleur(int IdRetourControleur, int IdControleur, DateTime dateRetour, string libelleRetour)
        {
            List<RetourControleur> ReferentielRetourControleur = _retourControleurRepository.GetAll().ToList();
            //si il existe un das avec cet id
            if (ReferentielRetourControleur.Where(cc => cc.IdRetourControleur == Int32.Parse(IdRetourControleur.ToString().Trim())).Any())
            {
                RetourControleur retourControleur = new RetourControleur
                {
                    IdControleur = IdControleur,
                    DateRetour = dateRetour,
                    LibelleRetour = libelleRetour.Trim(),
                    IdRetourControleur = Int32.Parse(IdRetourControleur.ToString().Trim())
                };
                await _retourControleurRepository.Update(retourControleur.IdRetourControleur, retourControleur);
            }
        }

        #endregion Post

        #region Delete


        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        [HttpDelete("RetourControleur/Delete/{idretourControleur?}")]
        public async Task DeleteRetourControleurs(string idRetourControleur)
        {
            await _retourControleurRepository.Delete(_retourControleurRepository.Get(Int32.Parse(idRetourControleur.ToString().Trim())));
        }

 



        #endregion Delete
    }
}