using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0_EktivaBankApp
{
    class CreateNewAccounttt : Action
    {
        //public Accounts Acc = new Accounts();

        public CreateNewAccounttt(Customer _CurrCust, int _Choice)
        {
            Choice = _Choice;
            currentCust = _CurrCust;
        }
        public CreateNewAccounttt(Customer _CurrCust)
        {
            currentCust = _CurrCust;
        }
        public CreateNewAccounttt()
        {
        }
        //public override void actionChoice1()
        //{

        //    switch (Choice)
        //    {
        //        case 1: //Checking Account
                    
        //            RegularAccount NewCheckAccB = new RegularAccount();
        //            double Bal = NewCheckAccB.actionChoice();
        //            //Console.WriteLine("The Balence you choose is :" + Bal);

        //            RegularAccount NewCheckAcc = new RegularAccount(currentCust, "Checking Account", Bal);

        //            Acc = NewCheckAcc;

        //            //Console.WriteLine("Account Type" + Acc.AccountType);
        //            //Console.WriteLine("Account Open Date:" + Acc.openDate);
        //            //Console.WriteLine("Account Balance" + Acc.Balance);
        //            //Console.WriteLine("Account Id" + Acc.AccountId);
        //            //Console.WriteLine("Account No" + Acc.AccountNumber);

        //            break;

        //        case 2: //Business Account
        //            RegularAccount NewBusAccB = new RegularAccount();
        //            double Bal1 = NewBusAccB.actionChoice();

        //            RegularAccount NewBusAcc = new RegularAccount(currentCust, "Business Account", Bal1);
        //            Acc = NewBusAcc;

        //            break;

        //        case 3: //Loan 
        //            LoanAccount NewLoaAcc = new LoanAccount(currentCust);
        //            Acc = NewLoaAcc;

        //            break;

        //        case 4: //Term Deposit 
        //            TermDepositAccount NewTDAcc = new TermDepositAccount(currentCust);
        //            Acc = NewTDAcc;

        //            Console.WriteLine("Case 2");

        //            break;

        //        default:
        //            Console.WriteLine("Sorry you choose the wromg number");
        //            int MenuCh;
        //            MethodForAllClass M = new CreateNewAccountMess();
        //            MenuCh = M.AskIntInput();

        //            CreateNewAccounttt NewAccCr = new CreateNewAccounttt(currentCust, MenuCh);
        //            NewAccCr.actionChoice1();

        //            break;
        //    }

        //}
        public override void Message()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.Write("Menu --->  "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Open New Account "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();
            Console.WriteLine("1. Checking account ");
            Console.WriteLine("2. Business account ");
            Console.WriteLine("3. Loan");
            Console.WriteLine("4. Term Deposit");
            Console.WriteLine("5. Cancel");
            Console.WriteLine("");
        }

        public void DisplayAccountCrea_Next(Accounts Acc)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Congratulation " + currentCust.FirstName + ", your account was susceffuly created"); Console.ResetColor();
            Console.WriteLine("");
            Acc.displayAccountMenu();
            Acc.displayAccount();
        }
    }

}
