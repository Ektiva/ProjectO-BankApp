using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0_EktivaBankApp
{
    class MenuWelcome : Action
    {
        public MenuWelcome()
        {
        }
 

        public override void Message()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;  Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Menu "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();
            Console.WriteLine("1. Open a new account");
            Console.WriteLine("2. Log Out");
            Console.WriteLine(" ");
        }
    }
}