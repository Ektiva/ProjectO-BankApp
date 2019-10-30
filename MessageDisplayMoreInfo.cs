using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0_EktivaBankApp
{
    class MessageDisplayMoreInfo : MethodForAllClass, InterfaceMessage
    {
        public void Message(Customer c)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.Write("Menu --->  Display My Account List ---> "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("More Information  "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();
            Console.WriteLine(" ");
            Console.WriteLine("Choose the No of the Account ");
            Console.WriteLine(" ");
            c.displayAllAccountList();
        }
        public void Message()
        {
        }
    }
}
