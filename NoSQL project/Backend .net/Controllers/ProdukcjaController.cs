using Bazy_NoSQL.Models;
using Microsoft.AspNetCore.Mvc;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazy_NoSQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdukcjaController : ControllerBase
    {

        private readonly IGraphClient _client;

        public ProdukcjaController(IGraphClient client)
        {
            _client = client;
        }


        [HttpPost]
        public async Task<IActionResult> Dodaj([FromBody] Produkcja p)
        {
            await _client.Cypher.Create("(p:Produkcja $p)")
                                .WithParam("p", p)
                                .ExecuteWithoutResultsAsync();

            return Ok();
        }


        [HttpPost("Dodaj kraj produkcji do filmu")]
        public async Task<IActionResult> Polacz(string Tytul, string Produkcja)
        {
            await _client.Cypher.Match("(f:Film), (p:Produkcja)")
                                .Where((Film f, Produkcja p) => f.Tytul == Tytul && p.Kraj_produkcji == Produkcja)
                                .Create("(f)-[rp :Produkcja]->(p)")
                                .ExecuteWithoutResultsAsync();

            return Ok();
        }


    }
}