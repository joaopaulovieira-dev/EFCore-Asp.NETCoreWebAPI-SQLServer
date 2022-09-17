using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Battle Batalha { get; set; }
        public int BatalhaId { get; set; }
    }
}
