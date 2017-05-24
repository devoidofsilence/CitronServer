using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainManagers
{
    public interface IJobDesignationManager
    {
        Designation CreateDesignation(Designation designation);

        Designation UpdateDesignation(Designation designation);

        Designation DeleteDesignation(Designation designation);

        IList<Designation> GetDesignations(Func<Designation, bool> condition);
    }
}
