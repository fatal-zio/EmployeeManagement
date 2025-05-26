using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Test.Fixtures;
using EmployeeManagement.Test.TestData;

namespace EmployeeManagement.Test
{
    [Collection("EmployeeServiceCollection")]
    public class DataDrivenEmployeeServiceTests(EmployeeServiceFixture employeeServiceFixture)// : IClassFixture<EmployeeServiceFixture>
    {
        private readonly EmployeeServiceFixture _employeeServiceFixture = employeeServiceFixture;

        [Theory]
        [InlineData("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e")]
        [InlineData("37e03ca7-c730-4351-834c-b66f280cdb01")]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedSecondObligatoryCourse(
            Guid courseId)
        {
            // Act
            var internalEmployee = _employeeServiceFixture.EmployeeService
                .CreateInternalEmployee("Brooklyn", "Cannon");

            // Assert
            Assert.Contains(internalEmployee.AttendedCourses,
                course => course.Id == courseId);
        }

        [Theory]
        [MemberData(nameof(ExampleTestDataForGiveRaise_WithMethod), 1, MemberType = typeof(DataDrivenEmployeeServiceTests))]
        public async Task GiveRaise_RaiseGiven_EmployeeMinimumRaiseGivenMatchesValue_WithMemberData(int raiseGiven, bool expectedValueForMinimumRaiseGiven)
        {
            // Arrange  
            var internalEmployee = new InternalEmployee(
                "Brooklyn", "Cannon", 5, 3000, false, 1);

            // Act
            await _employeeServiceFixture
                .EmployeeService.GiveRaiseAsync(internalEmployee, raiseGiven);

            // Assert
            Assert.Equal(expectedValueForMinimumRaiseGiven, internalEmployee.MinimumRaiseGiven);
        }

        [Theory]
        [ClassData(typeof(EmployeeServiceTestData))]
        public async Task GiveRaise_RaiseGiven_EmployeeMinimumRaiseGivenMatchesValue_WithClassData(int raiseGiven, bool expectedValueForMinimumRaiseGiven)
        {
            // Arrange  
            var internalEmployee = new InternalEmployee(
                "Brooklyn", "Cannon", 5, 3000, false, 1);

            // Act
            await _employeeServiceFixture
                .EmployeeService.GiveRaiseAsync(internalEmployee, raiseGiven);

            // Assert
            Assert.Equal(expectedValueForMinimumRaiseGiven, internalEmployee.MinimumRaiseGiven);
        }

        [Theory]
        [ClassData(typeof(StronglyTypedEmployeeServiceTestData))]
        public async Task GiveRaise_RaiseGiven_EmployeeMinimumRaiseGivenMatchesValue_WithTypedClassData(int raiseGiven, bool expectedValueForMinimumRaiseGiven)
        {
            // Arrange  
            var internalEmployee = new InternalEmployee(
                "Brooklyn", "Cannon", 5, 3000, false, 1);

            // Act
            await _employeeServiceFixture
                .EmployeeService.GiveRaiseAsync(internalEmployee, raiseGiven);

            // Assert
            Assert.Equal(expectedValueForMinimumRaiseGiven, internalEmployee.MinimumRaiseGiven);
        }

        public static IEnumerable<object[]> ExampleTestDataForGiveRaise_WithProperty
        {
            get
            {
                return
                [
                        [100, true],
                        [200, false]
                ];
            }
        }

        public static TheoryData<int, bool> StronglyTypedExampleTestDataForGiveRaise_WithProperty
        {
            get
            {
                return new TheoryData<int, bool>()
                {
                        { 100, true },
                        { 200, false }
                };
            }
        }

        public static IEnumerable<object[]> ExampleTestDataForGiveRaise_WithMethod(
             int testDataInstancesToProvide)
        {
            var testData = new List<object[]>
                {
                        new object[] { 100, true },
                        new object[] { 200, false }
                };

            return testData.Take(testDataInstancesToProvide);
        }


        //[Theory]
        //[MemberData(
        //    nameof(DataDrivenEmployeeServiceTests.ExampleTestDataForGiveRaise_WithMethod),
        //    1,
        //    MemberType = typeof(DataDrivenEmployeeServiceTests))]
        //[ClassData(typeof(EmployeeServiceTestData))]
        //[ClassData(typeof(StronglyTypedEmployeeServiceTestData))]
        //[MemberData(nameof(StronglyTypedExampleTestDataForGiveRaise_WithProperty))]
        //[ClassData(typeof(StronglyTypedEmployeeServiceTestData_FromFile))]
        //public async Task GiveRaise_RaiseGiven_EmployeeMinimumRaiseGivenMatchesValue(
        //    int raiseGiven, bool expectedValueForMinimumRaiseGiven)
        //{
        //    // Arrange  
        //    var internalEmployee = new InternalEmployee(
        //        "Brooklyn", "Cannon", 5, 3000, false, 1);

        //    // Act
        //    await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(
        //        internalEmployee, raiseGiven);

        //    // Assert
        //    Assert.Equal(expectedValueForMinimumRaiseGiven,
        //        internalEmployee.MinimumRaiseGiven);
        //}
    }
}
