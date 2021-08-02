using BankModel.Core.Entities.Accounts;
using BankModel.Core.Entities.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Core.Entities.ValidationRules
{
    public class WithdrawalLimitValidationRule : IRequestValidationRule
    {
        private readonly decimal limit;

        public WithdrawalLimitValidationRule(decimal limit)
        {
            this.limit = limit;
        }

        public bool Validate(ITransactionRequest request, IAccount account)
        {
            return !(request.Amount > limit);
        }
    }
}
