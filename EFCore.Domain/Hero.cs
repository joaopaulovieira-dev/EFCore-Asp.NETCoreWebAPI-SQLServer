using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain
{
    public class Hero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public SecretIdentity SecretIdentity { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<HeroBattle> HeroesBattles { get; set; }
    }
}
