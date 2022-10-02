using System;
using System.Collections.Generic;

namespace EFCore.Legacy
{
    public partial class HeroBattles
    {
        public int HeroId { get; set; }
        public int BatalhaId { get; set; }
        public int? BattleId { get; set; }

        public virtual Battles Battle { get; set; }
        public virtual Heroes Hero { get; set; }
    }
}
