using System;
using System.Collections.Generic;

namespace Athenium.Percentile
{
    public class Program
    {
        public Program()
        {
            StartInput();
        }

        private void StartInput()
        {
            Console.Clear();
            Console.Write("Would you like to enter input (1) or use random values (0)? ");
            var input = Convert.ToInt32(Console.ReadLine().Trim());

            switch (input)
            {
                case 0: UseRandom();
                    break;
                case 1: UseInput();
                    break;
                default: StartInput();
                    break;
            }
        }

        private void UseInput()
        {
            Console.Clear();
            Console.WriteLine("Please enter a comma separated list of values. Spaces are allowed.");
            var rawInput = Console.ReadLine();

            var cleanInput = rawInput.Replace(" ", "");
            var rawScores = new List<int>();

            foreach (var item in cleanInput.Split(','))
            {
                try
                {
                    rawScores.Add(Convert.ToInt32(item));
                }
                catch (Exception)
                {
                    Console.WriteLine($"There was a problem converting \'{item}\' to an integer. This value will be ignored...");
                    continue;
                }
            }

            //Display Data
            Console.WriteLine($"Amount of Scores: {rawScores.Count}");

            //Determine Grades
            var grades = PercentileHelper.Percentile(rawScores);

            //Display Data
            foreach (var Key in grades.Keys) Console.WriteLine($"{Key} Grades: {string.Join(", ", grades[Key])}");

            Console.ReadKey();
        }

        private void UseRandom()
        {
            //Create random values
            var rand = new Random();
            var scores = new List<int>();
            var amount = rand.Next(1, 41);

            //Fill List
            for (int i = 0; i < amount; i++) scores.Add(rand.Next(0, 101));

            //Display Data
            Console.WriteLine($"Amount of Scores: {scores.Count}");
            Console.WriteLine($"Raw Scores: {string.Join(", ", scores)}");

            //Determine Grades
            var grades = PercentileHelper.Percentile(scores);

            //Display Data
            foreach (var Key in grades.Keys) Console.WriteLine($"{Key} Grades: {string.Join(", ", grades[Key])}");

            Console.ReadKey();
        }

        public static void Main (string[] args)
        {
            var p = new Program();
        }
    }
}
