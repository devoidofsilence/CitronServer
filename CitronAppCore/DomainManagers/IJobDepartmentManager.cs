using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainManagers
{
    public interface IJobDepartmentManager
    {
        Department CreateDepartment(Department department);

        Department UpdateDepartment(Department department);

        Department DeleteDepartment(Department department);

        IList<Department> GetDepartments(Func<Department, bool> condition);
    }
}
