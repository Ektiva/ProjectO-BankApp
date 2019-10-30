using System;
using System.Collections.Generic;
using System.Text;

namespace Project0_EktivaBankApp
{
    class MessageTermDep2 : MethodForAllClass, InterfaceMessage
    {
        public void Message()
        {
            Console.WriteLine("Please Choose the Term Deposit lenght ");
            Console.WriteLine("1. 2 Years - 1.5%");
            Console.WriteLine("2. 5 Years - 2.1%");
            Console.WriteLine("");
        }
    }
}
