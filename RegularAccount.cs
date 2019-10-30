using System;
using System.Collections.Generic;
using System.Text;

namespace Project0_EktivaBankApp
{
    public class RegularAccount : Accounts
    {
        /// <summary>
        /// Assign a New Account at the Customer on parameter
        /// </summary>
        /// <param name="CurrentCust"></param>
        /// <param name="type"></param>
        /// <param name="term"></param>

        public RegularAccount()
        {

        }

        public double actionChoice()
        {
            //double MenuCh;
            MethodForAllClass M = new MessageRegularAcc();
            return M.AskPositiveDoubleInput();
        }
        public RegularAccount(Customer CurrentCust, string type, double _balance)
        {
            AccountType = type;
            openDate = DateTime.Now;

            //double MenuCh;
            //MethodForAllClass M = new MessageRegularAcc();
            //MenuCh = M.AskDoubleInput();

            Balance = _balance;

            AccountNumber = AccountNbrCount;

            Random rdn = new Random();
            #region
            if(AccountNbrCount < 10)
            {
                AccountId = "00" +AccountNbrCount + rdn.Next(100,999);
            } else if (AccountNbrCount < 100)
            {
                AccountId = "0" +AccountNbrCount + rdn.Next(100, 999);
            }
            else
            {
                AccountId = "" +AccountNbrCount + rdn.Next(100, 999);
            }
            #endregion
            
            #region
            if (type == "Checking Account")
            {
                interestRate = "0.1";
            }else if (type == "Business Account")
            {
                interestRate = "N/A";
            }
            #endregion
           
            AccountNbrCount++;

            TransactionMenuAdd("Type", "Description", "Amount", "Balance Before", "Balance After");
        }

        public override void displayAccount()
        {
            Console.Write("" + uniform("" + AccountNumber, 5) + " | " + "" + uniform(AccountType, 20) + " | " 
                + uniform(AccountId, 20) + " | " + uniform("" + Math.Round(Balance, 2), 15)
                + " | " + "" + uniform(""+interestRate, 15) + " | " + uniform("" + openDate.ToString("MM/dd/yy"), 15));
            Console.WriteLine("");
        }

        //public new void Message()
        //{
        //    Console.WriteLine("");
        //    Console.WriteLine("Open new " + AccountType);
        //    Console.WriteLine("------------------------------");
        //    Console.WriteLine("Please enter the Initial Balance");
        //    Console.WriteLine("");
        //}
    }
}
