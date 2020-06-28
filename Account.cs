using System.Collections.Generic;
using System.IO;


namespace FirstBank
{
    public class Account
    {
        private List<Transaction> transactions1 = new List<Transaction>();
        public string AccountType { get; set; }
        public decimal AccountBalance { get; set; }
        public string AccountTransaction { get; set; }
        public List<Transaction> transactions { get => transactions1; set => transactions1 = value; }

        public bool withdraw(string type, int amount)
        {
            if (amount <= 0)
                return false;
            int balance = getBalance(type);
            if (amount > balance)
                return false;
            var withdraw = new Transaction
            {
                AccountType = type,
                Balance = amount,
                TransactionType = "Withdraw",
            };
            transactions1.Add(withdraw);
            writeToCSV();
            return true;
        }

        public bool deposit(string type, int amount)
        {
            if (amount <= 0)
                return false;
            var deposit = new Transaction
            {
                AccountType = type,
                Balance = amount,
                TransactionType = "Deposit",
            };
            transactions1.Add(deposit);
            writeToCSV();
            return true;
        }

        public int getBalance(string type)
        {
            int balance = 0;
            for (int i = 0; i < transactions1.Count; i++)
            {
                if (transactions1[i].AccountType.Equals(type))
                    if (transactions1[i].TransactionType.Equals("Deposit"))
                        balance += transactions1[i].Balance;
                    else
                        balance -= transactions1[i].Balance;
            }
            return balance;
        }

        public bool writeToCSV()
        {
            try
            {
                StreamWriter sw = new StreamWriter("transactions.csv");
                for (int i = 0; i < transactions1.Count; i++)
                {
                    sw.Write(transactions1[i].AccountType + ": ");
                    sw.Write(transactions1[i].TransactionType + " - $");
                    sw.Write(transactions1[i].Balance + "\n");
                }
                sw.Close();
                return true;
            }
            catch { }
            return false;
        }

        public bool readFromCSV()
        {
            try
            {
                StreamReader sr = new StreamReader("transactions.csv");
                string line = sr.ReadLine();
                string[] values = line.Split(' ');
                if (values.Length == 3)
                {
                    Transaction transaction = new Transaction();
                    transaction.AccountType = values[0];
                    transaction.TransactionType = values[1];
                    transaction.Balance = int.Parse(values[2]);
                }
                sr.Close();
                return true;
            }
            catch { }
            return false;
        }
    }
}
