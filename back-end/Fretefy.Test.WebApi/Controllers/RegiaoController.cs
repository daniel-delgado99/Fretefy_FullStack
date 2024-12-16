using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Fretefy.Test.WebApi.Controllers
{
    [Route("api/regiao")]
    [ApiController]
    public class RegiaoController : ControllerBase
    {
        private readonly IRegiaoService _regiaoService;

        public RegiaoController(IRegiaoService regiaoService)
        {
            _regiaoService = regiaoService;
        }

        [HttpGet]
        public IActionResult List([FromQuery] string nome, [FromQuery] string terms)
        {
            IEnumerable<Regiao> regioes = _regiaoService.List();

            return Ok(regioes);
        }

        [HttpGet("ListWithCities")]
        public IActionResult ListWithCities()
        {
            IEnumerable<object> regioes = _regiaoService.ListWithCities();

            return Ok(regioes);
        }

        [HttpGet("ListWithCitiesById/{id}")]
        public IActionResult ListWithCitiesById(Guid id)
        {
           object regiao = _regiaoService.ListWithCitiesById(id);

            return Ok(regiao);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Regiao regiao)
        {
            var createdRegiao = _regiaoService.Create(regiao);
            return Ok(createdRegiao);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Regiao regiao)
        {
            var updatedRegiao = _regiaoService.Update(regiao);
            if (updatedRegiao == null)
                return NotFound();

            return Ok(updatedRegiao);
        }

        [HttpPut("ToggleAtivo/{id}")]
        public IActionResult ToggleAtivo(Guid id)
        {
            _regiaoService.ToggleAtivo(id);

            return Ok(true);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _regiaoService.Delete(id);
            return NoContent();
        }
    }
}
