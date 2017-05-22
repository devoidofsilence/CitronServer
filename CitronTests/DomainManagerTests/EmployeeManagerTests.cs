using Microsoft.VisualStudio.TestTools.UnitTesting;
using CitronAppCore.DomainEntities;
using CitronAppCore.DomainManagers;
using CitronInfrastructure;
using System;

namespace CitronTests.DomainManagerTests
{
    [TestClass]
    public class EmployeeManagerTests
    {
        IEmployeeManager employeeManager;
        public EmployeeManagerTests(IEmployeeManager _employeeManager)
        {
            employeeManager = _employeeManager;
        }

        [TestMethod]
        public void Present_Employee_Is_Correctly_Marked_As_Absent()
        {
            // AAA : Arrange - Act - Assert

            // Arrange
            Employee presentEmployee = new Employee { IsAbsent = false };            

            // Act
            var presentEmployeeAfterMarkedAsAbsentCalled = employeeManager.MarkAsAbsent(presentEmployee, DateTime.Today);

            // Assert
            Assert.IsTrue(presentEmployeeAfterMarkedAsAbsentCalled.IsAbsent);
        }

        [TestMethod]
        public void Absent_Employee_Is_Correctly_Marked_As_Absent()
        {
            // AAA : Arrange - Act - Assert

            // Arrange
            Employee absentEmployee = new Employee { IsAbsent = true };

            // Act
            var absentEmployeeAfterMarkedAsAbsentCalled = employeeManager.MarkAsAbsent(absentEmployee, DateTime.Today);

            // Assert
            Assert.IsTrue(absentEmployeeAfterMarkedAsAbsentCalled.IsAbsent);
        }
    }
}
