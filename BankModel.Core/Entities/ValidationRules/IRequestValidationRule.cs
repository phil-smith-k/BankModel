using BankModel.Core.Entities.Accounts;
using BankModel.Core.Entities.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Core.Entities.ValidationRules
{
    public interface IRequestValidationRule
    {
        public bool Validate(ITransactionRequest request, IAccount account);
    }
}
