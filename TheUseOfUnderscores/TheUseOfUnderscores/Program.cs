using System;
using System.Net.Http.Headers;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Can use an underscore for a valid variable name..
            //int _ = 0;
            //_++;
            //Console.Write(_);

            //Investigating the use of underscores in C# 12.0
            //Discards in out parameters
            Console.WriteLine("Please enter your favourite number: ");
            string number = Console.ReadLine();

            int result;
            if (int.TryParse(number, out result))
            {
                Console.WriteLine($"Your age is {result}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for your age.");
            }

            if (int.TryParse(number, out _)) //_ means "I don't care about the output" and no variable is created.
            {
                Console.WriteLine("The conversion was successful, but we don't need the result!!!!??!");
            }

            // Discards in tuple deconstruction
            var (name, _, age) = GetPerson(); //The second returned value is ignored and _ again acts as a discard, not a variable.


            // Lambda parameters named _

            Func<int, int> square = _ => _ * _; // Here, _ is actually a parameter name, not a discard. This works when there’s only one parameter.

            Console.WriteLine(square(9));

            // For multiple parameters, you can use multiple underscores:
            Func<int, int, int> add = (_, __) => _ + __;

            Console.WriteLine(add(9, 11));

            // Pattern matching and switch expressions
            string value = "Hello, World!";
            switch (value)
            {
                case "Hello, World!":
                    Console.WriteLine("Exact match");
                    break;
                case string _:
                    Console.WriteLine("Matches anything");
                    break;
                // Errors:
                //case _:
                //    Console.WriteLine("Matches anything");
                //    break;
                default: // Unreachable?
                    Console.WriteLine("Default case");
                    break;
            }
        }

        private static (string name, string d , int age) GetPerson()
        {
            return ("John Doe", "Some other info", 30);
        }

    }
}



