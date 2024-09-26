using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes01.GameEntities;

namespace Heroes01.AttackPatterns
{
    public abstract class MageAttackPattern : Ability
    {
        public abstract string abilityName { get; set; }
        public abstract int damage { get; set; }
        public abstract int manaCost { get; set; }
        public abstract void PerformAnimation();
        public virtual bool CastAbility(Hero attacker, Hero defender)
        {
            var mage_attacker = attacker as Mage;
            if (mage_attacker!.mana >= manaCost)
            {
                mage_attacker!.mana -= manaCost;
                if (defender.helth > damage)
                {
                    defender.helth -= damage;
                }
                else
                {
                    defender.alive = false;
                }
            }
            else
            {
                IHaveNoManaAnouncer();
                return false;
            }
            return true;
        }
        protected void IHaveNoManaAnouncer()
        {
            Console.WriteLine($"\nYou are too tired mighty mage. You can not use {abilityName} spell!\nYou will skip the attack, prepare yourself!");
        }
    }
}