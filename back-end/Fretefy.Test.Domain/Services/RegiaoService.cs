using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Interfaces;
using Fretefy.Test.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fretefy.Test.Services
{
    public class RegiaoService : IRegiaoService
    {
        private readonly IRegiaoRepository _regiaoRepository;

        public RegiaoService(IRegiaoRepository regiaoRepository)
        {
            _regiaoRepository = regiaoRepository;
        }

        public IEnumerable<Regiao> List()
        {
            return _regiaoRepository.List();
        }

        public IEnumerable<object> ListWithCities()
        {
            return _regiaoRepository.ListWithCities();
        }

        public object ListWithCitiesById(Guid regiaoId)
        {
            return _regiaoRepository.ListWithCitiesById(regiaoId);
        }

        public Regiao Create(Regiao regiao)
        {
            return _regiaoRepository.Add(regiao);
        }

        public Regiao Update(Regiao regiao)
        {
            return _regiaoRepository.Update(regiao);
        }

        public void ToggleAtivo(Guid id)
        {
            _regiaoRepository.ToggleAtivo(id);
        }

        public void Delete(Guid id)
        {
            _regiaoRepository.Delete(id);
        }
    }
}
