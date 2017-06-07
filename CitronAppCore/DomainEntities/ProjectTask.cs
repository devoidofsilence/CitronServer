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
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ParentTaskCode { get; set; }
        public string ParentTaskName { get; set; }
        public string ResponsibleEmployeeCode { get; set; }
        public string ResponsibleEmployeeName { get; set; }
        public IList<string> AssignedEmployees { get; set; }
    }
}
