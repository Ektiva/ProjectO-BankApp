using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0_EktivaBankApp
{
    public class Customer : MethodForAllClass, InterfaceMessage
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => $"{FirstName + "-"}{LastName}";
        public string email { get; set; }
        public string Password { get; set; }

        #region List of Accounts
        public List<Accounts> RegularAccountList = new List<Accounts>();

        public List<Accounts> LoanAccountList = new List<Accounts>();

        public List<Accounts> TermDepAccountList = new List<Accounts>();
        #endregion
        public void displayRegAccCustAccountList()
        {           
            if (RegularAccountList.Count > 0)
            {
                new RegularAccount().displayAccountMenu();
                foreach (var acc in RegularAccountList)
                {
                    acc.displayAccount();
                }
            }  else Console.WriteLine("No Regular Account");
        }

        public void displayAllAccountList()
        {
            if (RegularAccountList.Count <= 0 && LoanAccountList.Count <= 0 && TermDepAccountList.Count <= 0)
            {
                Console.Write(" ");
                Console.Write("                     ----------No Actif Account----------");
                Console.Write(" ");             
            }
            else
            {
                new RegularAccount().displayAccMenu();
                if (RegularAccountList.Count > 0)
                {
                    foreach (var acc in RegularAccountList)
                    {
                        acc.displayAllAccount();
                    }
                }
                if (LoanAccountList.Count > 0)
                {
                    foreach (var acc in LoanAccountList)
                    {
                        acc.displayAllAccount();
                    }
                }
                if (TermDepAccountList.Count > 0)
                {
                    foreach (var acc in TermDepAccountList)
                    {
                        acc.displayAllAccount();
                    }
                }
            }
            
        }

        public void displayLoanAccCustAccountList()
        {
            if (LoanAccountList.Count > 0)
            {
                new LoanAccount().displayAccountMenu();
                foreach (var acc in LoanAccountList)
                {
                    acc.displayAccount();
                }
            }
            else Console.WriteLine("No Loan Account");

        }

        public void displayTerDepAccCustAccountList()
        {
            if (TermDepAccountList.Count > 0)
            {
                new TermDepositAccount().displayAccountMenu();
                foreach (var acc in TermDepAccountList)
                {
                    acc.displayAccount();
                }
            }                
            else Console.WriteLine("No Term Deposit Account");
        }

        public void partialDisplayCustAccountList(Accounts accDontDisplay)
        {
            new RegularAccount().displayAccountMenu();
            foreach (var acc in RegularAccountList)
            {
                if (acc != accDontDisplay)
                {
                    acc.displayAccount();
                }
            }
            Console.WriteLine("");
        }

        public void displayCustomer()
        {
            int NoAcc = RegularAccountList.Count + LoanAccountList.Count + TermDepAccountList.Count;
            Console.Write(string.Concat(Enumerable.Repeat("-", 45)));
            Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write(" EKTIVA BANKING APPLICATION "); Console.ResetColor();
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 45)));
            Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine("Name : " + uniform("" + Name, 28) + " | " + "Id : " + uniform("" + Id, 10) + " | " + "email : " + uniform("" + email, 18) + " | " + "Actifs Account : " + NoAcc); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();
        }

        public void Message()
        {

        }

        public static string uniform(string orig, int n)
        {
            try
            {
                while (orig.Length < n)
                {
                    for (int i = 0; i < (n - orig.Length); i++)
                    {
                        orig = orig + " ";
                    }
                }
            }
            catch
            {
                orig = orig + "     ";
            }

            return orig;
        }

        
    }
}
