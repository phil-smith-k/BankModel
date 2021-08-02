using BankModel.Core.Entities.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Core.Entities.Accounts
{
    public class CheckingAccount : Account
    {
        public CheckingAccount()
        {
            this.ValidationRules = new List<IRequestValidationRule>
            {
                new OverdraftValidationRule(),
            };
        }

        public CheckingAccount(decimal initialBalance)
            : this()
        {
            this.Balance = initialBalance;
        }
    }
}
