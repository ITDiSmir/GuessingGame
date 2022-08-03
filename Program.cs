using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessingGame
{
    internal class Program
    {
        public static string UserInput { get; set; }
        public static string Secret { get; set; }


        static void Main(string[] args)
        {
            Console.WriteLine("Guessing Game");
            Console.WriteLine();

            GenerateSecret();

            for (int i = 0; i < 8; i++)
            {
                Console.Write($"Attempt {i + 1}. Please, write a guess number: ");
                GetUserInput();
                Console.WriteLine();

                if (UserInput == Secret)
                {
                    Console.WriteLine("Number guessed!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                char[] equalDigits = UserInput
                    .Intersect(Secret)
                    .ToArray();
                int p = equalDigits
                    .Where(x => UserInput.IndexOf(x) == Secret.IndexOf(x))
                    .Count();

                Console.WriteLine($"Secret: {Secret} Guess: {UserInput} M: {equalDigits.Length - p}; P: {p}");
                Console.WriteLine();
            }
            Console.WriteLine("You lose, Secret number: "+Secret);
        }

        public static void GenerateSecret()
        {
            Random r = new Random();
            int[] digits = new int[4];
            digits[0] = r.Next(1, 10);

            int number;
            for (int i = 1; i < digits.Length; i++)
            {
                do
                {
                    number = r.Next(0, 10);
                }
                while (digits.Contains(number));
                digits[i] = number;
            }

            Secret = string.Join("", digits);
        }

        public static void GetUserInput()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int result))
                {
                    Console.WriteLine("Convertation error");
                }
                else if (input.Length != 4)
                {
                    Console.WriteLine("Number must have 4 digits");
                }
                else
                {
                    UserInput = input;
                    return;
                }
            }

        }

    }
}
