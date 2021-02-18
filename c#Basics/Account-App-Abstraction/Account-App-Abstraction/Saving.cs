using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_App_Abstraction
{
    class Saving : Account
    {
        public Saving(int accountNumber, string accountHolderName, float accountBalance) : base(accountNumber, accountHolderName, accountBalance) { }

        public override bool Withdraw(float amount)
        {

            if (this.AccountBalance <= 1000)
            {
                return false;
            }
            else
            {
                this.AccountBalance = this.AccountBalance - amount;
                return true;
            }

        }
    }
}
