using System;
using System.Collections.Generic;
using System.Text;

namespace Project0_EktivaBankApp
{
    class Welcome : MethodForAllClass
    {
        public void Begin()
        {
            int LogReg;
            MethodForAllClass M = new Welcome();

            #region //Assign action according to the choice
            LogReg = M.AskIntInput(1,3);

            if (LogReg == 1)
            {
                Registration Reg = new Registration();
                Reg.FirstAction();
            }
            else if (LogReg == 2)
            {
                Login Log = new Login();
                Log.FirstAction();
            }
            else if (LogReg == 3)
            {
                Console.WriteLine("Thank you !!!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Sorry You entered a wrong Number, Try Again !!!"); Console.ResetColor();
                Console.WriteLine(" ");
                Begin();
            }
            #endregion
        }

        public void Message()
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.WriteLine(" ");
        }
    }
}
