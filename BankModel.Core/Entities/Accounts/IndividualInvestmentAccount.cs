using BankModel.Core.Entities.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Core.Entities.Accounts
{
    public class IndividualInvestmentAccount : Account
    {
        private const decimal withdrawalLimit = 1000;

        public IndividualInvestmentAccount()
        {
            this.ValidationRules = new List<IRequestValidationRule>
            {
                new OverdraftValidationRule(),
                new WithdrawalLimitValidationRule(withdrawalLimit),
            };
        }

        public IndividualInvestmentAccount(decimal initialBalance)
            : this()
        {
            this.Balance = initialBalance;
        }
    }
}
