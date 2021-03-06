﻿using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;
using CitronSqlPersistence.PersistenceEntities;

namespace CitronSqlPersistence
{
    public class EmployeeAllowanceDetailPersistenceManager : IEmployeeAllowanceDetailPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public Employee Create(Employee employee)
        {
            var dh = new TempDataHolder();
            Delete(employee);
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            if (employee.Allowances != null)
            {
                foreach (var item in employee.Allowances)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        var allowancePersistenceEntity = db.AllowancePersistenceEntities.FirstOrDefault(e => e.Code == item);
                        if (allowancePersistenceEntity != null)
                        {
                            dh.allowanceTypeID = allowancePersistenceEntity.ID;
                        }
                    }
                    var employeeAllowanceDetailPersistenceEntity = new EmployeeAllowanceDetailPersistenceEntity();
                    employeeAllowanceDetailPersistenceEntity.AllowanceID = dh.allowanceTypeID ?? default(int);
                    employeeAllowanceDetailPersistenceEntity.EmployeeID = employeeSelected.ID;
                    db.EmployeeAllowanceDetailPersistenceEntities.Add(employeeAllowanceDetailPersistenceEntity);
                }
            }

            db.SaveChanges();
            return employee;
        }

        public Employee Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(Employee employee)
        {
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            var employeeAllowanceDetailPersistenceEntity = db.EmployeeAllowanceDetailPersistenceEntities.Where(e => e.EmployeeID == employeeSelected.ID);
            foreach (var item in employeeAllowanceDetailPersistenceEntity)
            {
                db.EmployeeAllowanceDetailPersistenceEntities.Remove(item);
            }

            db.SaveChanges();
            return employee;
        }

        public Employee Find(object id)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> FindAll(Func<Employee, bool> condition)
        {
            throw new NotImplementedException();
        }

        public Employee Read(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
