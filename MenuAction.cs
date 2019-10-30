using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0_EktivaBankApp
{
    class MenuAction : Action
    {
        
        public Accounts Acc = new Accounts();

        #region Transitional variables
        public int validFrom;

        public int validTo;

        public int validWithdraw;

        public double validAmountWithdraw;

        public double validAmountDeposit;

        public int validCreatAcc;

        public int validAccounDep;
        #endregion 
        public MenuAction(Customer _currentCust, int _Choice)
        {
            currentCust = _currentCust;
            Choice = _Choice;
        }
        /// <summary>
        /// Main Menu
        /// </summary>

        #region Methods for the main menu
        public override void actionChoice1()
        {
            switch (Choice)
            {
                case 1: //Open new Account
                    openNewAccount();
                    break;

                case 2: //Display Account list
                    displayAccountList();
                    break;

                case 3: //Make a transfer
                    withinAccountTransfer();
                    break;

                case 4: //Deposit
                    Deposit();
                    break;

                case 5: //Withdraw
                    Withdraw();
                    break;


                case 6: //Pay a loan installment
                    payLoan();
                    break;

                case 7: //Log Out
                    logOut();
                    break;

                default:
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("--- > Sorry you enter the wrong number, Please chose one number on the list"); Console.ResetColor();
                    currentCust.displayCustomer();
                    int MenuCh;
                    MethodForAllClass M = new MenuChoiceeeeeee();
                    MenuCh = M.AskIntInput(1,7);

                    MenuAction MenA = new MenuAction(currentCust, MenuCh);
                    MenA.actionChoice1();

                    break;
            }
        }
        public void openNewAccount()
        {
            AskIntInputAccCreat(1, 5);
            if (validCreatAcc ==5)
            {
                menuActionNext();
            }
            actionChNewAcc(validCreatAcc);

            if (Acc.AccountType == "Checking Account" || Acc.AccountType == "Business Account")
            {
                currentCust.RegularAccountList.Add(Acc);
            } 
            else if (Acc.AccountType == "Loan")
            {
                currentCust.LoanAccountList.Add(Acc);
            }
            else
            {
                currentCust.TermDepAccountList.Add(Acc);
            }
            new CreateNewAccounttt(currentCust).DisplayAccountCrea_Next(Acc);
            menuActionNext();
        }

        public void actionChNewAcc(int Ch)
        {

            switch (Ch)
            {
                case 1: //Checking Account

                    RegularAccount NewCheckAccB = new RegularAccount();
                    double Bal = NewCheckAccB.actionChoice();

                    RegularAccount NewCheckAcc = new RegularAccount(currentCust, "Checking Account", Bal);
                    Acc = NewCheckAcc;
                    break;

                case 2: //Business Account
                    RegularAccount NewBusAccB = new RegularAccount();
                    double Bal1 = NewBusAccB.actionChoice();

                    RegularAccount NewBusAcc = new RegularAccount(currentCust, "Business Account", Bal1);
                    Acc = NewBusAcc;
                    break;

                case 3: //Loan 
                    LoanAccount NewLoaAcc = new LoanAccount(currentCust);
                    Acc = NewLoaAcc;
                    break;

                case 4: //Term Deposit 
                    TermDepositAccount NewTDAcc = new TermDepositAccount(currentCust);
                    Acc = NewTDAcc;
                    break;

                case 5: //Term Deposit 
                    currentCust.displayCustomer();
                    int Menu;
                    MethodForAllClass Mc = new MenuChoiceeeeeee();
                    Menu = Mc.AskIntInput(1, 7);
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("---- > Sorry you choose the wromg number"); Console.ResetColor();
                    int MenuCh;
                    MethodForAllClass M = new CreateNewAccountMess();
                    MenuCh = M.AskIntInput(1, 4);

                    actionChNewAcc(MenuCh);
                    break;
            }

        }
       
        public void displayAccountList()
        {
            currentCust.displayCustomer();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.Write("Menu --->  "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Display Account List "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();
            currentCust.displayAllAccountList();

            int MenuCh;
            MethodForAllClass Msx = new DisplayAccListAction();
            MenuCh = Msx.AskIntInput(1,5);


            DisplayAccListAction M = new DisplayAccListAction(currentCust, MenuCh);
            M.actionChoice1();

            menuActionNext();
        }

        public void withinAccountTransfer()
        {
            double amount = new double();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.Write("Menu --->  "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Make a Transfer "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();

            if (currentCust.RegularAccountList.Count > 1)
            {
                AskIntInputFrom(1, currentCust.RegularAccountList.Count);

                AskIntInputTo(1, currentCust.RegularAccountList.Count);
                #region Amount
                Console.WriteLine("Amount :");
                Console.WriteLine(" ");
                string inputAmount = Console.ReadLine();
                double b;

                while (!Double.TryParse(inputAmount, out b) || Convert.ToDouble(inputAmount)<0)
                {
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("--- > Invalid input. Please try again"); Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Please enter the amount :");
                    inputAmount = Console.ReadLine();
                }
                amount = Convert.ToDouble(inputAmount);
                #endregion


                foreach (var accFrom in currentCust.RegularAccountList)
                {
                    if (accFrom.AccountType == "Checking Account" && accFrom.Balance < amount)
                    {
                        Console.WriteLine(" ");
                        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Sorry, The Balance is less than the amount to transfer and you can't overdraw a Checking Account "); Console.ResetColor();
                        menuActionNext();
                    } else
                    {
                        if (validFrom == accFrom.AccountNumber)
                            foreach (var accTo in currentCust.RegularAccountList)
                            {
                                if (validTo == accTo.AccountNumber)
                                {
                                    int valid;
                                    MethodForAllClass M = new MessageValidation();
                                    valid = M.AskIntInput(1, 2);

                                    if (valid == 1)
                                    {
                                        double balBeforeFr = accFrom.Balance;
                                        accFrom.withdraw(amount);
                                        accFrom.TransactionMenuAdd("Tranfer", "To Account " + accFrom.AccountId, "-" + amount, "" + balBeforeFr, " " + accFrom.Balance);

                                        double balBeforeTo = accTo.Balance;
                                        accTo.deposit(amount);
                                        accTo.TransactionMenuAdd("Tranfer", "From Account " + accTo.AccountId, "+" + amount, "" + balBeforeTo, " " + accTo.Balance);

                                        Console.WriteLine(" ");
                                        Console.ForegroundColor = ConsoleColor.Green; Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("---- > Congratulation" + currentCust.FirstName + ", your transfer was succesfully done!!"); Console.ResetColor();
                                        Console.WriteLine(" ");

                                        currentCust.displayRegAccCustAccountList();
                                        menuActionNext();
                                    }
                                    else if (valid == 2)
                                    {
                                        Console.WriteLine("Transaction was cancel");
                                        menuActionNext();
                                    }

                                }
                            }
                        {

                        }
                    }
                    
                }                
            }
            else
            {
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("---- > Sorry, You have No or not enough own account to make Transfer" ); Console.ResetColor();
                Console.WriteLine(" ");
                menuActionNext();
            }

                
        }

        public void Withdraw()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.Write("Menu --->  "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Withdraw "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();

            int lenht = currentCust.RegularAccountList.Count + currentCust.TermDepAccountList.Count + currentCust.LoanAccountList.Count;
            AskIntInputWithdraw(1, lenht);

            foreach (var accWithdraw in currentCust.RegularAccountList)
            {
                //AskAmountWithdraw();
                if (validWithdraw == accWithdraw.AccountNumber)
                {
                    AskAmountWithdraw();
                    if (accWithdraw.AccountType == "Business Account")
                    {
                        if (accWithdraw.Balance < validAmountWithdraw)
                        {
                            Console.WriteLine("---- > This is a Business Account, the balance is less than the amount");
                            Console.WriteLine("");
                            Console.WriteLine("Your account will be Overdraft wiith 5% of interest for the remaining "+ (validAmountWithdraw - accWithdraw.Balance));
                            double balBefore = accWithdraw.Balance;
                            accWithdraw.withdraw(validAmountWithdraw);
                            accWithdraw.TransactionMenuAdd("Withdraw", "To external", "-" + validAmountWithdraw, "" + balBefore, " " + accWithdraw.Balance);
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("---- > Congratulation" + currentCust.FirstName + ", your withdraw was succesfully done!!"); Console.ResetColor();
                            Console.WriteLine(" ");
                        }
                        else if (validAmountWithdraw < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("---- > Sorry" + currentCust.FirstName + ", The amount is negative, Please try again"); Console.ResetColor();
                            Console.WriteLine(" ");
                        }
                        else
                        {
                            double balBefore = accWithdraw.Balance;
                            accWithdraw.withdraw(validAmountWithdraw);
                            accWithdraw.TransactionMenuAdd("Withdraw", "To external", "-" + validAmountWithdraw, "" + balBefore, " " + accWithdraw.Balance);
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("---- > Congratulation" + currentCust.FirstName + ", your withdraw was succesfully done!!"); Console.ResetColor();
                            Console.WriteLine(" ");
                        }
                    }
                    else
                    {
                        if (accWithdraw.Balance < validAmountWithdraw)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("---- > Sorry, This is a Checking Account, you can not Overdraft"); Console.ResetColor();
                            Console.WriteLine("");
                        }
                        else if (validAmountWithdraw < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("---- > Sorry" + currentCust.FirstName + ", The amount is negative, Please try again"); Console.ResetColor();
                            Console.WriteLine(" ");
                        }
                        else
                        {
                            double balBefore = accWithdraw.Balance;
                            accWithdraw.withdraw(validAmountWithdraw);
                            accWithdraw.TransactionMenuAdd("Withdraw", "To external", "-" + validAmountWithdraw, "" + balBefore, " " + accWithdraw.Balance);
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("---- > Congratulation" + currentCust.FirstName + ", your withdraw was succesfully done!!"); Console.ResetColor();
                            Console.WriteLine(" ");
                        }
                    }
                     
                }
            }

            foreach (var accWithdraw in currentCust.LoanAccountList)
            {
                if (validWithdraw == accWithdraw.AccountNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("---- > Sorry" + currentCust.FirstName + ", you can not Withdraw in a Loan Account, "); Console.ResetColor();
                    Console.WriteLine(" ");
                    menuActionNext();
                }
            }

            foreach (var accWithdraw in currentCust.TermDepAccountList)
            {
                if (validWithdraw == accWithdraw.AccountNumber)
                {
                    if (DateTime.Now.Year - accWithdraw.openDate.Year < accWithdraw.yearTerm)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;  Console.WriteLine("---- > Sorry, The Term Deposit is not yet at maturity, you can not Withdraw now"); Console.ResetColor();
                        Console.WriteLine("---- > You can Withdraw in " + (accWithdraw.yearTerm - DateTime.Now.Year + accWithdraw.openDate.Year) +" Years");
                        Console.WriteLine("");
                    }
                    else
                    {
                        AskAmountWithdraw();
                        if (accWithdraw.Balance < validAmountWithdraw)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("---- > Sorry, This is a Term Deposit, you can not Overdraft"); Console.ResetColor();
                            Console.WriteLine("");
                        }
                        else if (validAmountWithdraw < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("---- > Sorry" + currentCust.FirstName + ", The amount is negative, Please try again"); Console.ResetColor();
                            Console.WriteLine(" ");
                        }
                        else
                        {
                            double balBefore = accWithdraw.Balance;
                            accWithdraw.withdraw(validAmountWithdraw);
                            accWithdraw.TransactionMenuAdd("Withdraw", "To external", "-" + validAmountWithdraw, "" + balBefore, " " + accWithdraw.Balance);
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("---- > Congratulation" + currentCust.FirstName + ", your withdraw was succesfully done!!"); Console.ResetColor();
                            Console.WriteLine(" ");
                        }
                    }
                    
                }
            }
          currentCust.displayRegAccCustAccountList();
            menuActionNext();
        }

        public void Deposit()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.Write("Menu --->  "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Deposit "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();
            int n = currentCust.RegularAccountList.Count;
            AskIntInputAccDep(1,n);

            AskAmountDeposit();

            foreach (var accInto in currentCust.RegularAccountList)
            {
                if (validAccounDep == accInto.AccountNumber)
                    {
                            double balBefore = accInto.Balance;
                            accInto.deposit(validAmountDeposit);
                            accInto.TransactionMenuAdd("Deposit", "From external", "+" + validAmountDeposit, "" + balBefore, " " + accInto.Balance);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("---- > Congratulation" + currentCust.FirstName + ", your deposit was succesfully done!!"); Console.ResetColor();
            Console.WriteLine(" ");

            currentCust.displayRegAccCustAccountList();
            menuActionNext();
        }

        public void payLoan()
        {
            Console.WriteLine("Please Choose the Loan you want to pay");
            Console.WriteLine(" ");
            currentCust.displayLoanAccCustAccountList();
            int LoanAccPaid = Convert.ToInt32(Console.ReadLine());


            foreach (var acc in currentCust.LoanAccountList)
            {
                if (LoanAccPaid == acc.AccountNumber)
                {
                    Console.WriteLine("Choose the amount");
                    Console.WriteLine(" ");
                    Console.WriteLine("1. Monthly Payment :" +LoanAccount.calculateMonthlyPayment(acc.Balance, acc.yearTerm, Convert.ToDouble(acc.interestRate)));
                    Console.WriteLine("2. Paid Off :"+ acc.Balance);
                    //Console.WriteLine("3. Other Amount :");
                    int amountPaid = Convert.ToInt32(Console.ReadLine());
                    if (amountPaid == 1)
                    {
                        acc.withdraw(LoanAccount.calculateMonthlyPayment(acc.Balance, acc.yearTerm, Convert.ToDouble(acc.interestRate)));
                        currentCust.displayAllAccountList();
                        menuActionNext();
                    }
                    else if (amountPaid == 2)
                    {
                        acc.withdraw(acc.Balance);
                        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("---- > You paid Off your Loan, this Account is close"); Console.ResetColor();
                        Console.WriteLine(" ");
                        closeAccount(currentCust);
                        currentCust.displayAllAccountList();
                        menuActionNext();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("---- > Sorry you enter the wrong number"); Console.ResetColor();
                        Console.WriteLine(" ");
                        payLoan();
                        //menuActionNext();
                    }
                    //currentCust.displayLoanAccCustAccountList();
                }
            }
        }
        #endregion

        #region Intemedaite Methods
        public override void Message()
        {
       
        }

        public void AskIntInputFrom(int min, int max)
        {
            Console.WriteLine(" ");
            Console.WriteLine("From :");
            Console.WriteLine("Please Select the provider Account :");
            Console.WriteLine(" ");
            currentCust.displayRegAccCustAccountList();

            string input = Console.ReadLine();

            int i;

            while (!Int32.TryParse(input, out i) || min > Convert.ToInt32(input) || Convert.ToInt32(input) > max)
            {
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("--- > Invalid input. Please try again"); Console.ResetColor();
                Console.WriteLine(" ");
                Console.WriteLine("From :");
                Console.WriteLine("Please Select the provider Account :");
                Console.WriteLine(" ");
                currentCust.displayRegAccCustAccountList();
                input = Console.ReadLine();
            }
            validFrom = Convert.ToInt32(input);
        }
        public void AskIntInputAccDep(int min, int max)
        {
            Console.WriteLine(" ");
            Console.WriteLine("---> You can make a deposit only in regular account");
            Console.WriteLine("Please Select the account you want to make a deposit :");
            Console.WriteLine(" ");
            currentCust.displayRegAccCustAccountList();

            string input = Console.ReadLine();

            int i;

            while (!Int32.TryParse(input, out i) || min > Convert.ToInt32(input) || Convert.ToInt32(input) > max)
            {
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("--- > Invalid input. Please try again"); Console.ResetColor();
                Console.WriteLine(" ");
                Console.WriteLine("Select the account you want to make a deposit :");
                Console.WriteLine(" ");
                currentCust.displayRegAccCustAccountList();
                input = Console.ReadLine();
            }
            validAccounDep = Convert.ToInt32(input);
        }

        public void AskIntInputAccCreat(int min, int max)
        {

            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118)));
            Console.Write("Menu --->  "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("Open New Account "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(string.Concat(Enumerable.Repeat("-", 118))); Console.ResetColor();

            Console.WriteLine("1. Checking account ");
            Console.WriteLine("2. Business account ");
            Console.WriteLine("3. Loan");
            Console.WriteLine("4. Term Deposit");
            Console.WriteLine("5. Cancel");
            Console.WriteLine("");

            string input = Console.ReadLine();

            int i;

            while (!Int32.TryParse(input, out i) || min > Convert.ToInt32(input) || Convert.ToInt32(input) > max)
            {
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("--- > Invalid input. Please try again"); Console.ResetColor();
                Console.WriteLine("");
                //Console.WriteLine("Open New Account");
                //Console.WriteLine("----------------------");
                Console.WriteLine("1. Checking account ");
                Console.WriteLine("2. Business account ");
                Console.WriteLine("3. Loan");
                Console.WriteLine("4. Term Deposit");
                Console.WriteLine("5. Cancel");
                Console.WriteLine("");
                input = Console.ReadLine();
            }
            validCreatAcc = Convert.ToInt32(input);

        }
        
        public void AskIntInputWithdraw(int min, int max)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Select the Account :");
            Console.WriteLine(" ");
            currentCust.displayAllAccountList();

            string input = Console.ReadLine();

            int i;

            while (!Int32.TryParse(input, out i) || min > Convert.ToInt32(input) || Convert.ToInt32(input) > max)
            {
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("--- > Invalid input. Please try again"); Console.ResetColor();
                Console.WriteLine(" ");
                Console.WriteLine("Select the Account :");
                Console.WriteLine(" ");
                currentCust.displayAllAccountList();
                input = Console.ReadLine();
            }
            validWithdraw= Convert.ToInt32(input);
        }
        
        public void AskAmountWithdraw()
        {
            Console.WriteLine("Amount :");
            Console.WriteLine(" ");

            string inputAmount = Console.ReadLine();
            double b;
            while (!Double.TryParse(inputAmount, out b) || Convert.ToDouble(inputAmount)<0)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid input, Please Try Again"); Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("Please enter the amount :");

                inputAmount = Console.ReadLine();
            }
            validAmountWithdraw = Convert.ToDouble(inputAmount);
        }

        public void AskAmountDeposit()
        {
            Console.WriteLine("Amount :");
            Console.WriteLine(" ");

            string inputAmount = Console.ReadLine();
            double b;
            while (!Double.TryParse(inputAmount, out b) || Convert.ToDouble(inputAmount) < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid input, Please Try Again"); Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("Please enter the amount :");

                inputAmount = Console.ReadLine();
            }
            validAmountDeposit = Convert.ToDouble(inputAmount);
        }

        public void AskIntInputTo(int min, int max)
        {
            Console.WriteLine(" ");
            Console.WriteLine("To :");
            Console.WriteLine("Please Select the destination Account :");
            Console.WriteLine(" ");
            currentCust.partialDisplayCustAccountList(currentCust.RegularAccountList[validFrom - 1]);

            string input = Console.ReadLine();

            int i;

            while (!Int32.TryParse(input, out i) || min > Convert.ToInt32(input) || Convert.ToInt32(input) > max)
            {
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("--- > Invalid input. Please try again"); Console.ResetColor();
                Console.WriteLine(" ");
                Console.WriteLine("To :");
                Console.WriteLine("Please Select the destination Account :");
                Console.WriteLine(" ");
                currentCust.partialDisplayCustAccountList(currentCust.RegularAccountList[validFrom - 1]);
                input = Console.ReadLine();
            }
            validTo = Convert.ToInt32(input);

        }
        #endregion 

    }
}

