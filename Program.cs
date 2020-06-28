using System;
using CsvHelper;

namespace FirstBank
{
    public class Transaction
    {
        public int Balance { get; set; }
        public string AccountType { get; set; }
        public string TransactionType { get; set; }
    }

    class Program
    {

        static void DisplayGreeting()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to First Bank of Suncoast!");
            Console.WriteLine("Choose from one of the following:");
            Console.WriteLine();
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        public static int PromptForInteger(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                int userInput;
                var isInputGood = int.TryParse(Console.ReadLine(), out userInput);

                if (isInputGood && userInput >= 0)
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("Sorry, that is an invalid entry. Please try again.");

                }
            }

        }

        static void Main(string[] args)
        {
            Account user = new Account();
            user.readFromCSV();

            DisplayGreeting();


            string choice = "";

            while (choice != "E")
            {
                Console.WriteLine("(V)iew balances:");

                Console.WriteLine("(CD): Checking Deposit:");

                Console.WriteLine("(CW): Checking Withdrawal:");

                Console.WriteLine("(SD): Saving Deposit:");

                Console.WriteLine("(SW): Saving Withdrawal:");

                Console.WriteLine("(E)xit the application");

                Console.WriteLine();

                choice = PromptForString("Choice: ");

                if (choice == ("V"))
                {
                    int checkingBalance = user.getBalance("Checking");
                    int savingBalance = user.getBalance("Saving");

                    Console.WriteLine(string.Format("Here's a summary of your accounts - Checking: ${0}. Saving: ${1}.", checkingBalance, savingBalance));
                }

                if (choice == ("CD"))
                {
                    var amount = PromptForInteger("Amount to deposit:");
                    bool result = user.deposit("Checking", amount);
                    if (!result)
                    {
                        Console.WriteLine("Deposit failed. Please try again");
                    }
                }

                if (choice == ("SD"))
                {
                    var amount = PromptForInteger("Amount to deposit:");
                    bool result = user.deposit("Saving", amount);
                    if (!result)
                    {
                        Console.WriteLine("Deposit failed. Please try again");
                    }
                }

                if (choice == ("SW"))
                {
                    var amount = PromptForInteger("Amount to withdraw:");
                    bool result = user.withdraw("Saving", amount);
                    if (!result)
                    {
                        Console.WriteLine("Withdraw failed. Please try again");
                    }
                }

                if (choice == ("CW"))
                {
                    var amount = PromptForInteger("Amount to withdraw:");
                    bool result = user.withdraw("Checking", amount);
                    if (!result)
                    {
                        Console.WriteLine("Withdraw failed. Please try again");
                    }
                }
            }
        }
    }
}
