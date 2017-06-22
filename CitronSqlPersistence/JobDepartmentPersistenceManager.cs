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
        SqlDbContext db = new SqlDbContext();
        public Department Create(Department domainEntity)
        {
            throw new NotImplementedException();
        }

        public Department Delete(Department domainEntity)
        {
            throw new NotImplementedException();
        }

        public Department Find(object id)
        {
            throw new NotImplementedException();
        }

        public IList<Department> FindAll(Func<Department, bool> condition)
        {
            IList<Department> jobDepartments = new List<Department>();
            var jobDepartmentEntities = db.JobDepartmentPersistenceEntities;//.Where(condition);
            foreach (var jobDepartment in jobDepartmentEntities)
            {
                jobDepartments.Add(new Department()
                {
                    DepartmentCode = jobDepartment.Code,
                    DepartmentName = jobDepartment.Description
                });
            }
            return jobDepartments;
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
