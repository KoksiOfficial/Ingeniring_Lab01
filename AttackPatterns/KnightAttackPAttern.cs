using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes01.GameEntities;

namespace Heroes01.AttackPatterns
{
    public abstract class KnightAttackPattern : Ability
    {
        public abstract string abilityName { get; set; }
        public abstract int damage { get; set; }
        public abstract int fatiguePoints { get; set; }
        public abstract void PerformAnimation();
        public virtual bool CastAbility(Hero attacker, Hero defender)
        {
            var knight_attacker = attacker as Knigth;
            if (knight_attacker!.fatigue <= fatiguePoints)
            {
                knight_attacker!.fatigue += fatiguePoints;
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
                IAmTooTiredAnnouncer();
                return false;
            }
            return true;
        }
        protected void IAmTooTiredAnnouncer()
        {
            Console.WriteLine($"\nYou are too tired warrior. You can not use {abilityName} attack!\nYou will skip the attack, prepare yourself!");
        }
    }
}