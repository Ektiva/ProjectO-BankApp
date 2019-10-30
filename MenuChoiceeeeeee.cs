using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0_EktivaBankApp
{
    class MenuChoiceeeeeee : Action
    {
        public MenuChoiceeeeeee()
        {
        }

        public override void Message()
        {

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Menu"); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();
            Console.WriteLine("1. Open a new account");
            Console.WriteLine("2. Display Account list");
            Console.WriteLine("3. Make a transfer");
            Console.WriteLine("4. Deposit");
            Console.WriteLine("5. Withdraw");
            Console.WriteLine("6. Pay a loan installment");
            Console.WriteLine("7. Log Out");
            Console.WriteLine("");
        }
    }
}
