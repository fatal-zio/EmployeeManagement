using EmployeeManagement.Business.EventArguments;
using EmployeeManagement.Business.Exceptions;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Test.Fixtures;
using Xunit.Abstractions;

namespace EmployeeManagement.Test
{
    [Collection("EmployeeServiceCollection")]
    public class EmployeeServiceTests(EmployeeServiceFixture employeeServiceFixture, ITestOutputHelper testOutputHelper) //: IClassFixture<EmployeeServiceFixture>
    {
        private readonly EmployeeServiceFixture _employeeServiceFixture = employeeServiceFixture;
        private readonly ITestOutputHelper _outputHelper = testOutputHelper;

        [Fact]
        public void CreateInternalImployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithObject()
        {
            // Arrange          
            var obligatoryCourse = _employeeServiceFixture
                .EmployeeManagementTestDataRepository
                .GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            // Act
            var internalEmployee = _employeeServiceFixture
                .EmployeeService
                .CreateInternalEmployee("Brooklyn", "Cannon");

            // Assert
            Assert.Contains(obligatoryCourse, internalEmployee.AttendedCourses);
        }

        [Fact]
        public void CreateInternalImployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithPredicate()
        {
            // Act
            var internalEmployee = _employeeServiceFixture.EmployeeService.CreateInternalEmployee("Brooklyn", "Cannon");

            _outputHelper.WriteLine($"Employee after Act: {internalEmployee.FullName}");
            internalEmployee.AttendedCourses.ForEach(e => _outputHelper.WriteLine($"Course: {e.Title}"));

            // Assert
            Assert.Contains(internalEmployee.AttendedCourses, course => course.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
        }

        [Fact]
        public void CreateInternalImployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourses()
        {
            // Arrange
            var obligatoryCourses = _employeeServiceFixture.EmployeeManagementTestDataRepository.GetCourses(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

            // Act
            var internalEmployee = _employeeServiceFixture.EmployeeService.CreateInternalEmployee("Brooklyn", "Cannon");

            // Assert
            Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);
        }

        [Fact]
        public void CreateInternalImployee_InternalEmployeeCreated_AttendedCoursesMustNotBeNew()
        {
            // Act
            var internalEmployee = _employeeServiceFixture.EmployeeService.CreateInternalEmployee("Brooklyn", "Cannon");

            // Assert
            Assert.All(internalEmployee.AttendedCourses, course => Assert.False(course.IsNew));
        }

        [Fact]
        public async Task CreateInternalImployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourses_Async()
        {
            // Arrange
            var obligatoryCourses = await _employeeServiceFixture.EmployeeManagementTestDataRepository.GetCoursesAsync(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

            // Act
            var internalEmployee = await _employeeServiceFixture.EmployeeService.CreateInternalEmployeeAsync("Brooklyn", "Cannon");

            // Assert
            Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);
        }

        [Fact]
        public async Task GiveRaise_RaiseBelowMinimumGiven_EmployeeInvalidRaiseExceptionMustBeThrown()
        {
            // Arrange
            var internalEmployee = new InternalEmployee("Brook", "Cannon", 5, 3000, false, 1);

            // Act & Assert
            await Assert.ThrowsAsync<EmployeeInvalidRaiseException>(async () =>
            {
                await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(internalEmployee, 50);
            });
        }

        [Fact]
        public void NotifyOfAbsence_EmployeeIsAbsent_OnEmployeeIsAbsentMustBeTriggered()
        {
            // Arrange
            var internalEmployee = new InternalEmployee("Brook", "Cannon", 5, 3000, false, 1);

            // Act & Assert
            Assert.Raises<EmployeeIsAbsentEventArgs>(
                handler => _employeeServiceFixture.EmployeeService.EmployeeIsAbsent += handler,
                handler => _employeeServiceFixture.EmployeeService.EmployeeIsAbsent -= handler,
                () => _employeeServiceFixture.EmployeeService.NotifyOfAbsence(internalEmployee));
        }
    }
}
