using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Core.Entities.Transactions
{
    public interface ITransferRequest
    {
        public decimal Amount { get; init; }
        public ITransactionRequest WithdrawalRequest { get; init; }
        public ITransactionRequest DepositRequest { get; init; }
    }
}
