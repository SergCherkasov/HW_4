using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4.CalculatorMechanics
{
    public class Engine
    {
        public string SyntaxAnalyz(string input)
        {
            input = input.Replace(" ", "");//Deleting white-spcaes
            input = input.Replace(".", ",");//Replacing dots on comas

            foreach (char c in input)
            {
                if (!Char.IsDigit(c) && !IsOperator(c) && !IsDelimeter(c) && !c.Equals(','))//If letter or wrong sign
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Expression has wrong char!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return string.Empty;
                }
            }
            for (int i = 0; i < input.Length; i++)//repeating signs and signs in the begining of expression except "+-"
            {
                if (i == 0 && IsOperator(input[i]) && input[i] != '+' && input[i] != '-' && input[i] != '(')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Expression has wrong sign in the very beginning!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return string.Empty;
                }
                if (0 < i && i + 1 < input.Length && IsOperator(input[i]) && input[i] != '-' && IsOperator(input[i + 1]) && input[i + 1] != '-' && IsOperator(input[i]) && input[i] != '(' && IsOperator(input[i + 1]) && input[i + 1] != '(' && IsOperator(input[i]) && input[i] != ')' && IsOperator(input[i + 1]) && input[i + 1] != ')')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Expression has extra sign!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return string.Empty;
                }
            }
            for (int i = 0; i < input.Length; i++)//if "double" number starting with coma without null
            {
                if (i == 0 && input[i] == ',')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Expression has wrong number!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return string.Empty;
                }
                if (i > 0 && input[i] == ',' && IsOperator(input[i - 1]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Expression has wrong number!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return string.Empty;
                }
            }
            return input;
        }

        private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
            {
                return true;
            }
            return false;
        }
        private bool IsOperator(char c)
        {
            if ("+-/*()".IndexOf(c) != -1)
            {
                return true;
            }
            return false;
        }
    }
}
