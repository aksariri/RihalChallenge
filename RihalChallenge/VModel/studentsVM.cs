using RihalChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RihalChallenge.VModel
{
    public class studentsVM
    {
        public int id { get; set; }
        public countries countries { get; set; }
        public classes classes { get; set; }
        public string name { get; set; }
        public DateTime? date_of_birth { get; set; }
    }
}
