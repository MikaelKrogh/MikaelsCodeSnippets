using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUnitTest
{
    public class BankAccount
    {
        private double balance;

        public double Balance
        {
            get { return balance; }
        }

        public BankAccount(){}
        public BankAccount(double balance){
            this.balance = balance;
        }

        public void AddMoney(double amount){
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            balance += amount;
        }
        public void WithdrawMoney(double amount){
            if (this.balance - amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            this.balance -= amount;
        }

        public void TranferFundTo(BankAccount otheraccount, double amount){
            if (otheraccount is null)
                throw new ArgumentNullException(nameof(otheraccount));
            
            this.WithdrawMoney(amount);
            otheraccount.AddMoney(amount);
        }
    }
}
