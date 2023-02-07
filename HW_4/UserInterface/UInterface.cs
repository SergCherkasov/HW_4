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
        private IInputOutput io;

        public UInterface(IInputOutput io)
        {
            this.io = io;
        }
        public void Calculate()
        {
            Engine cm = new Engine();
            //do
            //{
            //    //Console.Clear();
            io.WriteLine($"\tWELCOME TO CALCULATOR APP!");
            Console.WriteLine();
            io.WriteLine("Enter expression:");

            string exp = io.Readline();
            exp = cm.SyntaxAnalyz(exp);
            Console.WriteLine();
            io.WriteLine("Result of Your expression:");
            Console.ForegroundColor = ConsoleColor.Green;
            string transformExp = string.Empty;
            transformExp = cm.TransformExpression(exp);
            var result = cm.Counting(transformExp);
            io.WriteLine(result.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine("Press any Key to Continue...\nPress ESC for EXIT.");

            //}
            //while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        public interface IInputOutput
        {
            string Readline();

            void WriteLine(string str);
        }
        public class ConsoleIO : IInputOutput
        {
            public string Readline() => Console.ReadLine();
            public void WriteLine(string str) => Console.WriteLine(str);

        }
    }
}
