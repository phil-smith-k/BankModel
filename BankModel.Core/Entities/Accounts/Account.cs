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
    public abstract class Account : IAccount
    {
        public decimal Balance { get; protected set; }
        public IEnumerable<IRequestValidationRule> ValidationRules { get; set; }
        public IOwner Owner { get; set; }
        
        public bool ProcessTransaction(ITransactionRequest request)
        {
            if (!request.ValidateTransaction(this))
            {
                return false;
            }

            this.Balance += request.Amount;
            return true;
        }

        public bool ProcessTransfer(IAccount accountFrom, ITransferRequest request)
        {
            var depositIsValid = request.DepositRequest.ValidateTransaction(this);
            var withdrawalIsValid = request.WithdrawalRequest.ValidateTransaction(accountFrom);

            if (depositIsValid && withdrawalIsValid)
            {
                return this.ProcessTransaction(request.DepositRequest) 
                    && accountFrom.ProcessTransaction(request.WithdrawalRequest);
            }

            return false;
        }
    }
}
