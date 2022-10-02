using System;
using System.Collections.Generic;

namespace EFCore.Legacy
{
    public partial class SecretIdentities
    {
        public int Id { get; set; }
        public int Nomereal { get; set; }
        public int HeroId { get; set; }

        public virtual Heroes Hero { get; set; }
    }
}
