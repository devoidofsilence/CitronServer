using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CitronAppCore.DomainManagers;
using CitronInfrastructure;
using CitronInfrastructure.PersistenceManagers;
using CitronSqlPersistence;
using CitronWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CitronWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Register Ioc Dependencies
            RegisterDependencies();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            //WebApiConfig.Register(GlobalConfiguration.Configuration);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // register MVC Controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // register API Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            // Register individual components
            builder.RegisterInstance(new EmployeePersistenceManager())
                   .As<IEmployeePersistenceManager>();
            builder.RegisterInstance(new EmployeeJobDetailPersistenceManager())
                   .As<IEmployeeJobDetailPersistenceManager>();
            builder.RegisterInstance(new EmployeeAccountDetailPersistenceManager())
                   .As<IEmployeeAccountDetailPersistenceManager>();
            builder.RegisterInstance(new EmployeeSalaryHistoryPersistenceManager())
                   .As<IEmployeeSalaryHistoryPersistenceManager>();
            builder.RegisterInstance(new EmployeeJobHistoryPersistenceManager())
                   .As<IEmployeeJobHistoryPersistenceManager>();
            builder.RegisterInstance(new EmployeeAllowanceDetailPersistenceManager())
                   .As<IEmployeeAllowanceDetailPersistenceManager>();
            builder.RegisterInstance(new EmployeeJobDepartmentDetailPersistenceManager())
                   .As<IEmployeeJobDepartmentDetailPersistenceManager>();
            builder.RegisterInstance(new LeavePersistenceManager())
                   .As<ILeavePersistenceManager>();
            builder.RegisterInstance(new AllowancePersistenceManager())
                   .As<IAllowancePersistenceManager>();
            builder.RegisterInstance(new BloodGroupPersistenceManager())
                   .As<IBloodGroupPersistenceManager>();
            builder.RegisterInstance(new PersonalityTypePersistenceManager())
                   .As<IPersonalityTypePersistenceManager>();
            builder.RegisterInstance(new JobDesignationPersistenceManager())
                   .As<IJobDesignationPersistenceManager>();
            builder.RegisterInstance(new JobDepartmentPersistenceManager())
                   .As<IJobDepartmentPersistenceManager>();
            builder.RegisterInstance(new MaritalStatusPersistenceManager())
                   .As<IMaritalStatusPersistenceManager>();
            builder.RegisterInstance(new ProjectPersistenceManager())
                   .As<IProjectPersistenceManager>();
            builder.RegisterInstance(new ProjectTaskPersistenceManager())
                   .As<IProjectTaskPersistenceManager>();
            builder.RegisterInstance(new ProjectAssignedEmployeesPersistenceManager())
                   .As<IProjectAssignedEmployeesPersistenceManager>();
            builder.RegisterInstance(new ProjectTaskAssignedEmployeesPersistenceManager())
                  .As<IProjectTaskAssignedEmployeesPersistenceManager>();
            builder.RegisterType<EmployeeManager>()
                   .As<IEmployeeManager>()
                   .UsingConstructor(typeof(IEmployeePersistenceManager), typeof(IEmployeeJobDetailPersistenceManager), typeof(IEmployeeAccountDetailPersistenceManager), typeof(IEmployeeSalaryHistoryPersistenceManager), typeof(IEmployeeJobHistoryPersistenceManager), typeof(IEmployeeAllowanceDetailPersistenceManager), typeof(IEmployeeJobDepartmentDetailPersistenceManager), typeof(ILeavePersistenceManager));
            builder.RegisterType<ProjectManager>()
                   .As<IProjectManager>()
                   .UsingConstructor(typeof(IProjectPersistenceManager), typeof(IProjectAssignedEmployeesPersistenceManager));
            builder.RegisterType<ProjectTaskManager>()
                   .As<IProjectTaskManager>()
                   .UsingConstructor(typeof(IProjectTaskPersistenceManager), typeof(IProjectTaskAssignedEmployeesPersistenceManager));
            builder.RegisterType<AllowanceManager>()
                   .As<IAllowanceManager>()
                   .UsingConstructor(typeof(IAllowancePersistenceManager));
            builder.RegisterType<BloodGroupManager>()
                   .As<IBloodGroupManager>()
                   .UsingConstructor(typeof(IBloodGroupPersistenceManager));
            builder.RegisterType<JobDepartmentManager>()
                   .As<IJobDepartmentManager>()
                   .UsingConstructor(typeof(IJobDepartmentPersistenceManager));
            builder.RegisterType<JobDesignationManager>()
                   .As<IJobDesignationManager>()
                   .UsingConstructor(typeof(IJobDesignationPersistenceManager));
            builder.RegisterType<PersonalityTypeManager>()
                   .As<IPersonalityTypeManager>()
                   .UsingConstructor(typeof(IPersonalityTypePersistenceManager));
            builder.RegisterType<MaritalStatusManager>()
                   .As<IMaritalStatusManager>()
                   .UsingConstructor(typeof(IMaritalStatusPersistenceManager));




            var container = builder.Build();

            // Set the dependency resolver to be Autofac.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
