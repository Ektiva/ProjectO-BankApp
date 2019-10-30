using System;
using System.Collections.Generic;
using System.Text;

namespace Project0_EktivaBankApp
{
    class Login : RegistrationLogin
    {
        public override void FirstAction()
        {

            if (ListOfCustomers != null)
            {
                Customer custLogin = new Customer();

                Console.WriteLine("Login :");

                Console.WriteLine(" ");
                Console.WriteLine("Please Enter your Id :");
                custLogin.Id = Console.ReadLine();

                Console.WriteLine(" ");
                Console.WriteLine("Please Enter your Password :");
                custLogin.Password = Console.ReadLine();

                foreach (Customer customer in ListOfCustomers)
                {
                    if (custLogin.Id == customer.Id && custLogin.Password == customer.Password)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--- Welcome " + customer.FirstName + " ---"); Console.ResetColor();
                        Console.WriteLine("");

                        customer.displayCustomer();

                        int MenuCh;
                        MethodForAllClass M = new MenuChoiceeeeeee();
                        MenuCh = M.AskIntInput(1,7);

                        MenuAction MenA = new MenuAction(customer, MenuCh);
                        MenA.actionChoice1();
                    }                   

                }
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Sorry The information you entered does not match our records"); Console.ResetColor();
                Console.WriteLine("");
                    Welcome w = new Welcome();
                    w.Begin();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Sorry The list of Customer is empty, Please Register"); Console.ResetColor();
                Welcome w = new Welcome();
                w.Begin();
            }
        }
    }
}
