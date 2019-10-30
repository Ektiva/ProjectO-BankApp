using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0_EktivaBankApp
{
    public class Accounts : AccountInterface, MethodForAllClass, InterfaceMessage
    {
        //Suppose to be protected

        public Accounts()
        {

        }
        public double Balance { get; set; }

        public int AccountNumber { get; set; }

        public string AccountId { get; set; }

        public static int AccountNbrCount = 1;

        public string AccountType { get; set; }

        public virtual int yearTerm { get; set; }

        public DateTime openDate { get; set; }

        public void deposit(double amount)
        {
            Balance += amount;
        }
        public void withdraw(double amount)
        {
            if (amount > Balance)
            {
                Balance = -((amount - Balance) * 1.05);
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, "Withdraw amount is less than zero");
            }
            Balance -= amount;
        }

        public void TransactionMenuAdd(string Type, string Description, string amount, string balBefore, string balAfter)
        {
            string[] TransMenu = new string[5];
            TransMenu[0] = ""+Type;
            TransMenu[1] = ""+ Description;
            TransMenu[2] = ""+amount;
            TransMenu[3] = ""+balBefore;
            TransMenu[4] = ""+balAfter;
            ListAccTransaction.Add(TransMenu);
        }

        public List<string[]> ListAccTransaction = new List<string[]>();


       

        public virtual string interestRate { get; set; }

        public virtual void displayAccount()
        {
            Console.Write("" + uniform("" + AccountNumber, 5) + " | " + "" + uniform(AccountType, 20) 
                + " | " + uniform(AccountId, 20) + " | " + uniform("" + Math.Round(Balance, 2), 15) + " | " + uniform("" + openDate.ToString("MM/dd/yy"), 15));
            Console.WriteLine("");
        }

        public virtual void displayAllAccount()
        {
            Console.Write("" + uniform("" + AccountNumber, 5) + " | " + "" + uniform(AccountType, 20)
                + " | " + uniform(AccountId, 20) + " | " + uniform("" + Math.Round(Balance, 2), 15) + " | " + uniform("" + openDate.ToString("MM/dd/yy"), 15));
            Console.WriteLine("");
        }

        public virtual void displayAccountMenu()
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.WriteLine("" + uniform("No", 5) + " | " + "" + uniform("Account Type :", 20)
                + " | " + uniform("Account Number :", 20) + " | " + uniform("Balance :", 15)
                + " | " + "" + uniform("Interest Rate :", 15) + " | " + "" + uniform("Open Date :", 15));
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
        }

        public virtual void displayAccMenu()
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.WriteLine("" + uniform("No", 5) + " | " + "" + uniform("Account Type :", 20)
                + " | " + uniform("Account Number :", 20) + " | " + uniform("Balance :", 15)
                + " | " + "" + uniform("Open Date :", 15));
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
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

        public void Message()
        {
            Console.WriteLine("");
            Console.WriteLine("Open new " + AccountType);
            Console.WriteLine("------------------------------");
            Console.WriteLine("Please enter the Initial Balance");
            Console.WriteLine("");
        }
    }
}
