using Bazy_NoSQL.Models;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;
using Neo4jClient;
using Neo4jClient.Transactions;
using SolrNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazy_NoSQL.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class UlubioneController : ControllerBase
    {

        private readonly IGraphClient _client;
     

        public UlubioneController(IGraphClient client)
        {
            _client = client;
        }

       
        [HttpPost]
        public async Task<IActionResult> Dodaj(string Imie, string Tytul)
        {
            await _client.Cypher.Match("(i:Osoba), (f:Film)")
                                .Where((Osoba i, Film f) => i.Imie == Imie && f.Tytul == Tytul)
                                .Create("(i)-[rr :Ulubiony_film]->(f)")
                                .ExecuteWithoutResultsAsync();

            return Ok();
        }


        [HttpGet("Wyszukaj po imieniu użytkownika")]
        public async Task<IActionResult> WyswietlUlubione(string Imie)
        {
           var WyswietlUlubione = await _client.Cypher.Match("(o:Osoba)-[rr :Ulubiony_film]-(f:Film)")
                                                  .Where((Osoba o) => o.Imie == Imie)
                                                  .Return(f => f.As<Ulubione>()).ResultsAsync;

            return Ok(WyswietlUlubione);
        }


        [HttpDelete]
        public async Task<IActionResult> Usun(string Imie, string Tytul)
        {
            await _client.Cypher.Match("(o:Osoba)-[rr]->(f:Film)")
                                 .Where((Osoba o, Film f) => o.Imie == Imie && f.Tytul == Tytul )
                                 .Delete("rr")
                                 .ExecuteWithoutResultsAsync();
            return Ok();

        }

    }
}