using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazy_NoSQL.Models
{
    public class Film
    {

        public string Tytul { get; set; }

        public string Premiera  { get; set; }

        public int Czas_trwania_w_min { get; set; }

        public string Rezyser { get; set; }

        public int Ranking { get; set; }

   
    }
}
