using BankModel.Core.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Core.Entities.Banks
{
    public interface IBank
    {
        public string Name { get; set; }
        public IEnumerable<IAccount> Accounts { get; set; }
    }
}
