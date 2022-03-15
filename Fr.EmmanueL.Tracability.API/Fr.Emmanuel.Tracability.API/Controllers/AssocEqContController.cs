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
    public class AssocEqContController : ControllerBase
    {




        protected readonly ILogger Logger;
        protected readonly IAssocEqContRepository DbContext;
        private readonly IAssocEqContRepository _assocEqContRepository;
  

        public AssocEqContController(
            ILogger<AssocEqContController> logger,
            IAssocEqContRepository dbContext, 
            IAssocEqContRepository assocEqContRepository
 
            )
        {
            Logger = logger;
            DbContext = dbContext;
            _assocEqContRepository = assocEqContRepository;
    

        }


        #region GetAll

        [HttpGet("AssocEqCont/GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<AssocEqCont>> GetAssocEqConts()
        {
            return await _assocEqContRepository.GetAllAsyn();
        }
        [HttpGet("AssocEqCont/GetAllIncluding")]
        public async Task<IEnumerable<AssocEqCont>> GetAssocEqContIncluding()
        {
            return await _assocEqContRepository.GetAssocEqContIncluding();
        }
        #endregion GetAll

        #region GET ById 

        // GET Method
        /// <response code="200">retourne un site</response>
        /// <response code="404">si le site n'existe pas</response>
        /// <response code="500">si il y a eu une erreur interne</response>


        [HttpGet("AssocEqCont/GetById/{IdAssocEqCont}")]
        public async Task<AssocEqCont> GetAssocEQCByIdInclude(int idAssocEqCont)
        {
            return await _assocEqContRepository.GetByIdIncludingAssocEqCont(idAssocEqCont);
        }


        #endregion GET ById

        #region Put

        // POST
        /// <response code="200">l'opération c'est passé correcement</response>
        /// <response code="400">mauvaise requete</response>
        /// <response code="500">erreur serveur interne</response>


        [HttpPut("AssocEqCont/Create/{equipementId}/{controleurId}/{dateAssoc?}")]
        public async Task AddAssocEqCont(int equipementId, int controleurId, DateTime dateAssoc)
        {
            AssocEqCont assocEqCont = new AssocEqCont
            {
                IdEquipement = equipementId,
                IdControleur = controleurId,
                DateAssoc = dateAssoc
            };
            await _assocEqContRepository.Create(assocEqCont);
        }

        #endregion Put


        #region Post

        [HttpPost("AssocEqCont/Update/{IdAssocEqCont?}/{dateAssoc?}")]
        public async Task UpdateAssocEqCont(int IdAssocEqCont, DateTime dateAssoc)
        {
            List<AssocEqCont> ReferentielAssocEqCont = _assocEqContRepository.GetAll().ToList();
            //si il existe un das avec cet id
            if (ReferentielAssocEqCont.Where(cc => cc.IdAssocEqCont == Int32.Parse(IdAssocEqCont.ToString().Trim())).Any())
            {
                AssocEqCont assocEqCont = new AssocEqCont
                {

                    DateAssoc = dateAssoc,
                    IdAssocEqCont = Int32.Parse(IdAssocEqCont.ToString().Trim())
                };
                await _assocEqContRepository.Update(assocEqCont.IdAssocEqCont, assocEqCont);
            }
        }


        #endregion Post

        #region Delete


        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        [HttpDelete("AssocEqCont/Delete/{idAssocEqCont?}")]
        public async Task DeleteAssocEqConts(string idAssocEqCont)
        {
            await _assocEqContRepository.Delete(_assocEqContRepository.Get(Int32.Parse(idAssocEqCont.ToString().Trim())));
        }


        #endregion Delete
    }
}