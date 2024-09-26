using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes01.AttackPatterns;

namespace Heroes01.MageSpells
{
    public class FireBall : MageAttackPattern
    {
        public override string abilityName { get; set; }
        public override int damage { get; set; }
        public override int manaCost { get; set; }
        public FireBall()
        {
            abilityName = "Fire Ball";
            manaCost = 25;
            damage = 32;
        }
        static char[,] GenerateFireball(int size)
        {
            char[,] fireball = new char[size, size];
            int centerX = size / 2;
            int centerY = size / 2;
            int radius = size / 2;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // Calculate distance from center to create a spherical look
                    double distance = Math.Sqrt(Math.Pow(i - centerX, 2) + Math.Pow(j - centerY, 2));

                    // Set characters based on distance from the center (core to edges)
                    if (distance < radius * 0.4) // Core of the fireball
                    {
                        fireball[i, j] = '@';
                    }
                    else if (distance < radius * 0.7) // Middle flame
                    {
                        fireball[i, j] = '*';
                    }
                    else if (distance < radius) // Outer flame
                    {
                        fireball[i, j] = '.';
                    }
                    else
                    {
                        fireball[i, j] = ' '; // Empty space around the fireball
                    }
                }
            }
            return fireball;
        }

        // Display the fireball with gradient colors
        static void DisplayFireball(char[,] fireball)
        {
            int size = fireball.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    char fireChar = fireball[i, j];

                    // Apply different colors based on the character intensity
                    switch (fireChar)
                    {
                        case '@':  // Core of the fireball
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case '*':  // Middle of the flame
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case '.':  // Outer flame
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                        default:   // Empty space
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                    }
                    Console.Write(fireChar);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public override void PerformAnimation()
        {
            int size = 15;  // Fireball size (can be increased for larger fireball)

            for (int k = 0; k < 10; k++)  // Loop for animation effect
            {
                Console.Clear();  // Clear the console
                char[,] fireball = GenerateFireball(size);
                DisplayFireball(fireball);
                Thread.Sleep(150);  // Frame delay for animation
            }
        }
    }
}