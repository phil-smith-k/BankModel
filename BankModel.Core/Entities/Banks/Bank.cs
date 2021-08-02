using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankModel.Core.Entities.Accounts;

namespace BankModel.Core.Entities.Banks
{
    public class Bank : IBank
    {
        public string Name { get; set; }
        public IEnumerable<IAccount> Accounts { get; set; }
    }
}
