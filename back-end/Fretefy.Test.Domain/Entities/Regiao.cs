using System;
using System.Collections.Generic;

namespace Fretefy.Test.Domain.Entities
{
    public class Regiao : IEntity
    {
        public Regiao()
        {
        }

        public Regiao(string nome, List<Cidade> cidades)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Ativo = false;
            RegiaoCidades = new List<RegiaoCidade>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public ICollection<RegiaoCidade> RegiaoCidades { get; set; }
    }
}
