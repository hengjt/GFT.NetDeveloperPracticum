using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFT.NetDeveloperPracticum.Model.Entities;

namespace GFT.NetDeveloperPracticum
{
    class Program
    {
        private static void Main(string[] args)
        {
            var userAnswer = true; 
            do
            {
                var input = GetInput();

                const string msg = "Something was wrong, please check the error and try again.";
                try
                {
                    var output = new MealManager().Manager(input);

                    var result = String.Empty;

                    output.Menu.ForEach(p =>
                                        {
                                            result += String.Format("{0}, ", p);
                                        });

                    Console.WriteLine("Dishes for " + output.TimeOfday + ": " +
                                      result.Substring(0, result.Count() - 2));
                }
                catch (Exception e)
                {
                    ErrorMessage(msg);
                    Console.WriteLine(e.Message);
                }

                if (userAnswer)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Seach again? y/n");
                    var screenResponse = Console.ReadLine();
                    userAnswer = true ? screenResponse == "y" : false;
                    Console.Clear();
                }

            } while (userAnswer);

        }

        private static void ErrorMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        private static string GetInput()
        {
            Console.WriteLine("Insert the time and the dishes separated by commas.");
            var input = Console.ReadLine();
            return input;
        }
    }
}
