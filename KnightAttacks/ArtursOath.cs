using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes01.AttackPatterns;

namespace Heroes01.KnightAttacks
{
    public class ArtursOath : KnightAttackPattern
    {
        public override string abilityName { get; set; }
        public override int damage { get; set; }
        public override int fatiguePoints { get; set; }
        public ArtursOath()
        {
            abilityName = "Arthur`s Oath";
            fatiguePoints = 60;
            damage = 60;
        }

        // Sword ASCII representation
        static string[] sword = new string[]
        {
        "    O",    // Pommel
        "    |",    // Handle
        "    |",    // Handle
        "   /|\\",   // Guard
        "  / | \\",  // Guard
        " /  |  \\", // Guard
        "    |",    // Blade
        "    |",    // Blade
        "    |",    // Blade
        "    |",    // Blade
        "    |",    // Blade
        "    |"     // Tip of the sword
        };

        // Function to display the sword at a specific horizontal position with optional rotation
        static void DisplaySword(int position, int height)
        {
            Console.Clear(); // Clear the console before each frame
            int swordHeight = sword.Length;

            // Print empty lines until the sword's current position
            for (int i = 0; i < position; i++)
            {
                Console.WriteLine();
            }

            // Print the sword starting from its current position
            for (int i = 0; i < swordHeight; i++)
            {
                if (position + i < height)
                {
                    Console.WriteLine(sword[i]);
                }
            }

            // If the sword has reached the bottom, print impact effect
            if (position + swordHeight >= height)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n MIGHTY IMPACT!");
                Console.ResetColor();
            }
        }

        public override void PerformAnimation()
        {
            int height = 20;  // Total height of the terminal window
            int swordPosition = 0;  // Initial sword position (top of the screen)
            int delay = 200;  // Speed of the falling sword (in milliseconds)

            // Simulate the sword falling down
            while (swordPosition + sword.Length < height)
            {
                DisplaySword(swordPosition, height);
                Thread.Sleep(delay);  // Delay for the animation
                swordPosition++;  // Move sword down by one line
            }

            // Final impact and ground shake effect
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                DisplaySword(height - sword.Length, height);
                Thread.Sleep(100);
                Console.Clear();
                Thread.Sleep(100);  // Simulate a flashing effect for the impact
            }
        }
    }
}