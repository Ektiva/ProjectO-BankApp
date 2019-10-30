using System;
using System.Collections.Generic;
using System.Text;

namespace Project0_EktivaBankApp
{
    class AnytimeAction : Action
    {
        public AnytimeAction()
        {
        }
        public AnytimeAction(Customer _currentCust, int _Choice)
        {
            currentCust = _currentCust;
            Choice = _Choice;
        }

        public override void actionChoice1()
        {

            if (Choice == 1)
            {
                currentCust.displayCustomer();
                int MenuCh;
                MethodForAllClass M = new MenuChoiceeeeeee();
                MenuCh = M.AskIntInput(1,7);

                MenuAction MenA = new MenuAction(currentCust, MenuCh);
                MenA.actionChoice1();
            }
            else if (Choice == 2)
            {
                logOut();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Sorry you choose a wrong number, Please Try again "); Console.ResetColor();
                Console.WriteLine("");

                currentCust.displayCustomer();
                int MenuCh;
                MethodForAllClass M = new AnytimeAction();
                MenuCh = M.AskIntInput(1,2);

                AnytimeAction AnyT;
                AnyT = new AnytimeAction(currentCust, MenuCh);
                AnyT.actionChoice1();
            }
        }

        public override void Message()
        {
            Console.WriteLine("");
            Console.WriteLine("1. Menu");
            Console.WriteLine("2. Log Out");
            Console.WriteLine("");
        }
    }
}
