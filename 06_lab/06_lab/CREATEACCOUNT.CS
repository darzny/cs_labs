using System;

namespace bankAccounts
{
    enum AccountType
    {
        Checking,
        Deposit
    }

    class BankAccount
    {
        private long accNo;
        private decimal accBal;
        private AccountType accType;
        private static long nextAccNo;

        public void Populate(decimal balance)
        {
            accNo = NextNumber();
            accBal = balance;
            accType = AccountType.Checking;
        }

        public decimal Deposit(decimal amount)
        {
            accBal += amount;
            return accBal;
        }

        public bool Withdraw(decimal amount)
        {
            bool sufficientFunds = accBal >= amount;

            if (sufficientFunds)
            {
                accBal -= amount;
            }

            return sufficientFunds;
        }

        public long GetNumber()
        {
            return accNo;
        }

        public decimal GetBalance()
        {
            return accBal;
        }

        public AccountType GetAccountType()
        {
            return accType;
        }

        private static long NextNumber()
        {
            return nextAccNo++;
        }

    }

    class CreateAccount
    {
        static void Main1()
        {
            BankAccount berts = NewBankAccount();
            Write(berts);
            TestDeposit(berts);
            Write(berts);
            TestWithdraw(berts);
            Write(berts);

            BankAccount freds = NewBankAccount();
            Write(freds);
            TestDeposit(freds);
            Write(freds);
            TestWithdraw(freds);
            Write(freds);
        }

        static BankAccount NewBankAccount()
        {
            BankAccount created = new BankAccount();

            Console.Write("Enter the account balance! : ");
            decimal balance = decimal.Parse(Console.ReadLine());

            created.Populate(balance);

            return created;
        }

        static void Write(BankAccount toWrite)
        {
            Console.WriteLine("Account number is {0}", toWrite.GetNumber());
            Console.WriteLine("Account balance is {0}", toWrite.GetBalance());
            Console.WriteLine("Account type is {0}", toWrite.GetAccountType().ToString());
        }

        public static void TestDeposit(BankAccount acc)
        {
            Console.Write("Enter amount to deposit: "); decimal amount = decimal.Parse(Console.ReadLine());
            acc.Deposit(amount);
        }

        public static void TestWithdraw(BankAccount acc)
        {
            Console.Write("Enter amount to withdraw: ");
            decimal amount =
       decimal.Parse(Console.ReadLine());
            if (!acc.Withdraw(amount))
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
    }
}
