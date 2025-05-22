using EmployeeManagement.Test.Fixtures;

namespace EmployeeManagement.Test
{
    public class EmployeeServiceTestsWithDependencyInjection(EmployeeServiceWithDependencyInjectionFixture employeeServiceFixture) : IClassFixture<EmployeeServiceWithDependencyInjectionFixture>
    {
        private readonly EmployeeServiceWithDependencyInjectionFixture _employeeServiceFixture = employeeServiceFixture;

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithObject()
        {
            // Arrange
            var obligatoryCourse = _employeeServiceFixture
                .EmployeeManagementTestRepository
                .GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            // Act
            var internalEmployee = _employeeServiceFixture
                .EmployeeService.CreateInternalEmployee("Brooklyn", "Cannon");

            // Assert
            Assert.Contains(obligatoryCourse, internalEmployee.AttendedCourses);
        }
    }
}
