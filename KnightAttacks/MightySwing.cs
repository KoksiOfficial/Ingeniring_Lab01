using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes01.AttackPatterns;

namespace Heroes01.KnightAttacks
{
    public class MightySwing : KnightAttackPattern
    {
        public override string abilityName { get; set; }
        public override int damage { get; set; }
        public override int fatiguePoints { get; set; }
        public MightySwing()
        {
            abilityName = "Mighty Swing";
            fatiguePoints = 10;
            damage = 20;
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
        static void DisplaySword(int position, int swingAngle, int screenWidth)
        {
            Console.Clear(); // Clear the console before each frame

            // Adjust sword's horizontal position based on swingAngle (simulating swing)
            int swordLength = sword.Length;
            for (int i = 0; i < swordLength; i++)
            {
                int offset = position + i;

                // Make sure the sword stays within screen bounds
                if (offset >= 0 && offset < screenWidth)
                {
                    Console.SetCursorPosition(offset, i);
                    Console.WriteLine(sword[i]);
                }
            }

            // Mid-swing impact effect
            if (swingAngle == 90) // Simulate "cut" effect at the middle of the swing
            {
                Console.SetCursorPosition(position + swordLength, swordLength / 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**** IMPACT ****");
                Console.ResetColor();
            }
        }

        public override void PerformAnimation()
        {
            int screenWidth = 80;  // Width of the terminal window
            int swordPosition = 0;  // Sword starts from the left side of the screen
            int delay = 100;  // Speed of the swinging sword (in milliseconds)

            // Swing the sword from left to right
            for (int angle = 0; angle <= 180; angle += 6)  // Swing in 30-degree increments
            {
                // Calculate sword position based on swing angle (simulate arc)
                swordPosition = (int)((screenWidth / 2) * Math.Sin(Math.PI * angle / 180));

                // Display the sword in its current swing position
                DisplaySword(swordPosition, angle, screenWidth);
                Thread.Sleep(delay);  // Delay for the animation
            }

            // Final swing impact flash effect
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                DisplaySword(swordPosition, 90, screenWidth);  // Final impact frame
                Thread.Sleep(100);
                Console.Clear();
                Thread.Sleep(100);  // Simulate a flashing effect for the final impact
            }
        }
    }
}