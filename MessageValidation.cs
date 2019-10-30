using System;
using System.Collections.Generic;
using System.Text;

namespace Project0_EktivaBankApp
{
    class MessageValidation : MethodForAllClass, InterfaceMessage
    {
        public void Message()
        {
            Console.WriteLine("");
            Console.WriteLine( "Please confirm the transaction");
            Console.WriteLine(" ");
            Console.WriteLine("1. Confirm ");
            Console.WriteLine("2. Cancel");
        }
    }
}
