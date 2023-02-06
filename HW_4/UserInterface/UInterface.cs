using HW_4.CalculatorMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4.UserInterface
{
    public class UInterface
    {
        public void Calculate()
        {
            Engine cm = new Engine();
            do
            {
                Console.Clear();
                Console.WriteLine($"\tWELCOME TO CALCULATOR APP!");
                Console.WriteLine();
                Console.WriteLine("Enter expression:");

                string exp = Console.ReadLine();                
                exp = cm.SyntaxAnalyz(exp);
                Console.WriteLine();
                Console.WriteLine("Result of Your expression:");
                Console.ForegroundColor = ConsoleColor.Green;
                string transformExp = string.Empty;
                transformExp = cm.TransformExpression(exp);
                var result = cm.Counting(transformExp);
                Console.WriteLine(result);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press any Key to Continue...\nPress ESC for EXIT.");

            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
