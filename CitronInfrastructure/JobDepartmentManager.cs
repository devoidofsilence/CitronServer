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
    public class JobDepartmentManager : IJobDepartmentManager
    {
        IJobDepartmentPersistenceManager _jobDepartmentPersistenceManager;
        public JobDepartmentManager(IJobDepartmentPersistenceManager jobDepartmentPersistenceManager)
        {
            _jobDepartmentPersistenceManager = jobDepartmentPersistenceManager;
        }
        public Department CreateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Department DeleteDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public IList<Department> GetDepartments(Func<Department, bool> condition)
        {
            var jobDepartments = _jobDepartmentPersistenceManager.FindAll(condition);
            return jobDepartments;
        }

        public Department UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
