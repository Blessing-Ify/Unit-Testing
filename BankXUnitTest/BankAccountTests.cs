using Bank_Unit_Testing;
using System;
using Xunit;

namespace BankXUnitTest
{
    public class BankAccountTests
    {
        [Fact]
        public void Adding_Funds_Updates_Balance()
        {
            var account = new BankAccount(1000);
            account.Add(200);
            Assert.Equal(1200, account.Balance);
        }

        [Fact]
        public void Adding_Negative_Funds_Throws()
        {
            var account = new BankAccount(1200);
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-100));
        }

         [Fact]
         public void Withdrawing_Funds_Updates_Balance()
         {
             var account = new BankAccount(1000);
             account.Withdraw(200);
             Assert.Equal(800, account.Balance);
         }

         [Fact]
         public void Withdrawing_Negative_Funds_Throws()
         {
             var account = new BankAccount(800);
             Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-100));
         }

         [Fact]
         public void Withdrawing_More_Than_Funds_Throws()
         {
             var account = new BankAccount(800);
             Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(2000));
         }

         [Fact]
         public void Transfering_Funds_Updates_Both_Accounts()
         {
             var account = new BankAccount(800);
             var otherAccount = new BankAccount();
             account.TransferFundsTo(otherAccount, 500);
             Assert.Equal(300, account.Balance);
             Assert.Equal(500, otherAccount.Balance);
         }

         [Fact]
         public void TransferFundsTo_Non_Existing_Account_Throws()
         {
             var account = new BankAccount(300);
             Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null, 200));
         }
    }
}

