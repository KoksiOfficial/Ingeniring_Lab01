using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes01.AttackPatterns;

namespace Heroes01.GameEntities
{
    public abstract class Hero
    {
        public int helth { get; set; } = 100;
        //true -> alive; false -> dead
        public bool alive { get; set; } = true;
        public string name { get; set; } = "Unknown warrior";

        public List<Ability> abilities { get; set; } = null;
    }
}