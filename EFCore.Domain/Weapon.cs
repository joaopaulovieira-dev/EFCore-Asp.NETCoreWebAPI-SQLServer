using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Hero Heroi { get; set; }
        public int HeroiId { get; set; }
    }
}
