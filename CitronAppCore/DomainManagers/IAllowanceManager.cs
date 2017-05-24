using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainManagers
{
    public interface IAllowanceManager
    {
        Allowance CreateAllowance(Allowance allowance);

        Allowance UpdateAllowance(Allowance allowance);

        Allowance DeleteAllowance(Allowance allowance);

        IList<Allowance> GetAllowances(Func<Allowance, bool> condition);
    }
}
