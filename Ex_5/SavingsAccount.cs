using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_5
{
    public class SavingsAccount : BankAccount
    {
        const decimal SavingsRate = 0.15m;

        public SavingsAccount()
        {
                
        }

        public SavingsAccount(string number, string owner, decimal total)
            : base(number, owner, total)
        {

        }
        public decimal AddInterest()
        {
            decimal newBalance;

            newBalance = this.Total +(this.Total * (SavingsRate));
            return newBalance;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\nBalance: {0}, \nRate: {1}", Total, SavingsRate);
            //, this.AddInterest()
        }

        public override string FileFormat()
        {
            return string.Format("{0}, {1}, {2}, {3}", AccountNumber, AccountOwner, this.AddInterest(), SavingsRate);
        }
    }
}
