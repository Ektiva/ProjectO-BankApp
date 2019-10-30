using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0_EktivaBankApp
{
    public class TermDepositAccount : Accounts
    {
        //int yearTerm = 0;

        public TermDepositAccount()
        {

        }
        public TermDepositAccount(Customer CurrentCust)
        {

            AccountType = "Term Deposit";
            AccountNumber = AccountNbrCount;
            openDate = DateTime.Now;

            Random rdn = new Random();

            if (AccountNbrCount < 10)
            {
                AccountId = "" + CurrentCust.FirstName[0] + CurrentCust.LastName[0] + "00" + AccountNbrCount + rdn.Next(1, 9);
            }
            else if (AccountNbrCount < 100)
            {
                AccountId = "" + CurrentCust.FirstName[0] + CurrentCust.LastName[0] + "0" + AccountNbrCount + rdn.Next(10, 99);
            }
            else
            {
                AccountId = "" + CurrentCust.FirstName[0] + CurrentCust.LastName[0] + AccountNbrCount + rdn.Next(100, 999);
            }

            double MenuCh;
            MethodForAllClass M = new MessageTermDeposit();
            MenuCh = M.AskPositiveDoubleInput();

            Balance = MenuCh;

            TermDepositChoice();

            AccountNbrCount++;

            TransactionMenuAdd("Type", "Description", "Amount", "Balance Before", "Balance After");
        }

        public void TermDepositChoice()
        {

            int MenuCh;
            MethodForAllClass M = new MessageTermDep2();
            MenuCh = M.AskIntInput(1,2);

            int _yearTerm = MenuCh;

            if (_yearTerm == 1 || _yearTerm == 2)
            {
                yearTerm = _yearTerm;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Sorry you enter the wrong number"); Console.ResetColor();
                TermDepositChoice();
            }
        }

        public override void displayAccountMenu()
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.WriteLine("" + uniform("No", 5) + " | " + "" + uniform("Account Type :", 20)
                + " | " + uniform("Account Number :", 20) + " | " + uniform("Balance :", 15)
                + " | " + uniform("Maturity:", 10) + " | " + uniform("Interest :", 15)+ " | " + uniform("Open Date :", 15));
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
        }

        public override void displayAccount()
        {
            if (yearTerm == 1)
            {
                Console.Write("" + uniform("" + AccountNumber, 5) + " | " + "" + uniform(AccountType, 20)
                    + " | " + uniform(AccountId, 20) + " | " + uniform("" + Math.Round(Balance, 2), 15)
                    + " | " + uniform("" + 2 + " Years", 10) + " | " + uniform("" +1.5, 15) + " | " + uniform("" + openDate.ToString("MM/dd/yy"), 15));
            }
            else
            {
                Console.Write("" + uniform("" + AccountNumber, 5) + " | " + "" + uniform(AccountType, 20)
                    + " | " + uniform(AccountId, 20) + " | " + uniform("" + Math.Round(Balance, 2), 15) + " | " + uniform("" + 5 + " Years", 10)
                    + " | " + uniform("" + 2.1, 15) + " | " + uniform("" + openDate.ToString("MM/dd/yy"), 15));
            }
            Console.WriteLine("");
        }

        public new void Message()
        {

        }
    }
}

