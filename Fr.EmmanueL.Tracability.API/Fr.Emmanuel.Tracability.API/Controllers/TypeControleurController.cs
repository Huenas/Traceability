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
    public class TypeControleurController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly ITypeControleurRepository DbContext;
        private readonly ITypeControleurRepository _typeControleurRepository;

        public TypeControleurController(
            ILogger<TypeControleurController> logger,
            ITypeControleurRepository dbContext,
            ITypeControleurRepository typeControleurRepository
            )
        {
            Logger = logger;
            DbContext = dbContext;

            _typeControleurRepository = typeControleurRepository;

        }


        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        #region GetAll


        [HttpGet("TypeControleur/GetAll")]
        public async Task<IEnumerable<TypeControleur>> GetAllTypeControleur()
        {
            return await _typeControleurRepository.GetAllAsyn();
        }

      
        #endregion GetAll

        #region GET ById 

        // GET Method
        /// <response code="200">retourne un site</response>
        /// <response code="404">si le site n'existe pas</response>
        /// <response code="500">si il y a eu une erreur interne</response>

        [HttpGet("TypeControleur/GetById/{IdTypeControleur?}")]
        public async Task<TypeControleur> GetTypeControleurByName(int IdTypeControleur)
        {
            return await _typeControleurRepository.GetAsyn(IdTypeControleur);
        }

        #endregion GET ById

        #region Put

        // POST
        /// <response code="200">l'opération c'est passé correcement</response>
        /// <response code="400">mauvaise requete</response>
        /// <response code="500">erreur serveur interne</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        [HttpPut("TypeControleur/Create/{libelleType}")]
        public async Task AddTypeControleur(string libelleType)
        {

            TypeControleur typeControleur = new TypeControleur
            {
                LibelleType = libelleType,
            };
            await _typeControleurRepository.Create(typeControleur);
        }

        #endregion Put


        #region Post
        [HttpPost("TypeControleur/Update/{IdTypeControleur?}/{libelleType}")]
        public async Task UpdateTypeControleur(int IdTypeControleur, string libelleType)
        {
            List<TypeControleur> ReferentielTypeControleur = _typeControleurRepository.GetAll().ToList();
            //si il existe un das avec cet id
            if (ReferentielTypeControleur.Where(cc => cc.IdTypeControleur == Int32.Parse(IdTypeControleur.ToString().Trim())).Any())
            {
                TypeControleur typeControleur = new TypeControleur
                {
                    LibelleType = libelleType.Trim(),
                    IdTypeControleur = Int32.Parse(IdTypeControleur.ToString().Trim())
                };
                await _typeControleurRepository.Update(typeControleur.IdTypeControleur, typeControleur);
            }
        }

        #endregion Post

        #region Delete


        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        [HttpDelete("TypeControleur/Delete/{idTypeControleur?}")]
        public async Task DeleteTypeControleurs(string idTypeControleur)
        {
            await _typeControleurRepository.Delete(_typeControleurRepository.Get(Int32.Parse(idTypeControleur.ToString().Trim())));
        }







        #endregion Delete
    }
}