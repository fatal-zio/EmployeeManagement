using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
    public class EmployeeFactoryTests
    {
        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
        {
            var employeeFactory = new EmployeeFactory();
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Jayme", "Desrosiers");

            Assert.Equal(2500, employee.Salary);
        }

        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
        {
            var employeeFactory = new EmployeeFactory();
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Jayme", "Desrosiers");

            Assert.InRange(employee.Salary,2500, 3500);
        }

        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500_PrecisionExample()
        {
            var employeeFactory = new EmployeeFactory();
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Jayme", "Desrosiers");
            employee.Salary = 2500.123m;

            Assert.Equal(2500, employee.Salary, 0);
        }
    }
}
