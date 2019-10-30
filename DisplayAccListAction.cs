using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0_EktivaBankApp
{
    class DisplayAccListAction : Action
    {
        //public int validTrans;
        public DisplayAccListAction()
        {

        }
        public DisplayAccListAction(Customer _currentCust, int _Choice)
        {
            currentCust = _currentCust;
            Choice = _Choice;
        }

        public override void actionChoice1()
        {
            if (Choice == 1)
            {
                DisplayMoreInfo();

            }else if (Choice == 2)
            {
                DisplayAccTransation();

            }
            else if (Choice == 3)
            {
                closeAccount(currentCust);
            }
            else if (Choice == 4)
            {
                currentCust.displayCustomer();
                int MenuCh;
                MethodForAllClass Msx = new MenuChoiceeeeeee();
                MenuCh = Msx.AskIntInput(1,7);

                MenuAction M = new MenuAction(currentCust, MenuCh);
                M.actionChoice1();
            }
            else if (Choice == 5)
            {
                logOut();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Sorry you choose a wrong number "); Console.ResetColor();
                Console.WriteLine("");
                actionChoice1();
            }
        }

        public override void Message()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine("Sub-Menu"); Console.ResetColor();
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 40)));
            Console.WriteLine("1. More info for an Account");
            Console.WriteLine("2. Display Account transaction");
            Console.WriteLine("3. Close Account");
            Console.WriteLine("4. Menu");
            Console.WriteLine("5. Log Out");
        }

        public void DisplayAccTransation()
        {
            int lenght = currentCust.RegularAccountList.Count + currentCust.TermDepAccountList.Count + currentCust.LoanAccountList.Count;

            int MenuCh;
            MethodForAllClass Msx = new MessageDispTransaction();
            MenuCh = Msx.AskIntInput(1, lenght, currentCust);

            currentCust.displayCustomer();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.Write("Menu --->  Display My Account List ---> "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Display Account Transaction "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();

            foreach (var acc in currentCust.LoanAccountList)
                {
                    if (acc.AccountNumber == MenuCh)
                    {
                        if (acc.ListAccTransaction.Count <= 1)
                        {
                        Console.WriteLine("");
                        Console.WriteLine("     ---No transaction on this account---");
                    } else {
                                Console.WriteLine(string.Concat(Enumerable.Repeat("-", 114)));
                                for (int i = 0; i < 5; i++)
                                {
                                    Console.Write("" + Accounts.uniform("" + acc.ListAccTransaction[0][i], 20) + "|");
                                }
                                Console.WriteLine(string.Concat(Enumerable.Repeat("-", 114)));
                                //Console.WriteLine("");
                                foreach (var a in acc.ListAccTransaction)
                                    {
                                        if(a != acc.ListAccTransaction[0])
                                        {
                                            for (int i = 0; i < 5; i++)
                                            {
                                                Console.Write("" + Accounts.uniform("" + a[i], 20) + "|");
                                            }
                                            Console.WriteLine("");
                                        }
                                        Console.WriteLine("");
                                }
                                        
                          }
                        
                    }
                }

                foreach (var acc in currentCust.TermDepAccountList)
                {
                    if (acc.AccountNumber == MenuCh)
                    {
                        if (acc.ListAccTransaction.Count <= 1)
                        {
                        Console.WriteLine("");
                        Console.WriteLine("     ---No transaction on this account---");
                    } 
                    else
                        {

                        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 114)));
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write("" + Accounts.uniform("" + acc.ListAccTransaction[0][i], 20) + "|");
                        }
                        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 114)));

                        foreach (var a in acc.ListAccTransaction)
                            {
                                if (a != acc.ListAccTransaction[0])
                                {
                                for (int i = 0; i < 5; i++)
                                {
                                    Console.Write("" + Accounts.uniform("" + a[i], 20) + "|");
                                }
                                Console.WriteLine("");
                            }
                            Console.WriteLine("");
                        }
                                
                        }
                    }
                }

                foreach (var acc in currentCust.RegularAccountList)
                {
                if (acc.AccountNumber == MenuCh)
                {
                    if (acc.ListAccTransaction.Count <= 1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("     ---No transaction on this account---");
                    }
                    else
                    {

                        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 114)));
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write("" + Accounts.uniform("" + acc.ListAccTransaction[0][i], 20) + "|");
                        }
                        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 114)));

                        foreach (var a in acc.ListAccTransaction)
                        {
                            if (a != acc.ListAccTransaction[0])
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    Console.Write("" + Accounts.uniform("" + a[i], 20) + "|");
                                }
                                Console.WriteLine("");
                            }
                            Console.WriteLine("");
                        }

                    }
                }
            }
            
           

            menuActionNext();

        }


        public void DisplayMoreInfo()
        {
            int lenght = currentCust.RegularAccountList.Count + currentCust.TermDepAccountList.Count + currentCust.LoanAccountList.Count;

            int MenuCh;
            MethodForAllClass Msx = new MessageDisplayMoreInfo();
            MenuCh = Msx.AskIntInput(1, lenght, currentCust);

            currentCust.displayCustomer();

            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.Write("Menu --->  Display My Account List ---> "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("More Information "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();

            foreach (var acc in currentCust.LoanAccountList)
            {
                if (acc.AccountNumber == MenuCh)
                {
                    currentCust.displayLoanAccCustAccountList();
                }
            }

            foreach (var acc in currentCust.TermDepAccountList)
            {
                if (acc.AccountNumber == MenuCh)
                {
                    currentCust.displayTerDepAccCustAccountList();
                }
            }

            foreach (var acc in currentCust.RegularAccountList)
            {
                if (acc.AccountNumber == MenuCh)
                {
                    currentCust.displayRegAccCustAccountList();
                }
            }
            menuActionNext();

        }
    }
}
