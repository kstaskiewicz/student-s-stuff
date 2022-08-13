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
    public class OsobaController : ControllerBase
    {

        private readonly IGraphClient _client;

        public OsobaController(IGraphClient client)
        {
            _client = client;
        }

        [HttpPost]
        public async Task<IActionResult> NowyUzytkownik([FromBody] Osoba o)
        {
            await _client.Cypher.Create("(o:Osoba $o)")
                                .WithParam("o", o)
                                .ExecuteWithoutResultsAsync();

            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Usun(string Imie)
        {
            await _client.Cypher.Match("(o:Osoba)-[rr :Ulubiony_film]->(f:Film)")
                                 .Where((Osoba o, Film f) => o.Imie == Imie)
                                 .Delete("rr") 
                                 .ExecuteWithoutResultsAsync();
           

            await _client.Cypher.Match("(o:Osoba)")
                                 .Where((Osoba o) => o.Imie == Imie)
                                 .Delete("o")
                                 .ExecuteWithoutResultsAsync();
            return Ok();

        }



    }
}