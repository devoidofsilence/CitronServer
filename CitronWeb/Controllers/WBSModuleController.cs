using CitronAppCore.DomainEntities;
using CitronAppCore.DomainManagers;
using CitronWeb.HttpResults;
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
        public WBSModuleController(IProjectManager projectManager, IProjectTaskManager projectTaskManager)
        {
            _projectManager = projectManager;
            _projectTaskManager = projectTaskManager;
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
        public object AddProjectTask([FromBody] ProjectTask projectTask)
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
        public object UpdateProjectTaskDetail([FromBody] ProjectTask projectTask)
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
    }
}