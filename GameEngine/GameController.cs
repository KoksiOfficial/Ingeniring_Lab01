using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes01.AttackPatterns;
using Heroes01.GameEntities;
using Heroes01.KnightAttacks;
using Heroes01.MageSpells;

namespace Heroes01.GameEngine
{
    public class GameController
    {
        public static (Hero hero1, Hero hero2) Start()
        {
            Hero hero1 = null;
            Hero hero2 = null;

            SetHeroClass(ref hero1, 1);
            if (GetHeroName() is string heroName1)
                hero1!.name = heroName1;
            SetHeroAbilites(hero1!);

            SetHeroClass(ref hero2, 2);
            if (GetHeroName() is string heroName2)
                hero2!.name = heroName2;
            SetHeroAbilites(hero2!);

            return (hero1, hero2);
        }

        public static void DisplayCurrentStats(Hero hero)
        {
            string stats = $"Hero's {hero.name} current stats: health = {hero.helth}, ";
            if (hero is Mage)
                stats += $"mana = {(hero as Mage).mana}";
            else
                stats += $"fatigue = {(hero as Knigth).fatigue}";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(stats);
            Console.ResetColor();
        }

        public static void Attack(Hero atacker, Hero defender)
        {
            Console.WriteLine($"\nWarrior {atacker.name} cast a ability:");
            Console.WriteLine("1 -> fisrt ability/n 2 -> second one");
            var answ = Console.ReadKey();
            var spell = answ.KeyChar;
            if (spell == '1')
            {
                var result = atacker.abilities[0].CastAbility(atacker, defender);
                if (result) atacker.abilities[0].PerformAnimation();
            }
            else if (spell == '2')
            {
                var result = atacker.abilities[1].CastAbility(atacker, defender);
                if (result) atacker.abilities[1].PerformAnimation();
            }
            else
            {
                Console.WriteLine("You did not choose a spell.\n You skip the turn!");
            }
        }

        public static void DeathAnnouncer(Hero winner, Hero looser)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nHero {winner.name} is a WINNER!");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Hero {looser.name} is a looser!");
            Console.ResetColor();
        }

        private static void SetHeroAbilites(Hero hero)
        {
            if (hero is Mage)
            {
                hero.abilities = new Ability[] { new FireBall(), new AvadaKedavra() };
            }
            else
            {
                hero.abilities = new Ability[] { new MightySwing(), new ArtursOath() };
            }
        }

        private static void SetHeroClass(ref Hero? hero, int indx)
        {
            Console.WriteLine($"\nGreetings hero {indx}! Choose your class:");
            Console.WriteLine("1 -> mage;\n2 -> knight");

            var answ = Console.ReadKey();

            if (answ.KeyChar == '1')
            { hero = new Mage(); return; }
            else if (answ.KeyChar == '2')
            { hero = new Knigth(); return; }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ivalid input! Try again:\n");
                Console.ResetColor();
                //recusrion
                SetHeroClass(ref hero, indx);
            }

            // var answ = 1;

            // if (answ == 1)
            // { hero = new Mage(); return; }
            // else if (answ == 2)
            // { hero = new Knigth(); return; }
            // else
            // {
            //     Console.ForegroundColor = ConsoleColor.Red;
            //     Console.WriteLine("Ivalid input! Try again:\n");
            //     Console.ResetColor();
            //     //recusrion
            //     SetHeroClass(ref hero, indx);
            // }
        }

        private static string? GetHeroName()
        {
            Console.WriteLine("\nEnter your name sire/madam: ");
            return Console.ReadLine();
        }
    }
}