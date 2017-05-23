using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;

namespace CitronSqlPersistence
{
    public class JobDepartmentPersistenceManager : IJobDepartmentPersistenceManager
    {
        public Department Create(Department domainEntity)
        {
            throw new NotImplementedException();
        }

        public Department Delete(Department domainEntity)
        {
            throw new NotImplementedException();
        }

        public Department Find(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Department> FindAll(Func<Department, bool> condition)
        {
            throw new NotImplementedException();
        }

        public Department Read(string identifier)
        {
            throw new NotImplementedException();
        }

        public Department Update(Department domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
