using System;
using System.Collections.Generic;
using System.Text;

namespace Project0_EktivaBankApp
{
    abstract class Action : MethodForAllClass, InterfaceMessage
    {
        public Customer currentCust;
        public int Choice;

        public virtual void actionChoice1()
        {

        }

        public virtual void logOut()
        {
            Console.WriteLine("You've been succefully Log Out " + currentCust.FirstName);
            Console.WriteLine("");
            currentCust = null;
            Welcome w = new Welcome();
            w.Begin();
        }

        public virtual void validation()
        {
            Console.WriteLine("1. Ok ");
            Console.WriteLine("2. Cancel");
        }

        public void menuActionNext()
        {
            int MenuCh;
            MethodForAllClass M = new AnytimeAction();
            MenuCh = M.AskIntInput(1,2);

            AnytimeAction AnyT;
            AnyT = new AnytimeAction(currentCust, MenuCh);
            AnyT.actionChoice1();

        }

        public void closeAccount(Customer currentCust)
        {
            if (currentCust.RegularAccountList.Count <= 0 && currentCust.LoanAccountList.Count <= 0 && currentCust.TermDepAccountList.Count <= 0)
            {
                Console.WriteLine("You dont have any account");
            }
            Console.WriteLine("Choose the No of the Account you want to Close");
            currentCust.displayAllAccountList();

            string input = Console.ReadLine();
            int i;
            int accLght = currentCust.TermDepAccountList.Count + currentCust.LoanAccountList.Count + currentCust.RegularAccountList.Count;

            while (!Int32.TryParse(input, out i) || 1 > Convert.ToInt32(input) || Convert.ToInt32(input) > accLght)
            {
                Console.WriteLine(" ");
                Console.WriteLine("--- > Invalid input. Please try again");
                Console.WriteLine("Choose the No of the Account you want to Close");
                currentCust.displayAllAccountList();
                input = Console.ReadLine();
            }
            int trans = Convert.ToInt32(input);

            foreach (var acc in currentCust.RegularAccountList)
            {
                if (acc.AccountNumber == trans)
                {
                    if (acc.Balance > 0)
                    {
                        Console.WriteLine("Your Balance is positive: "+acc.Balance + ("Please Withraw the money before close the Account"));
                        Console.WriteLine("");
                        Console.WriteLine("1. Withdraw ");
                        Console.WriteLine("2. Cancel");
                        Console.WriteLine("");

                        string inputClose = Console.ReadLine();
                        //int k;

                        //while (!Int32.TryParse(inputClose, out k) || 1 > Convert.ToInt32(Console.ReadLine()) || Convert.ToInt32(Console.ReadLine()) > 2)
                        //{
                        //    Console.WriteLine(" ");
                        //    Console.WriteLine("--- > Invalid input. Please try again");
                        //    Console.WriteLine(" ");
                        //    Console.WriteLine("" + currentCust.FirstName + "Please chose 1 to Withdraw the money before closing account or 2 to Cancel");
                        //    Console.WriteLine("1. Withdraw ");
                        //    Console.WriteLine("2. Cancel");
                        //    inputClose = Console.ReadLine();
                        //}

                        int valid = Convert.ToInt32(inputClose);
                        Console.WriteLine("I AM HERE!!!!" + valid);
                        if (valid == 1)
                        {
                            Console.WriteLine("--- > you withdraw "+ acc.Balance + "From your Account");
                            currentCust.RegularAccountList.Remove(acc);
                            Console.WriteLine("Your account was suscefully close");
                            Console.WriteLine("");
                            currentCust.displayCustomer();
                            currentCust.displayAllAccountList();
                            menuActionNext();
                        }
                        else if (valid == 2)
                        {
                            menuActionNext();
                        }
                    } else if (acc.AccountType == "Business Account")
                    {
                        Console.WriteLine("This Account have negative value: " + acc.Balance + ("Please pay the negative balance before close the Account"));
                        Console.WriteLine("");
                        Console.WriteLine("1. Pay ");
                        Console.WriteLine("2. Cancel");

                        string inputClose = Console.ReadLine();
                        int k;

                        while (!Int32.TryParse(inputClose, out k) || 1 > Convert.ToInt32(Console.ReadLine()) || Convert.ToInt32(Console.ReadLine()) > 2)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("--- > Invalid input. Please try again");
                            Console.WriteLine(" ");
                            Console.WriteLine("" + currentCust.FirstName + "Please chose 1 to Withdraw the money before closing account or 2 to Cancel");
                            Console.WriteLine("1. Pay ");
                            Console.WriteLine("2. Cancel");
                            inputClose = Console.ReadLine();
                        }

                        int valid = Convert.ToInt32(inputClose);

                        if (valid == 1)
                        {
                            Console.WriteLine("--- > you pay  " + acc.Balance + "as a remaining balance");
                            currentCust.RegularAccountList.Remove(acc);
                            Console.WriteLine("Your account was suscefully close");
                            Console.WriteLine("");
                            currentCust.displayCustomer();
                            currentCust.displayAllAccountList();
                            menuActionNext();
                        }
                        else if (valid == 2)
                        {
                            menuActionNext();
                        }
                    }
                    currentCust.RegularAccountList.Remove(acc);
                    Console.WriteLine("Your account was suscefully close");
                    Console.WriteLine("");
                    currentCust.displayCustomer();
                    currentCust.displayAllAccountList();
                    menuActionNext();
                }
            }

            foreach (var acc in currentCust.LoanAccountList)
            {
                if (acc.AccountNumber == trans)
                {
                    if (acc.Balance > 0)
                    {
                        Console.WriteLine("The balance is"+ acc.Balance);
                        Console.WriteLine("You need to pay off the loan before close the account");
                        Console.WriteLine("");
                        Console.WriteLine("1. Pay ");
                        Console.WriteLine("2. Cancel");

                        string inputClose = Console.ReadLine();
                        int k;

                        while (!Int32.TryParse(inputClose, out k) || 1 > Convert.ToInt32(Console.ReadLine()) || Convert.ToInt32(Console.ReadLine()) > 2)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("--- > Invalid input. Please try again");
                            Console.WriteLine(" ");
                            Console.WriteLine("" + currentCust.FirstName + "Please chose 1 to Withdraw the money before closing account or 2 to Cancel");
                            Console.WriteLine("1. Pay ");
                            Console.WriteLine("2. Cancel");
                            inputClose = Console.ReadLine();
                        }

                        int valid = Convert.ToInt32(inputClose);

                        if (valid == 1)
                        {
                            Console.WriteLine("--- > you pay  off your loan ");
                            currentCust.LoanAccountList.Remove(acc);
                            Console.WriteLine("Your account was suscefully close");
                            Console.WriteLine("");
                            currentCust.displayCustomer();
                            currentCust.displayAllAccountList();
                            menuActionNext();
                        }
                        else if (valid == 2)
                        {
                            menuActionNext();
                        }
                    }
                   
                    currentCust.LoanAccountList.Remove(acc);
                    Console.WriteLine("Your account was suscefully close");
                    Console.WriteLine("");
                    currentCust.displayCustomer();
                    currentCust.displayAllAccountList();
                    menuActionNext();
                }
            }

            foreach (var acc in currentCust.TermDepAccountList)
            {
                if (acc.AccountNumber == trans)
                {
                    if(acc.yearTerm < DateTime.Now.Year-acc.openDate.Year)
                    {
                        Console.WriteLine("Sorry the Term deposit is not mature, you can not close");
                        Console.WriteLine("");
                        currentCust.displayCustomer();
                        currentCust.displayAllAccountList();
                        menuActionNext();
                    }
                    currentCust.TermDepAccountList.Remove(acc);
                    Console.WriteLine("Your account was suscefully close");
                    Console.WriteLine("");
                    currentCust.displayCustomer();
                    currentCust.displayAllAccountList();
                    menuActionNext();
                }
            }
            currentCust.displayCustomer();
            currentCust.displayAllAccountList();

            
        }

        public abstract void Message();

       
    }
}
