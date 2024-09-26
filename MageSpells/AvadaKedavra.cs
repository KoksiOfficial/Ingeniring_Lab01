using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes01.AttackPatterns;

namespace Heroes01.MageSpells
{
    public class AvadaKedavra : MageAttackPattern
    {
        public override string abilityName { get; set; }
        public override int damage { get; set; }
        public override int manaCost { get; set; }
        public AvadaKedavra()
        {
            abilityName = "Avada Kedavra";
            manaCost = 50;
            damage = 55;
        }
        static char[,] GenerateExplosion(int size)
        {
            char[,] explosion = new char[size, size];
            int centerX = size / 2;
            int centerY = size / 2;
            int radius = size / 2;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // Calculate distance from center to create a circular explosion
                    double distance = Math.Sqrt(Math.Pow(i - centerX, 2) + Math.Pow(j - centerY, 2));

                    // Set characters based on distance to simulate an explosion
                    if (distance < radius * 0.4) // Core of the explosion
                    {
                        explosion[i, j] = '@';
                    }
                    else if (distance < radius * 0.7) // Middle of the explosion
                    {
                        explosion[i, j] = 'o';
                    }
                    else if (distance < radius) // Outer area of the explosion
                    {
                        explosion[i, j] = '*';
                    }
                    else
                    {
                        explosion[i, j] = ' '; // Empty space around the explosion
                    }
                }
            }
            return explosion;
        }

        // Display the explosion with colors
        static void DisplayExplosion(char[,] explosion, int intensity)
        {
            int size = explosion.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    char explosionChar = explosion[i, j];

                    // Use different shades of green for different parts of the explosion
                    if (explosionChar == '@')
                    {
                        Console.ForegroundColor = intensity > 2 ? ConsoleColor.Green : ConsoleColor.DarkGreen; // Core (bright)
                    }
                    else if (explosionChar == 'o')
                    {
                        Console.ForegroundColor = intensity > 1 ? ConsoleColor.Green : ConsoleColor.DarkGreen; // Middle (mid-intensity)
                    }
                    else if (explosionChar == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen; // Outer (fading)
                    }

                    Console.Write(explosionChar);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        public override void PerformAnimation()
        {
            int size = 20;  // Explosion size (can be increased for larger explosion)
            int explosionSteps = 5;  // Number of stages in the explosion

            for (int step = 0; step < explosionSteps; step++)  // Loop through explosion stages
            {
                Console.Clear();  // Clear the console
                char[,] explosion = GenerateExplosion(size);
                DisplayExplosion(explosion, step);  // Display each stage of the explosion
                Thread.Sleep(200);  // Delay between stages
            }

            // Final bright explosion stage
            for (int flash = 0; flash < 3; flash++)
            {
                Console.Clear();
                char[,] explosion = GenerateExplosion(size);
                DisplayExplosion(explosion, 3);  // Bright green flash
                Thread.Sleep(100);
                Console.Clear();
                Thread.Sleep(100);  // Create a flashing effect
            }
        }
    }
}