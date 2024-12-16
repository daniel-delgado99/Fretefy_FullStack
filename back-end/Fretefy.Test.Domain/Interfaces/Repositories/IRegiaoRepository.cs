using Fretefy.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fretefy.Test.Domain.Interfaces.Repositories
{
    public interface IRegiaoRepository
    {
        IEnumerable<Regiao> List();
        IEnumerable<object> ListWithCities();
        object ListWithCitiesById(Guid regiaoId);
        Regiao Add(Regiao regiao);
        Regiao Update(Regiao regiao);
        void ToggleAtivo(Guid id);
        void Delete(Guid id);
    }
}
