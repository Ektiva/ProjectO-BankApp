using System;
using System.Collections.Generic;
using System.Text;

namespace Project0_EktivaBankApp
{
    interface MethodForAllClass : InterfaceMessage
    {
        public int AskIntInput()
        {
            Message();
            string input = Console.ReadLine();
            int i;

            while (!Int32.TryParse(input, out i))
            {
                Console.WriteLine(" ");
                Console.WriteLine("--- > Invalid input. Please try again");
                Message();
                input = Console.ReadLine();
            }

            return Convert.ToInt32(input);

        }

        public int AskIntInput(int min, int max)
        {
            Message();
            string input = Console.ReadLine();

            int i;

            while (!Int32.TryParse(input, out i) || min > Convert.ToInt32(input) || Convert.ToInt32(input) > max)
            {
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("--- > Invalid input. Please try again"); Console.ResetColor();
                Message();
                input = Console.ReadLine();
            }
            int valid = Convert.ToInt32(input);
            return valid;
        }

        public int AskIntInput(int min, int max, Customer c)
        {
            Message(c);
            string input = Console.ReadLine();

            int i;

            while (!Int32.TryParse(input, out i) || min > Convert.ToInt32(input) || Convert.ToInt32(input) > max)
            {
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("--- > Invalid input. Please try again"); Console.ResetColor();
                Message();
                input = Console.ReadLine();
            }
            int valid = Convert.ToInt32(input);
            return valid;
        }

        


        public double AskDoubleInput()
        #region// This Method Re-Ask for input until getting an double for input
        {
            Message();
            string input = Console.ReadLine();
            double b;

            while (!Double.TryParse(input, out b))
            {
                Console.WriteLine(" ");
                Console.WriteLine("--- > Invalid input. Please try again");
                Message();
                input = Console.ReadLine();
            }

            return Convert.ToDouble(input);

        }
        #endregion

        public double AskPositiveDoubleInput()

        {
            Message();
            string input = Console.ReadLine();
            double b;

            while (!Double.TryParse(input, out b) || Convert.ToDouble(input) < 0)
            {
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("--- > Invalid input. Please try again"); Console.ResetColor();
                Message();
                input = Console.ReadLine();
            }

            return Convert.ToDouble(input);

        }

    }
}