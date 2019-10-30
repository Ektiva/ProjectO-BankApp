using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0_EktivaBankApp
{
    class Registration : RegistrationLogin
    {
        public override void FirstAction()
        {
#region
            Customer custReg = new Customer();

            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine("Registration "); 
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 30))); Console.ResetColor();
            //Console.WriteLine(" ");

            Console.WriteLine("Please Enter your First Name :");
            custReg.FirstName = Console.ReadLine();
            Console.WriteLine(" ");

            Console.WriteLine("Please Enter your Last Name :");
            custReg.LastName = Console.ReadLine();
            Console.WriteLine(" ");

            Console.WriteLine("Please Enter your email:");
            custReg.email = Console.ReadLine();
            Console.WriteLine(" ");

            Console.WriteLine("Please Enter your Password :");
            custReg.Password = Console.ReadLine();
            Console.WriteLine(" ");

            custReg.Id = "" + custReg.FirstName[0] + "" + custReg.LastName[0] + "" + LastCustomerId;
            #endregion

            if (ListOfCustomers != null)
            {
                foreach (var ExistCust in ListOfCustomers)
                {
                    if (custReg.email == ExistCust.email)
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("---- > Sorry this Customer already exist "); Console.ResetColor();
                        Console.WriteLine("");
                        Welcome w = new Welcome();
                        w.Begin();
                    }
                } 
                    LastCustomerId++;
                    ListOfCustomers.Add(custReg);

                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("-------> Welcome " + custReg.FirstName); Console.ResetColor();
                    Console.WriteLine("");
                    custReg.displayCustomer();

                    int MenuCh;
                    MethodForAllClass M = new MenuWelcome();
                    MenuCh = M.AskIntInput(1,2);

                    if (MenuCh == 1)
                    {
                        custReg.displayCustomer();
                        Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 115)));
                        Console.Write("Menu --->  "); Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Open New Account "); Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 115))); Console.ResetColor();
                        MenuAction MenA = new MenuAction(custReg, 1);
                        MenA.actionChoice1();
                    }
                    else if (MenuCh == 2)
                    {
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("You've been succefully Log Out " + custReg.FirstName); Console.ResetColor();
                    Console.WriteLine("");
                        custReg = null;
                        Welcome w = new Welcome();
                        w.Begin();
                    }

            } 
            else
            {
                LastCustomerId++;

                ListOfCustomers = new List<Customer>();
                ListOfCustomers.Add(custReg);

                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("-------> Welcome " + custReg.FirstName); Console.ResetColor();
                Console.WriteLine("");

                custReg.displayCustomer();

                int MenuCh;
                MethodForAllClass M = new MenuWelcome();
                MenuCh = M.AskIntInput(1,2);
                if (MenuCh == 1)
                {
                    custReg.displayCustomer();
                    //Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
                    //Console.Write("Menu --->  "); Console.ResetColor();
                    //Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Open New Account "); Console.ResetColor();
                    //Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();

                    MenuAction MenA = new MenuAction(custReg, 1);
                    MenA.actionChoice1();
                }
                else if(MenuCh == 2) {
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("You've been succefully Log Out " + custReg.FirstName); Console.ResetColor();
                    Console.WriteLine("");
                    custReg = null;
                    Welcome w = new Welcome();
                    w.Begin();
                }

            }

        }
    }
}
