using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0_EktivaBankApp
{
    public class LoanAccount : Accounts
    {
        //int yearTerm =0;
        public LoanAccount(Customer CurrentCust)
        { 
            AccountType = "Loan";
            AccountNumber = AccountNbrCount;
            openDate = DateTime.Now;

            Random rdn = new Random();

            if (AccountNbrCount < 10)
            {
                AccountId = "00" + AccountNbrCount + rdn.Next(100, 999);
            }
            else if (AccountNbrCount < 100)
            {
                AccountId = "0" + AccountNbrCount + rdn.Next(100, 999);
            }
            else
            {
                AccountId = "" +AccountNbrCount + rdn.Next(100, 999);
            }

            double MenuCh;
            MethodForAllClass M = new MessageLoanAccount();
            MenuCh = M.AskPositiveDoubleInput();

            Balance = MenuCh;

            yearTermChoice();

            AccountNbrCount++;

            TransactionMenuAdd("Type", "Description", "Amount", "Balance Before", "Balance After");
        }

        public LoanAccount()
        {

        }
        public void yearTermChoice()
        {
            int MenuCh;
            MethodForAllClass M = new MessageLoanAcc2();
            MenuCh = M.AskIntInput(1,2);

            int _yearTerm = MenuCh;

            if (_yearTerm == 1)
            {
                yearTerm = 2;
                interestRate = "2.8";
            }
            else if (_yearTerm == 2)
            {
                yearTerm = 5;
                interestRate = "4.7";
            }
            else
            {
                Console.WriteLine("Sorry you enter the wrong number");
                //int MenuCh1;
                //MethodForAllClass M1 = new MessageLoanAcc2();
                //MenuCh1 = M1.AskIntInput();
                yearTermChoice();
            }
        }

        public override void displayAccountMenu()
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.WriteLine("" + uniform("No", 5) + " | " + "" + uniform("Account Type :", 20) 
                + " | " + uniform("Account Number :", 20) + " | " + uniform("Balance :", 15) 
                + " | " + uniform("Loan Term :", 15) + " | " + uniform("Monthly Payment :", 20) + " | " + "" + uniform("Open Date :", 15));
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
        }

        public override void displayAccount()
        {
            if (yearTerm == 1)
            {
                Console.Write("" + uniform("" + AccountNumber, 5) + " | " + "" + uniform(AccountType, 20) 
                    +   " | " + uniform(AccountId, 20) + " | " + uniform("" + Math.Round(Balance, 2), 15) 
                    + " | " + uniform("" + yearTerm + " Years", 15) + " | " 
                    + uniform(""+ calculateMonthlyPayment(Balance, yearTerm, Convert.ToDouble(interestRate)), 20) + " | " + uniform("" + openDate.ToString("MM/dd/yy"), 15));
            }
            else
            {
                Console.Write("" + uniform("" + AccountNumber, 5) + " | " + "" + uniform(AccountType, 20)
                    + " | " + uniform(AccountId, 20) + " | " + uniform("" + Math.Round(Balance, 2), 15) + " | " + uniform("" + yearTerm + " Years", 15)
                    + " | " + uniform("" + calculateMonthlyPayment(Balance, yearTerm, Convert.ToDouble(interestRate)), 20) + " | " + uniform("" + openDate.ToString("MM/dd/yy"), 15));
            }
            Console.WriteLine("");
        }

        public static double calculateMonthlyPayment(double loanAmount, int termInYears, double interestRate)
        {

            // Convert interest rate into a decimal
            // eg. 6.5% = 0.065

            interestRate /= 100.0;

            // Monthly interest rate 
            // is the yearly rate divided by 12

            double monthlyRate = interestRate / 12.0;

            // The length of the term in months 
            // is the number of years times 12

            int termInMonths = termInYears * 12;

            // Calculate the monthly payment
            // Typically this formula is provided so 
            // we won't go into the details

            // The Math.pow() method is used calculate values raised to a power
            double monthlyPayment =
               (loanAmount * monthlyRate) /
                  (1 - Math.Pow(1 + monthlyRate, -termInMonths));

            return monthlyPayment;
        }

        //public new void Message()
        //{
        //    Console.WriteLine("");
        //    Console.WriteLine("Open new Loan");
        //    Console.WriteLine("------------------------------"); 
        //    Console.WriteLine("Please enter the Loan Amount");
        //    Console.WriteLine("");
        //}
    }
}
