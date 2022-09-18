using System;
using System.Collections.Generic;

namespace EFCore.Legacy
{
    public partial class Weapons
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int HeroiId { get; set; }

        public virtual Heroes Heroi { get; set; }
    }
}
