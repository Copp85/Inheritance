using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_5
{
   public class BankAccount
    {
        public string AccountNumber { get; set; }
        public string AccountOwner { get; set; }
        public decimal Total { get; set; }

        public BankAccount()
        {

        }

        public BankAccount(string number, string owner, decimal total)
        {
            AccountNumber = number;
            AccountOwner = owner;
            Total = total;

        }

        public override string ToString()
        {
            return string.Format("Account Number: {0} \nAccount Name {1} \nBalance", AccountNumber, AccountOwner, Total);
        }

        public virtual string FileFormat()
        {
            return string.Format("{0}, {1}, {2}", AccountNumber, AccountOwner, Total);
        }
    }
}
