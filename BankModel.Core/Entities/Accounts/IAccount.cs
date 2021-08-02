using BankModel.Core.Entities.Owners;
using BankModel.Core.Entities.Transactions;
using BankModel.Core.Entities.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Core.Entities.Accounts
{
    public interface IAccount
    {
        public decimal Balance { get; }
        public IOwner Owner { get; set; }
        public IEnumerable<IRequestValidationRule> ValidationRules { get; set; }
        public bool ProcessTransaction(ITransactionRequest request);
        public bool ProcessTransfer(IAccount accountFrom, ITransferRequest request);
    }
}
