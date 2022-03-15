using System.Collections.Generic;
using Fr.Emmanuel.Tracability.Domain.Model;
using System.Threading.Tasks;

namespace Fr.Emmanuel.Tracability.Domain.Services.IRepository
{
    public interface ITypeControleurRepository : IGenericRepository<TypeControleur>

    {
        TypeControleur GetTypeControleurByName(string libelleType);

       
    }
}
