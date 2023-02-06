using System;
using System.Collections.Generic;
using System.Globalization;
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
        public string TransformExpression(string input)
        {
            string output = string.Empty;
            Stack<char> forOperatorsStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (IsDelimeter(input[i]))
                    continue;

                if (i == 0 && input[i] == '-' || input[i] == '-' && IsOperator(input[i - 1]) && input[i - 1] != ')')
                {
                    output += input[i];
                    i++;
                }

                if (Char.IsDigit(input[i]) || input[i] == ',')
                {
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i];
                        i++;

                        if (i == input.Length)
                            break;
                    }

                    output += " ";
                    i--;
                }

                if (IsOperator(input[i]))
                {
                    if (input[i] == '(')
                    {
                        forOperatorsStack.Push(input[i]);
                    }
                    else if (input[i] == ')')
                    {
                        char s = forOperatorsStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = forOperatorsStack.Pop();
                        }
                    }
                    else
                    {
                        if (forOperatorsStack.Count > 0)
                            if (GetPriority(input[i]) <= GetPriority(forOperatorsStack.Peek()))
                                output += forOperatorsStack.Pop().ToString() + ' ';

                        forOperatorsStack.Push(char.Parse(input[i].ToString()));

                    }


                }

            }

            while (forOperatorsStack.Count > 0)
            {
                output += forOperatorsStack.Pop() + " ";
            }

            return output;
        }
        public double Counting(string input)
        {
            double result = 0;
            Stack<double> temp = new Stack<double>();

            var culture = new CultureInfo("en-US")
            {
                NumberFormat =
                {
                    NumberDecimalSeparator=",",
                }
            };

            if (input == string.Empty)
            {
                return 0;
            }


            for (int i = 0; i < input.Length; i++)
            {
                string a = string.Empty;

                if (i == 0 && input[i] == '-' || input[i] == '-' && Char.IsDigit(input[i + 1]) && i + 1 < input.Length && input[i - 1] != ')')
                {
                    a += input[i];
                    i++;
                }

                if (Char.IsDigit(input[i]) || input[i] == ',')
                {
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        a += input[i];
                        i++;
                        if (input[i] == input.Length) { break; }
                    }
                    temp.Push(double.Parse(a, NumberStyles.Any, culture));
                    i--;
                }
                else if (IsOperator(input[i]))
                {
                    double x = temp.Pop();
                    double y = temp.Pop();

                    switch (input[i])
                    {
                        case '+': result = y + x; break;
                        case '-': result = y - x; break;
                        case '*': result = y * x; break;
                        case '/':
                            if (x == 0)
                            {
                                Console.WriteLine("Dividing by zero! Result will be undefined!");
                            }
                            result = y / x; break;
                    }

                    temp.Push(result);
                }

            }

            return temp.Peek();
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
        private byte GetPriority(char c)
        {
            switch (c)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 5;

                default: return 6;
            }
        }
    }
}
