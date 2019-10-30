using System;
using System.Collections.Generic;
using System.Text;

namespace Project0_EktivaBankApp
{
    abstract class RegistrationLogin : MethodForAllClass, InterfaceMessage
    {
        public static List<Customer> ListOfCustomers;
        
        public static int LastCustomerId = 1;

        public abstract void FirstAction();

        public void Message()
        {

        }

    }
}
