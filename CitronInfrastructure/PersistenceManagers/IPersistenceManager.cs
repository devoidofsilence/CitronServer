using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronInfrastructure.PersistenceManagers
{
    public interface IPersistenceManager<T> where T : IDomainEntity
    {
        T Find(string id);
        IList<T> FindAll(Func<T, bool> condition);
        T Create(T domainEntity);
        T Read(string identifier);
        T Update(T domainEntity);
        T Delete(T domainEntity);
    }
}
