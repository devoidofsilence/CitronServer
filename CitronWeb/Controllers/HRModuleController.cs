using CitronAppCore.DomainEntities;
using CitronAppCore.DomainManagers;
using CitronWeb.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace CitronWeb.Controllers
{
    public class HRModuleController : ApiController
    {
        IEmployeeManager _employeeManager;
        public HRModuleController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        // GET api/<controller>
        [HttpPost]
        public object RecruitEmployee([FromBody] Employee employee)
        {
            try
            {
                _employeeManager.RecruitEmployee(employee);
            }
            catch (Exception ex)
            {
                return new ErrorResult() { Reason = ex.Message };
            }
            return new SuccessResult() { Message = "Employee created" };
        }

        [HttpPost]
        public object UpdateEmployeeDetail([FromBody] Employee employee)
        {
            try
            {
                _employeeManager.UpdateEmployeeDetail(employee);
            }
            catch (Exception ex)
            {
                return new ErrorResult() { Reason = ex.Message };
            }
            return new SuccessResult() { Message = "Employee updated" };
        }

        [HttpPost]
        public void DeleteEmployeeDetail([FromBody] Employee employee)
        {
            _employeeManager.DeleteEmployeeDetail(employee);
        }

        [HttpPost]
        public void AddEmployeeJobDetail([FromBody] Employee employee)
        {
            _employeeManager.AddEmployeeJobDetail(employee);
        }

        [HttpPost]
        public void UpdateEmployeeJobDetail([FromBody] Employee employee)
        {
            _employeeManager.UpdateEmployeeJobDetail(employee);
        }

        [HttpPost]
        public void AddEmployeeAccountDetail([FromBody] Employee employee)
        {
            _employeeManager.AddEmployeeAccountDetail(employee);
        }

        [HttpPost]
        public void PromoteEmployee([FromBody] Employee employee)
        {
            _employeeManager.PromoteEmployee(employee);
        }

        [HttpPost]
        public void ReviewEmployeeSalary([FromBody] Employee employee)
        {
            _employeeManager.ReviewEmployeeSalary(employee);
        }

        // GET api/<controller>/5
        public object GetEmployees(Func<Employee, bool> condition)
        {
            try
            {
                return _employeeManager.GetEmployees(condition);
            }
            catch (Exception ex)
            {
                return new ErrorResult() { Reason = ex.Message };
            }
            return new SuccessResult() { Message = "Employee updated" };
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}