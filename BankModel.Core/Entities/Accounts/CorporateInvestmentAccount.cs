using BankModel.Core.Entities.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Core.Entities.Accounts
{
    public class CorporateInvestmentAccount : Account
    {
        public CorporateInvestmentAccount()
        {
            this.ValidationRules = new List<IRequestValidationRule>
            {
                new OverdraftValidationRule(),            
            };
        }

        public CorporateInvestmentAccount(decimal initialBalance) 
            : this()
        {
            this.Balance = initialBalance;
        }
    }
}
