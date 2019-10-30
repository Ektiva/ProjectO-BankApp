using System;
using System.Collections.Generic;
using System.Text;

namespace Project0_EktivaBankApp
{
    interface InterfaceMessage
    {
        public abstract void Message();
        public virtual void Message(Customer c) { }

    }
}
