using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainEntities
{
    public class ProjectCharter : IDomainEntity
    {
        //public string Code { get; set; }
        public string ProjectCode { get; set; }
        public List<QuestionAnswerCollection> QACollection { get; set; }
    }

    public class QuestionAnswerCollection
    {
        public string HeaderCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Answer { get; set; }
        public string Note { get; set; }
    }
}
