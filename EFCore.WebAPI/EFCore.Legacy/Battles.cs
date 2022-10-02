using System;
using System.Collections.Generic;

namespace EFCore.Legacy
{
    public partial class Battles
    {
        public Battles()
        {
            HeroBattles = new HashSet<HeroBattles>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public virtual ICollection<HeroBattles> HeroBattles { get; set; }
    }
}
