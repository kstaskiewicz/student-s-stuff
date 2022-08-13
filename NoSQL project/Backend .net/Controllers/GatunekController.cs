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
    public class GatunekController : ControllerBase
    {

        private readonly IGraphClient _client;

        public GatunekController(IGraphClient client)
        {
            _client = client;
        }

    
        [HttpPost]
        public async Task<IActionResult> Dodaj([FromBody] Gatunek_filmu g)
        {
            await _client.Cypher.Create("(g:Gatunek $g)")
                                .WithParam("g", g)
                                .ExecuteWithoutResultsAsync();

            return Ok();
        }


        [HttpPost("Dodaj film do gatunku")]
        public async Task<IActionResult> Polacz(string Tytul, string Gatunek)
        {
            await _client.Cypher.Match("(f:Film), (g:Gatunek)")
                                .Where((Film f, Gatunek_filmu g) => f.Tytul == Tytul && g.Gatunek == Gatunek)
                                .Create("(f)-[rg :Gatunek]->(g)")
                                .ExecuteWithoutResultsAsync();

            return Ok();
        }


    }
}