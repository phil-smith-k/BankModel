using BankModel.Core.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Core.Entities.Transactions
{
    public class TransferRequest : ITransferRequest
    {
        public TransferRequest(decimal amount)
        {
            this.Amount = amount;

            this.WithdrawalRequest = new WithdrawalRequest(amount);
            this.DepositRequest = new DepositRequest(amount);
        }

        public ITransactionRequest WithdrawalRequest { get; init; }
        public ITransactionRequest DepositRequest { get; init;  }
        public decimal Amount { get; init; }
    }
}
