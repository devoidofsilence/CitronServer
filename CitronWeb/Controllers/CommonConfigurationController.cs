using CitronAppCore.DomainManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CitronWeb.Controllers
{
    public class CommonConfigurationController : ApiController
    {
        IAllowanceManager _allowanceManager;
        IBloodGroupManager _bloodGroupManager;
        IJobDepartmentManager _jobDepartmentManager;
        IJobDesignationManager _jobDesignationManager;
        IPersonalityTypeManager _personalityTypeManager;
        IMaritalStatusManager _maritalStatusManager;

        public CommonConfigurationController(IAllowanceManager allowanceManager, IBloodGroupManager bloodGroupManager, IJobDepartmentManager jobDepartmentManager, IJobDesignationManager jobDesignationManager, IPersonalityTypeManager personalityTypeManager, IMaritalStatusManager maritalStatusManager)
        {
            _allowanceManager = allowanceManager;
            _bloodGroupManager = bloodGroupManager;
            _jobDepartmentManager = jobDepartmentManager;
            _jobDesignationManager = jobDesignationManager;
            _personalityTypeManager = personalityTypeManager;
            _maritalStatusManager = maritalStatusManager;
        }

        public object GetAllowances()
        {
            return _allowanceManager.GetAllowances(all => true);
        }
        public object GetBloodGroups()
        {
            return _bloodGroupManager.GetBloodGroups(bg => true);
        }
        public object GetJobDepartments()
        {
            return _jobDepartmentManager.GetDepartments(dep => true);
        }
        public object GetDesignations()
        {
            return _jobDesignationManager.GetDesignations(des => true);
        }
        public object GetPersonalityTypes()
        {
            return _personalityTypeManager.GetPersonalityTypes(pt => true);
        }
        public object GetMaritalStatuses()
        {
            return _maritalStatusManager.GetMaritalStatuses(ms => true);
        }
    }
}
