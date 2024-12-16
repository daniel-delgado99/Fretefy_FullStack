using Fretefy.Test.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Fretefy.Test.Domain.Interfaces
{
    public interface IRegiaoService
    {
        IEnumerable<Regiao> List();
        public IEnumerable<object> ListWithCities();
        public object ListWithCitiesById(Guid regiaoId);
        Regiao Create(Regiao regiao);
        Regiao Update(Regiao regiao);
        void ToggleAtivo(Guid id);
        void Delete(Guid id);
    }
}
