using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhMoDev_MathPromptMethodChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
           string name= GetUserName();
         decimal number1=   GetUserNumber1(name);
          decimal number2 =  GetUserNumber2(name, number1);
         decimal answer=   Calculate(number1, number2,name);
            Console.WriteLine("{1}, I've performed the calculation you requested on {0} and {2}. \nHere is your answer: {3}", number1, name, number2,
                answer);
            Console.ReadLine();

        }

        private static decimal Calculate(decimal number1, decimal number2, string name)
        {
          int choice= ChooseCalculationType(name);
            decimal answer = 0;
            switch (choice.ToString())
            {
                case "1":
                  answer =   Addition(number1, number2);
                    break;

                case "2":
                     answer = Subtraction(number1, number2);
                    break;

                case "3":
                    answer = Multiplication(number1, number2);
                    break;

                case "4":
                    answer = Division(number1, number2);
                    break;
            }
            return answer;
        }

        private static decimal Division(decimal number1, decimal number2)
        {
          decimal answer=  number1/number2;
            return answer;
        }

        private static decimal Multiplication(decimal number1, decimal number2)
        {
       decimal  answer=   number1* number2;
            return answer;
        }

        private static decimal Subtraction(decimal number1, decimal number2)
        {
            decimal answer = number1 - number2;
            return answer;
        }

        private static decimal Addition(decimal number1, decimal number2)
        {
            decimal answer = number1 + number2;
            return answer;
        }

        private static int ChooseCalculationType(string name)
        {
            int userSelection = 0;
            bool isNumber = false;
            bool inRange = false;
            Console.WriteLine("Hey {0}, What do you want me to do with these numbers?\n 1. Add\n 2. Subtract\n 3. Multiply\n 4. Divide\n", name);
            do
            {
                Console.Write("Enter the number corresponding to your choice:" );
                string userInput = Console.ReadLine();
                
                try
                {
                     userSelection = int.Parse(userInput);
                    isNumber = true;
                    if (userSelection > 0 && userSelection < 5)
                    {
                        inRange = true;
                    }
                    else
                    {
                        isNumber = false;
                        Console.Clear();
                        Console.WriteLine("{0} is out of range.\n 1. Add\n 2. Subtract\n 3. Multiply\n 4. Divide\n ");
                    }

                }
                catch (Exception)
                {
                    
Console.WriteLine("{0} is not a number.", userInput);                }

            } while (!isNumber|| !inRange);

            return userSelection;


        }

        private static decimal GetUserNumber2(string name, decimal number1)
        {
            decimal secondNumber = 0;
            bool isNumber = false;
            Console.Clear();
            Console.Write("Ok I've got {0}, {1} \n", number1, name);
            do
            {
                Console.Write("now enter a second number:");
                string userInput2 = Console.ReadLine();

                try
                {
                    secondNumber = decimal.Parse(userInput2);
                    isNumber = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("{1}, you entered {0}, try entering a number this time:", userInput2, name);
                }

            } while (!isNumber);
            return secondNumber;
        }

        private static decimal GetUserNumber1(string name)
        {
            decimal firstNumber=0;
            bool isNumber = false;
            Console.Write("Give me a couple numbers to work with {0}. ",name);
            do
            {Console.Write("Enter the first number:");
            string userInput1 = Console.ReadLine();

                try
                {
                    firstNumber = decimal.Parse(userInput1);
                    isNumber = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("{1}, you entered {0}, try entering a NUMBER this time:", userInput1, name);
                }
                
            } while (!isNumber);
            return firstNumber;
        }

        private static string GetUserName()
        {
Console.Write("Enter your name: ");
            string UserName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Hello {0}! I am here to calculate for you.", UserName);
            return UserName;
        }
    }
}
