using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes01.AttackPatterns;
using Heroes01.GameEntities;

namespace Heroes01.Projectiles
{
    public class Catapult : Ability
    {
        public string abilityName { get; set; } = "Catapult";
        public int damage { get; set; } = 10;
        public bool CastAbility(Hero attacker, Hero defender)
        {
            if (defender.helth > damage)
                defender.helth -= damage;
            else
                defender.alive = false;
            return true;
        }

        public void PerformAnimation()
        {
            DrawCatapult();
            AnimateProjectile();
        }
        static void DrawCatapult()
        {
            // Drawing the catapult base at fixed position
            Console.SetCursorPosition(0, Math.Abs(Math.Min(12, Console.BufferHeight - 1)));
            Console.WriteLine("       ____               ");
            Console.WriteLine("      /    \\               ");
            Console.WriteLine("     /      \\____           ");
            Console.WriteLine("    /           O\\_________ ");
            Console.WriteLine("   /            /            \\");
            Console.WriteLine("  /            /              \\");
            Console.WriteLine(" |___________|                O");
            Console.WriteLine("   O        O                / \\");
            Console.WriteLine("  / \\      / \\              /   \\");
        }

        static void AnimateProjectile()
        {
            // Trajectory control parameters
            int startX = 15;
            int startY = 7;
            int endX = 70;   // End position of the projectile
            int height = 10; // Height of the projectile arc

            // Loop to move the projectile from left to right
            for (int x = startX; x <= endX; x++)
            {
                // Calculate the height of the projectile to create a parabolic arc
                int y = (int)(startY - height * Math.Sin((Math.PI * (x - startX)) / (endX - startX)));

                // Clear the previous projectile
                Console.Clear();

                // Redraw the catapult after clearing
                DrawCatapult();

                // Set projectile color to red
                Console.ForegroundColor = ConsoleColor.Red;

                // Set the cursor position to where the projectile is in the air
                Console.SetCursorPosition(Math.Abs(x), Math.Abs(y));
                Console.Write("O");  // Represent the projectile

                // Reset the console color to default
                Console.ResetColor();

                // Delay to simulate movement speed
                Thread.Sleep(100);
            }

            // Final position message
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("The projectile has been launched!");
        }
    }
}