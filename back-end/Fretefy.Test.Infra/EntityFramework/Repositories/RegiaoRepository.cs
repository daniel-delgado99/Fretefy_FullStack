using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Interfaces;
using Fretefy.Test.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fretefy.Test.Infra.EntityFramework.Repositories
{
    public class RegiaoRepository : IRegiaoRepository
    {
        private DbSet<Regiao> _dbSet;
        private DbContext _dbContext;

        public RegiaoRepository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<Regiao>();
            _dbContext = dbContext;
        }

        public IEnumerable<Regiao> List()
        {
            return _dbSet.Include(r => r.RegiaoCidades)
                .ThenInclude(rc => rc.Cidade)
                .ToList();
        }

        public IEnumerable<object> ListWithCities()
        {
            return _dbSet
                .Include(r => r.RegiaoCidades)
                .ThenInclude(rc => rc.Cidade)
                .Select(r => new
                {
                    id = r.Id,
                    nome = r.Nome,
                    ativo = r.Ativo,
                    cidades = r.RegiaoCidades.Select(rc => new
                    {
                        id = rc.Cidade.Id,
                        nome = rc.Cidade.Nome,
                        uf = rc.Cidade.UF
                    }).ToList()
                })
                .ToList();
        }

        public object ListWithCitiesById(Guid regiaoId)
        {
            return _dbSet
                .Where(r => r.Id == regiaoId) 
                .Include(r => r.RegiaoCidades)
                .ThenInclude(rc => rc.Cidade)
                .Select(r => new
                {
                    id = r.Id,
                    nome = r.Nome,
                    ativo = r.Ativo,
                    cidades = r.RegiaoCidades.Select(rc => new
                    {
                        id = rc.Cidade.Id,
                        nome = rc.Cidade.Nome,
                        uf = rc.Cidade.UF
                    }).ToList()
                })
                .FirstOrDefault();
        }
        public Regiao GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(r => r.Id == id);
        }

        public Regiao Add(Regiao regiao)
        {
            regiao.Id = Guid.NewGuid();
            regiao.Ativo = true;
            _dbSet.Add(regiao);

            if (regiao.RegiaoCidades != null && regiao.RegiaoCidades.Any())
            {
                foreach (var regiaoCidade in regiao.RegiaoCidades)
                {
                    var existingRegiaoCidade = _dbContext.Set<RegiaoCidade>().Local.FirstOrDefault(rc => rc.RegiaoId == regiaoCidade.RegiaoId && rc.CidadeId == regiaoCidade.CidadeId);

                    if (existingRegiaoCidade == null)
                    {
                        var novaRegiaoCidade = new RegiaoCidade
                        {
                            RegiaoId = regiao.Id,
                            CidadeId = regiaoCidade.CidadeId
                        };

                        _dbContext.Set<RegiaoCidade>().Add(novaRegiaoCidade);
                    }
                }

            }

            _dbContext.SaveChanges();

            return regiao;
        }

        public Regiao Update(Regiao regiao)
        {
            var idOriginal = regiao.Id;
            _dbSet.Remove(regiao);
            regiao.Id = idOriginal;
            regiao.Ativo = true;
            Add(regiao);
            _dbContext.SaveChanges();
            return regiao;
        }

        public void ToggleAtivo(Guid id)
        {
            var regiao = _dbSet.Find(id);
            regiao.Ativo = !regiao.Ativo;
            regiao.Id = id;
            _dbSet.Update(regiao);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var regiao = _dbSet.Find(id);
            if (regiao != null)
            {
                _dbSet.Remove(regiao);
                _dbContext.SaveChanges();
            }
        }
    }
}
