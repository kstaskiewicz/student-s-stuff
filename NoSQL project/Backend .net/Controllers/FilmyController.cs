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
    public class FilmyController : ControllerBase
    {

        private readonly IGraphClient _client;

        public FilmyController(IGraphClient client)
        {
            _client = client;
        }

        [HttpPost]
        public async Task<IActionResult> Dodaj([FromBody] Film f)
        {
            await _client.Cypher.Create("(f: Film $f)")
                                .WithParam("f", f)
                                .ExecuteWithoutResultsAsync();

            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Usun(string Tytul)
        {
            await _client.Cypher.Match("(o:Osoba)-[rr]->(f:Film)")
                                 .Where((Film f) => f.Tytul == Tytul)
                                 .Delete("rr")
                                 .ExecuteWithoutResultsAsync();

            await _client.Cypher.Match("(f:Film)-[rg]->(g:Gatunek)")
                                 .Where((Film f) => f.Tytul == Tytul)
                                 .Delete("rg")
                                 .ExecuteWithoutResultsAsync();

            await _client.Cypher.Match("(f:Film)-[rp]->(p:Produkcja)")
                                 .Where((Film f) => f.Tytul == Tytul)
                                 .Delete("rp")
                                 .ExecuteWithoutResultsAsync();

            await _client.Cypher.Match("(f:Film)")
                                 .Where((Film f) => f.Tytul == Tytul)
                                 .Delete("f")
                                 .ExecuteWithoutResultsAsync();



            return Ok();

        }


    }
}