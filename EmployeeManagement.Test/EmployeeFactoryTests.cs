using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
    public class EmployeeFactoryTests
    {
        private readonly EmployeeFactory _employeeFactory;

        public EmployeeFactoryTests()
        {
            _employeeFactory = new EmployeeFactory();
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
        {
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Jayme", "Desrosiers");

            Assert.Equal(2500, employee.Salary);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
        {
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Jayme", "Desrosiers");

            Assert.InRange(employee.Salary,2500, 3500);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500_PrecisionExample()
        {
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Jayme", "Desrosiers");
            employee.Salary = 2500.123m;

            Assert.Equal(2500, employee.Salary, 0);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_ReturnType")]
        public void CreateEmployee_IsExternalIsTrue_ReturnTypeMustBeExternalEmployee()
        {
            var employee = _employeeFactory.CreateEmployee("Jayme", "Desrosiers", "Company", true);
            Assert.IsType<ExternalEmployee>(employee);
        }
    }
}
