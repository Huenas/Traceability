using Fr.Emmanuel.Tracability.Domain.Model;
using Fr.Emmanuel.Tracability.Domain.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
namespace Fr.Emmanuel.Tracability.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracabilityController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly IAffaireRepository DbContext;
        private readonly IAffaireRepository _affaireRepository;
        private readonly IAssocEqContRepository _assocEqContRepository;
        private readonly IControleurRepository _controleurRepository;
        private readonly IEquipementRepository _equipementRepository;
        private readonly IParametrageRepository _parametrageRepository;
        private readonly IRetourControleurRepository _retourControleurRepository;
        private readonly IRetourEquipementRepository _retourEquipementRepository;
        private readonly ITypeControleurRepository _typeControleurRepository;

        public TracabilityController(
            ILogger<TracabilityController> logger,
            IAffaireRepository dbContext,
            IAffaireRepository affaireRepository,
            IAssocEqContRepository assocEqContRepository,
            IControleurRepository controleurRepository,
            IEquipementRepository equipementRepository,
            IParametrageRepository parametrageRepository,
            IRetourControleurRepository retourControleurRepository,
            IRetourEquipementRepository retourEquipementRepository,
            ITypeControleurRepository typeControleurRepository
            )
        {
            Logger = logger;
            DbContext = dbContext;
            _affaireRepository = affaireRepository;
            _assocEqContRepository = assocEqContRepository;
            _controleurRepository = controleurRepository;
            _equipementRepository = equipementRepository;
            _parametrageRepository = parametrageRepository;
            _retourControleurRepository = retourControleurRepository;
            _retourEquipementRepository = retourEquipementRepository;
            _typeControleurRepository = typeControleurRepository;

        }
        

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        #region GetAll
        [HttpGet("Affaire/GetAll")]
        public async Task<IEnumerable<Affaire>> GetAllAffaire()
        {
            return await _affaireRepository.GetAllAsyn();
        }

        [HttpGet("AssocEqCont/GetAll")]
        public async Task<IEnumerable<AssocEqCont>> GetAssocEqConts()
        {
            return await _assocEqContRepository.GetAllAsyn();
        }

        [HttpGet("Controleur/GetAll")]
        public async Task<IEnumerable<Controleur>> GetAllControleur()
        {
            return await _controleurRepository.GetAllAsyn();
        }

        [HttpGet("Equipement/GetAll")]
        public async Task<IEnumerable<Equipement>> GetAllEquipement()
        {
            return await _equipementRepository.GetAllAsyn();
        }

        [HttpGet("Parametrage/GetAll")]
        public async Task<IEnumerable<Parametrage>> GetAllParametrage()
        {
            return await _parametrageRepository.GetAllAsyn();
        }

        [HttpGet("RetourControleur/GetAll")]
        public async Task<IEnumerable<RetourControleur>> GetAllRetourControleur()
        {
            return await _retourControleurRepository.GetAllAsyn();
        }

        [HttpGet("RetourEquipement/GetAll")]
        public async Task<IEnumerable<RetourEquipement>> GetAllRetourEquipement()
        {
            return await _retourEquipementRepository.GetAllAsyn();
        }

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
      
        
        [HttpGet("AssocEqCont/GetById/{IdAssocEqCont}")]
        public async Task<AssocEqCont> GetAssocEQCByIdInclude(int idAssocEqCont)
        {
            return await _assocEqContRepository.GetByIdIncludingAssocEqCont(idAssocEqCont);
        }

 
        
        [HttpGet("Controleur/GetById/{IdControleur?}")]
        public async Task<Controleur> GetProfitLossById(int IdControleur)
        {
            return await _controleurRepository.GetAsyn(IdControleur);
        }

        [HttpGet("Equipement/GetById/{IdEquipement?}")]
        public async Task<Equipement> GetCategorieCompteById(int IdEquipement)
        {
            return await _equipementRepository.GetAsyn(IdEquipement);
        }

        [HttpGet("Parametrage/GetById/{IdParametrage?}")]
        public async Task<Parametrage> GetParametrageById(int IdParametrage)
        {
            return await _parametrageRepository.GetAsyn(IdParametrage);
        }

        [HttpGet("RetourControleur/GetById/{IdRetourControleur?}")]
        public async Task<RetourControleur> GetRetourControleurtById(int IdRetourControleur)
        {
            return await _retourControleurRepository.GetAsyn(IdRetourControleur);
        }

        [HttpGet("RetourEquipement/GetById/{IdRetourEquipement?}")]
        public async Task<RetourEquipement> GetRetourEquipementById(int IdRetourEquipement)
        {
            return await _retourEquipementRepository.GetAsyn(IdRetourEquipement);
        }

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

        [HttpPut("Controleur/Create/{typeControleurId?}/{serial?}/{lotProd}/{adresseDansArmoire}/{IdRetourControleur}")]
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

        [HttpPut("Equipement/Create/{nomEquipement?}/{affaireId}")]
        public async Task AddEquipement(string nomEquipement,int affaireId)
        {

            Equipement equipement = new Equipement
            {
                NomEquipement = nomEquipement,
                IdAffaire = affaireId
            };
            await _equipementRepository.Create(equipement);
        }

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

        [HttpPut("RetourControleur/Create/{controleurId?}/{dateRetour}/{libelleRetour}")]
        public async Task AddRetourControleur(int controleurId, DateTime dateRetour, string libelleRetour)
        {

            RetourControleur retourControleur = new RetourControleur
            {
                IdControleur = controleurId,
                DateRetour = dateRetour,
                LibelleRetour = libelleRetour
            };
            await _retourControleurRepository.Create(retourControleur);
        }


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

        [HttpPut("TypeControleur/Create/{IdTypeControleur?}/{libelleType}")]
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
        
        [HttpPost("Controleur/Update/{IdTypeControleur?}/{serial?}/{lotProd}/{adresseDansArmoire}/{IdRetourControleur}")]
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
                    IdControleur= Int32.Parse(IdControleur.ToString().Trim())
                };
                await _controleurRepository.Update(controleur.IdControleur, controleur);
            }
        }

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

        [HttpDelete("Affaire/Delete/{idAffaire?}")]
        public async Task DeleteAffaires(string idAffaire)
        {
            await _affaireRepository.Delete(_affaireRepository.Get(Int32.Parse(idAffaire.ToString().Trim())));
        }
        
        [HttpDelete("AssocEqCont/Delete/{idAssocEqCont?}")]
        public async Task DeleteAssocEqConts(string idAssocEqCont)
        {
            await _assocEqContRepository.Delete(_assocEqContRepository.Get(Int32.Parse(idAssocEqCont.ToString().Trim())));
        }
        
        [HttpDelete("Controleur/Delete/{idControleur?}")]
        public async Task DeleteControleurs(string idControleur)
        {
            await _controleurRepository.Delete(_controleurRepository.Get(Int32.Parse(idControleur.ToString().Trim())));
        }

        [HttpDelete("Equipement/Delete/{idEquipement?}")]
        public async Task DeleteEquipements(string idEquipement)
        {
            await _equipementRepository.Delete(_equipementRepository.Get(Int32.Parse(idEquipement.ToString().Trim())));
        }

        [HttpDelete("Parametrage/Delete/{idParametrage?}")]
        public async Task DeleteParametrages(string idParametrage)
        {
            await _parametrageRepository.Delete(_parametrageRepository.Get(Int32.Parse(idParametrage.ToString().Trim())));
        }

        [HttpDelete("RetourControleur/Delete/{idretourControleur?}")]
        public async Task DeleteRetourControleurs(string idRetourControleur)
        {
            await _retourControleurRepository.Delete(_retourControleurRepository.Get(Int32.Parse(idRetourControleur.ToString().Trim())));
        }

        [HttpDelete("RetourEquipement/Delete/{idRetourEquipement?}")]
        public async Task DeleteRetourEquipements(string idRetourEquipement)
        {
            await _retourEquipementRepository.Delete(_retourEquipementRepository.Get(Int32.Parse(idRetourEquipement.ToString().Trim())));
        }

        [HttpDelete("TypeControleur/Delete/{idTypeControleur?}")]
        public async Task DeleteTypeControleurs(string idTypeControleur)
        {
            await _typeControleurRepository.Delete(_typeControleurRepository.Get(Int32.Parse(idTypeControleur.ToString().Trim())));
        }




        


        #endregion Delete
    }
}*/