using System;
using System.Collections.Generic;
using System.Text;

namespace Project0_EktivaBankApp
{
    class CreateNewAccountMess : Action
    {
        public CreateNewAccountMess()
        {
        }

        public override void Message()
        {
            Console.WriteLine("");
            //Console.WriteLine("Open New Account");
            //Console.WriteLine("----------------------");
            Console.WriteLine("1. Checking account ");
            Console.WriteLine("2. Business account ");
            Console.WriteLine("3. Loan");
            Console.WriteLine("4. Term Deposit");
            Console.WriteLine("5. Cancel");
            Console.WriteLine("");
        }
    }
}
