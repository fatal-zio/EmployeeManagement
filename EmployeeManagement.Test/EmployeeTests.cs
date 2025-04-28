using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
    public class EmployeeTests
    {
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstAndLastName_FullNameIsConcatenated()
        {
            // Arrange
            var employee = new InternalEmployee("John", "Doe", 1, 2000, false, 1);
            // Act
            var fullName = employee.FullName;
            // Assert
            Assert.Equal("John Doe", fullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstAndLastName_FullNameStartsWithFirstName()
        {
            // Arrange
            var employee = new InternalEmployee("John", "Doe", 1, 2000, false, 1);
            // Act
            var fullName = employee.FullName;
            // Assert
            Assert.StartsWith(employee.FirstName, fullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstAndLastName_FullNameEndsWithLastName()
        {
            // Arrange
            var employee = new InternalEmployee("John", "Doe", 1, 2000, false, 1);
            // Act
            var fullName = employee.FullName;
            // Assert
            Assert.EndsWith(employee.LastName, fullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstAndLastName_FullNameSoundsLikeConcatenation()
        {
            // Arrange
            var employee = new InternalEmployee("John", "Doe", 1, 2000, false, 1)
            {
                // Act
                FirstName = "Lucia",
                LastName = "Shelton"
            };
            // Assert
            Assert.Matches("Lu(c|s|z)ia Shel(t|d)on", employee.FullName);
        }
    }
}
