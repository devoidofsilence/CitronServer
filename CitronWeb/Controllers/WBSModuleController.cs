using CitronAppCore.DomainEntities;
using CitronAppCore.DomainManagers;
using CitronWeb.HttpResults;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CitronWeb.Controllers
{
    public class WBSModuleController : ApiController
    {
        IProjectManager _projectManager;
        IProjectTaskManager _projectTaskManager;
        IProjectCharterQuestionManager _projectCharterQuestionManager;
        IProjectCharterManager _projectCharterManager;
        IStakeholderManager _stakeholderManager;
        IAssignStakeholderManager _assignStakeholderManager;
        public WBSModuleController(IProjectManager projectManager, IProjectTaskManager projectTaskManager, IProjectCharterQuestionManager projectCharterQuestionManager, IProjectCharterManager projectCharterManager, IStakeholderManager stakeholderManager, IAssignStakeholderManager assignStakeholderManager)
        {
            _projectManager = projectManager;
            _projectTaskManager = projectTaskManager;
            _projectCharterQuestionManager = projectCharterQuestionManager;
            _projectCharterManager = projectCharterManager;
            _stakeholderManager = stakeholderManager;
            _assignStakeholderManager = assignStakeholderManager;
        }

        [HttpPost]
        public object AddProject([FromBody] Project project)
        {
            try
            {
                _projectManager.AddProject(project);
            }
            catch (Exception ex)
            {
                return new ErrorResult() { Reason = ex.Message };
            }
            return new SuccessResult() { Message = "Project added" };
        }

        [HttpPost]
        public object UpdateProjectDetail([FromBody] Project project)
        {
            try
            {
                _projectManager.UpdateProject(project);
            }
            catch (Exception ex)
            {
                return new ErrorResult() { Reason = ex.Message };
            }
            return new SuccessResult() { Message = "Project updated" };
        }

        [HttpPost]
        public void DeleteProjectDetail([FromBody] Project project)
        {
            _projectManager.DeleteProject(project);
        }

        [HttpPost]
        public object AddProjectTask([FromBody] ProjectTask[] projectTask)
        {
            try
            {
                _projectTaskManager.AddProjectTask(projectTask);
            }
            catch (Exception ex)
            {
                return new ErrorResult() { Reason = ex.Message };
            }
            return new SuccessResult() { Message = "Project Task added" };
        }

        [HttpPost]
        public object UpdateProjectTaskDetail([FromBody] ProjectTask[] projectTask)
        {
            try
            {
                _projectTaskManager.UpdateProjectTask(projectTask);
            }
            catch (Exception ex)
            {
                return new ErrorResult() { Reason = ex.Message };
            }
            return new SuccessResult() { Message = "Project Task updated" };
        }

        [HttpPost]
        public void DeleteProjectTaskDetail([FromBody] ProjectTask projectTask)
        {
            _projectTaskManager.DeleteProjectTask(projectTask);
        }

        // GET api/<controller>/5
        public object GetProjects()
        {
            return _projectManager.GetProjects(null);
        }

        [HttpGet]
        [Route("api/WBSModule/GetProjectDetail/{code}")]
        public object GetProjectDetail(string code)
        {
            if (code != null)
            {
                return _projectManager.GetProjectDetail(code);
            }
            return new ErrorResult() { Reason = "" };
        }

        public object GetProjectTasks()
        {
            return _projectTaskManager.GetProjectTasks(null);

        }

        [HttpGet]
        [Route("api/WBSModule/GetProjectTaskDetail/{code}")]
        public object GetProjectTaskDetail(string code)
        {
            if (code != null)
            {
                return _projectTaskManager.GetProjectTaskDetail(code);
            }
            return new ErrorResult() { Reason = "" };
        }

        [HttpGet]
        [Route("api/WBSModule/GetProjectCharterDetail/{code}")]
        public object GetProjectCharterDetail(string code)
        {
            if (code != null)
            {
                return _projectCharterManager.GetProjectCharterDetail(code);
            }
            return new ErrorResult() { Reason = "" };
        }

        public object GetProjectCharterQuestions()
        {
            return _projectCharterQuestionManager.GetProjectCharterQuestions(null);

        }

        [HttpPost]
        public object AddProjectCharter([FromBody] ProjectCharter projectCharter)
        {
            try
            {
                _projectCharterManager.CreateProjectCharter(projectCharter);
            }
            catch (Exception ex)
            {
                return new ErrorResult() { Reason = ex.Message };
            }
            return new SuccessResult() { Message = "Project Charter added" };
        }

        [HttpPost]
        public object UpdateProjectCharter([FromBody] ProjectCharter projectCharter)
        {
            try
            {
                _projectCharterManager.UpdateProjectCharter(projectCharter);
            }
            catch (Exception ex)
            {
                return new ErrorResult() { Reason = ex.Message };
            }
            return new SuccessResult() { Message = "Project Charter added" };
        }

        [HttpPost]
        public object AddStakeholder([FromBody] List<Stakeholder> stakeholders)
        {
            try
            {
                _stakeholderManager.CreateStakeholder(stakeholders);
            }
            catch (Exception ex)
            {
                return new ErrorResult() { Reason = ex.Message };
            }
            return new SuccessResult() { Message = "Stakeholder added" };
        }

        [HttpPost]
        public object UpdateStakeholder([FromBody] List<Stakeholder> stakeholders)
        {
            try
            {
                _stakeholderManager.UpdateStakeholder(stakeholders);
            }
            catch (Exception ex)
            {
                return new ErrorResult() { Reason = ex.Message };
            }
            return new SuccessResult() { Message = "Stakeholder added" };
        }

        [HttpPost]
        public void DeleteStakeholder([FromBody] Stakeholder stakeholder)
        {
            _stakeholderManager.DeleteStakeholder(stakeholder);
        }

        [HttpGet]
        [Route("api/WBSModule/GetStakeholders")]
        public object GetStakeholders()
        {
            return _stakeholderManager.GetStakeholders(null);
        }

        [HttpGet]
        [Route("api/WBSModule/GetEmployeesInsideProject/{code}")]
        public object GetEmployeesInsideProject(string code)
        {
            return _projectManager.GetProjectAssignedEmployees(code);
        }

        [HttpPost]
        public object AssignStakeholders([FromBody] AssignStakeholder[] stakeholders)
        {
            try
            {
                _assignStakeholderManager.AssignStakeholder(stakeholders);
            }
            catch (Exception ex)
            {
                return new ErrorResult() { Reason = ex.Message };
            }
            return new SuccessResult() { Message = "Stakeholders assigned" };
        }

        [HttpPost]
        public object UpdateAssignedStakeholders([FromBody] AssignStakeholder[] stakeholders)
        {
            try
            {
                _assignStakeholderManager.UpdateAssignedStakeholder(stakeholders);
            }
            catch (Exception ex)
            {
                return new ErrorResult() { Reason = ex.Message };
            }
            return new SuccessResult() { Message = "Stakeholders assigned" };
        }

        [HttpPost]
        public void DeleteAssignedStakeholder([FromBody] AssignStakeholder stakeholder)
        {
            _assignStakeholderManager.DeleteAssignedStakeholder(stakeholder);
        }

        [HttpGet]
        [Route("api/WBSModule/GetAssignedStakeholders")]
        public object GetAssignedStakeholders()
        {
            return _assignStakeholderManager.GetAssignedStakeholders(null);
        }
    }
}