using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace AccountInterface
{
    public enum AccountCategory
    {
        Checking,
        Savings,
        Retirement,
        Investment
    }

    public interface IAccountDimensions
    {
        float minBalance { get; set; }
        string currency { get; set; }
        bool advisorEnabled { get; set; }
    }

    public interface IAccount
    {
        string accountNumber { get; set; }
        string accountLogin { get; set; }
        float accountBalance { get; set; }
        DateTime? lastLogin { get; set; }
        AccountCategory accountType { get; set; }

        void AccountCharacteristics();
    }

    public class Account : IAccount, IAccountDimensions
    {
        public string accountNumber { get; set; }
        public string accountLogin { get; set; }
        public float accountBalance { get; set; }
        public DateTime? lastLogin { get; set; }
        public AccountCategory accountType { get; set; }
        public float minBalance { get; set; }
        public string currency { get; set; }
        public bool advisorEnabled { get; set; }

        public Account(string AccountNumber, string AccountLogin, float AccountBalance, AccountCategory AccountType)
        {
            accountNumber = AccountNumber;
            accountLogin = AccountLogin;
            accountBalance = AccountBalance;
            accountType = AccountType;
        }

        public void AccountCharacteristics()
        {
            WriteLine("Account Characteristics");
            WriteLine("accountNumber: {0}", accountNumber);
            WriteLine("accountLogin: {0}", accountLogin);
            WriteLine("accountBalance: {0}", accountBalance);
            WriteLine("lastLogin: {0}", lastLogin);
            WriteLine("AccountCategory: {0}", accountType);
            WriteLine("minBalance: {0}", minBalance);
            WriteLine("currency: {0}", currency);
            WriteLine($"advisorEnabled: {advisorEnabled}");
        }
    }

    public class AccountProgram
    {
        public static void Main()
        {
            Account savingsAcct = new Account("SS345-9I", "JADFL2", 10234.34f, AccountCategory.Savings);
            savingsAcct.lastLogin = DateTime.Now;
            savingsAcct.minBalance = 5000.00f;
            savingsAcct.currency = "USD";
            savingsAcct.advisorEnabled = false;
            savingsAcct.AccountCharacteristics();
            WriteLine();

            Account investAcct = new Account("IN345-9I", "LNKT43", 310234.34f, AccountCategory.Investment);
            investAcct.lastLogin = DateTime.Now;
            investAcct.minBalance = 25000.00f;
            investAcct.currency = "EUR";
            investAcct.advisorEnabled = true;
            investAcct.AccountCharacteristics();
            WriteLine();

            ReadLine();
        }
    }
}
