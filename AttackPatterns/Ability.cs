using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes01.GameEntities;

namespace Heroes01.AttackPatterns
{
    public interface Ability
    {
        string abilityName { get; set; }
        int damage { get; set; }

        bool CastAbility(Hero attacker, Hero defender);
        void PerformAnimation();
    }
}

// Mage mage_attacker;
// Knigth knigth_attacker;
// if (attacker is Mage)
//     mage_attacker = attacker as Mage;
// else knigth_attacker = attacker as Knigth;
