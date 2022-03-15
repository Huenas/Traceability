using Fr.Emmanuel.Tracability.Domain.Model;
using Fr.Emmanuel.Tracability.Domain.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Fr.Emmanuel.Tracability.Entity.Services.Repository
{
    public class ControleurRepository : GenericRepository<Controleur>, IControleurRepository
    {
        public ControleurRepository(DbContextFactory context) : base(context)
        {
        }

        public Controleur GetControleurByProperties(int serial, string lotProd, int adresseDansArmoire, string detail, int retourCtrleurId)
        {
            throw new NotImplementedException();
        }

        public int GetControleurIncludingAEC(int controleurId)
        {
            var controleurProp = GetAllIncluding(s => s.AssocEqConts).Where (s=> s.IdControleur== controleurId).FirstOrDefault();
            return controleurProp.AssocEqConts.Count();
        }


        public async Task<IEnumerable<Controleur>> GetControleurIncluding()
        {
            var assocEqContIncluding = await GetAllIncluding(x => x.IdTypeControleurNavigation
                                                            
                                                            ).AsNoTracking().ToListAsync();
            return assocEqContIncluding;
        }


        public int GetControleurIncludingParam(int controleurId)
        {

            var controleurProp = GetAllIncluding(s => s.RetourControleurs).Where(s => s.IdControleur == controleurId).FirstOrDefault();
            return controleurProp.RetourControleurs.Count();
        }

        public int GetControleurIncludingRC(int controleurId)
        {
            var controleurProp = GetAllIncluding(s => s.Parametrages).Where(s => s.IdControleur == controleurId).FirstOrDefault();
            return controleurProp.Parametrages.Count();
        }
    }

}