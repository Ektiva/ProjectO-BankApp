using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0_EktivaBankApp
{
    public class MessageLoanAccount : MethodForAllClass, InterfaceMessage
    {
        public void Message()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.Write("Menu --->  Open New Account --- >  "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Loan Account"); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();
            Console.WriteLine("Please enter the Loan Amount");
            Console.WriteLine("");
        }
    }
}
