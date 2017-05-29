using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;

namespace CitronSqlPersistence
{
    public class JobDesignationPersistenceManager : IJobDesignationPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public Designation Create(Designation domainEntity)
        {
            throw new NotImplementedException();
        }

        public Designation Update(Designation domainEntity)
        {
            throw new NotImplementedException();
        }

        public Designation Delete(Designation domainEntity)
        {
            throw new NotImplementedException();
        }

        public Designation Find(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Designation> FindAll(Func<Designation, bool> condition)
        {
            IList<Designation> jobDesignations = new List<Designation>();
            var jobDesignationEntities = db.JobDesignationPersistenceEntities;//.Where(condition);
            foreach (var jobDesignation in jobDesignationEntities)
            {
                jobDesignations.Add(new Designation()
                {
                    DesignationCode = jobDesignation.Code,
                    DesignationName = jobDesignation.Description
                });
            }
            return jobDesignations;
        }

        public Designation Read(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
