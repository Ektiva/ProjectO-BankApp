using System;
using System.Collections.Generic;
using System.Text;

namespace Project0_EktivaBankApp
{
    class MessageLoanAcc2 : MethodForAllClass, InterfaceMessage
    {
        public void Message()
        {
            Console.WriteLine("Please Choose the Loan Term");
            Console.WriteLine("1. 2 Years - 2.8%");
            Console.WriteLine("2. 5 Years - 4.7%");
            Console.WriteLine("");
        }
    }
}

