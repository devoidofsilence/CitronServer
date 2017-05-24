using CitronAppCore.DomainManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;
using CitronInfrastructure.PersistenceManagers;

namespace CitronInfrastructure
{
    public class AllowanceManager : IAllowanceManager
    {
        IAllowancePersistenceManager _allowancePersistenceManager;
        public AllowanceManager(IAllowancePersistenceManager allowancePersistenceManager)
        {
            _allowancePersistenceManager = allowancePersistenceManager;
        }
        public Allowance CreateAllowance(Allowance allowance)
        {
            throw new NotImplementedException();
        }

        public Allowance DeleteAllowance(Allowance allowance)
        {
            throw new NotImplementedException();
        }

        public IList<Allowance> GetAllowances(Func<Allowance, bool> condition)
        {
            var allowances = _allowancePersistenceManager.FindAll(condition);
            return allowances;
        }

        public Allowance UpdateAllowance(Allowance allowance)
        {
            throw new NotImplementedException();
        }
    }
}
