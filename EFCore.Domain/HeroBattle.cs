using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain
{
    public class HeroBattle
    {
        public int HeroId { get; set; }
        public int BatalhaId { get; set; }

        public Hero Hero { get; set; }
        public Battle Battle { get; set; }
    }
}
