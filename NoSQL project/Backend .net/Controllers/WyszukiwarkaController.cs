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
    public class WyszukiwarkaController : ControllerBase
    {

        private readonly IGraphClient _client;

        public WyszukiwarkaController(IGraphClient client)
        {
            _client = client;
        }

        

        [HttpGet("Wyszukaj Filmu wraz z jego gatunkiem oraz krajem produkcji")]
        public async Task<IActionResult> WyswietlUlubione(string Tytul)
        {
          var osoby = await _client.Cypher.Match("(o:Osoba)-[rr: Ulubiony_film]-(f:Film)")
                                                  .Where((Film f) => f.Tytul == Tytul)
                                                  .Return(o => o.As<Wyszukiwarka_osoby>()).ResultsAsync;

            var gatunek = await _client.Cypher.Match("(f:Film)-[rg :Gatunek]-(g:Gatunek)")
                                                  .Where((Film f) => f.Tytul == Tytul)
                                                  .Return(g => g.As<Wyszukiwarka_gatunek>()).ResultsAsync;

            var produkcja = await _client.Cypher.Match("(f:Film)-[rp :Produkcja]-(p:Produkcja)")
                                                  .Where((Film f) => f.Tytul == Tytul)
                                                  .Return(p => p.As<Wyszukiwarka_produkcja>()).ResultsAsync;


            return Ok(new { Osoby = osoby, Gatunek = gatunek, Produkcja = produkcja });

        }

    }
}