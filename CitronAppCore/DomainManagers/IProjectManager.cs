﻿using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainManagers
{
    public interface IProjectManager
    {
        Project AddProject(Project project);
        Project UpdateProject(Project project);
        Project DeleteProject(Project project);
        Project GetProjectDetail(string code);
        IList<Project> GetProjects(Func<Project, bool> condition);
        object GetProjectAssignedEmployees(string code);
    }
}
