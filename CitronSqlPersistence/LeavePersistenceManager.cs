using System;
using System.Collections.Generic;
using CitronAppCore.DomainEntities;
using CitronInfrastructure.PersistenceManagers;

namespace CitronSqlPersistence
{
    public class LeavePersistenceManager : ILeavePersistenceManager
    {
        public Employee Create(Employee domainEntity)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(Employee domainEntity)
        {
            throw new NotImplementedException();
        }

        public Employee Find(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> FindAll(Func<Employee, bool> condition)
        {
            throw new NotImplementedException();
        }

        public Employee Read(string identifier)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
