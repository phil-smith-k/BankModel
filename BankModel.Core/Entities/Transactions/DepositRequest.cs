using BankModel.Core.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Core.Entities.Transactions
{
    public class DepositRequest : ITransactionRequest
    {
        public DepositRequest(decimal amount)
        {
            this.Amount = Math.Abs(amount);
        }

        public decimal Amount { get; init; }

        public bool ValidateTransaction(IAccount account)
        {
            return account.ValidationRules.All(r => r.Validate(this, account));
        }
    }
}
