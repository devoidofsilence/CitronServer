using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainEntities
{
    public class ProjectTask : IDomainEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OptimisticTime { get; set; }
        public int PessimisticTime { get; set; }
        public int NormalTime { get; set; }
        public int ExpectedTime { get; set; }
        public string ParentTask { get; set; }
        public string ResponsibleEmployee { get; set; }
        public IList<string> EmployeesNeededForTaskCompletion { get; set; }
    }
}
