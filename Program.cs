using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0_EktivaBankApp
{
    class Program
    {
       public static  void ChoseNumer(int min, int max)
        {
            Console.WriteLine("Entre un nomnre compris entre 1 et 3");
            string inputConfirm = Console.ReadLine();
            int k;
            while (!Int32.TryParse(inputConfirm, out k))
            {

                Console.WriteLine("Invalid input. Please try again");
                inputConfirm = Console.ReadLine();
            }

            int valid = Convert.ToInt32(inputConfirm);

            if(min > valid || valid > max) 
            {
                ChoseNumer(min, max);
            }
            else
            {
                Console.WriteLine("Congratulation tu as choisis " + valid);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(" ");
            Console.Write(string.Concat(Enumerable.Repeat("-", 45)));
            Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("EKTIVA BANKING APPLICATION "); Console.ResetColor();
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 44)));
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine("--- Welcome to Ektiva Banking Application--- "); Console.ResetColor();
            Console.WriteLine(" ");
            Console.WriteLine("Anytime just choose the number corresponding of your choice and type Enter!!!");
            Console.WriteLine(" ");

            new Welcome().Begin();



        }

    }
}
