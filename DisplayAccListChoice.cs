using System;
using System.Collections.Generic;
using System.Text;

namespace Project0_EktivaBankApp
{
    class DisplayAccListChoice : Action
    {
        public DisplayAccListChoice()
        {

        }
        public DisplayAccListChoice(Customer _currentCust)
        {
            currentCust = _currentCust;

        }

        public override void Message()
        {
            Console.WriteLine("");
            Console.WriteLine("1. Display Account transaction");
            Console.WriteLine("2. Close Account");
            Console.WriteLine("3. Menu");
            Console.WriteLine("4. Log Out");
        }
    }
}
