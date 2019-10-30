using System;
using System.Collections.Generic;
using System.Text;

namespace Project0_EktivaBankApp
{
    interface AccountInterface
    {
        public void deposit(double amount);

        public void withdraw(double amount);

        public void displayAccount();

        public void displayAccountMenu();



    }
}
