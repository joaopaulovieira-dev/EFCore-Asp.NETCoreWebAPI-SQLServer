using System;
using System.Collections.Generic;

namespace EFCore.Legacy
{
    public partial class Heroes
    {
        public Heroes()
        {
            HeroBattles = new HashSet<HeroBattles>();
            Weapons = new HashSet<Weapons>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual SecretIdentities SecretIdentities { get; set; }
        public virtual ICollection<HeroBattles> HeroBattles { get; set; }
        public virtual ICollection<Weapons> Weapons { get; set; }
    }
}
