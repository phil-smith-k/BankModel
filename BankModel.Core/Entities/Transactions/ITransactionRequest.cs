using BankModel.Core.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Core.Entities.Transactions
{
    public interface ITransactionRequest
    {
        public decimal Amount { get; init; }
        public bool ValidateTransaction(IAccount account);
    }
}
