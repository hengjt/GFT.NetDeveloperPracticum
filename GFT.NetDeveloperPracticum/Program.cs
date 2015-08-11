using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFT.NetDeveloperPracticum.Model;
using GFT.NetDeveloperPracticum.Model.Entities;
using GFT.NetDeveloperPracticum.Model.Entities.BussinessExceptions;
using GFT.NetDeveloperPracticum.Model.Entities.Contracts;
using GFT.NetDeveloperPracticum.Model.Entities.Enums;

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
                    var time = MealTime.GetTime(input);
                    var strategy = time == EnumDishesTime.Morning
                                        ? (IScheduleStrategy) new MorningMeal()
                                        : new NightMeal();

                    var output = new MealManager(strategy, time).Manager(input);

                    var result = String.Empty;

                    if (output.Menu.Any())
                    {
                        output.Menu.ForEach(p =>
                        {
                            result += String.Format("{0}, ", p);
                        });

                        Console.WriteLine("Dishes for " + output.TimeOfday + ": " +
                                          result.Substring(0, result.Count() - 2));
                    }
                    else
                    {
                        throw new ExceptionGeneric("Error: The inserted text is incorrect.");
                    }
                    
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
