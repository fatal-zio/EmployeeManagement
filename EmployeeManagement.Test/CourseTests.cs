﻿using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
    public class CourseTests
    {
        [Fact]
        public void CourseConstructor_ConstructCourse_IsNewMustBeTrue()
        {
            // Arrange
            // Nothing to see here

            // Act
            var course = new Course("Disaster Management 101");

            // Assert
            Assert.True(course.IsNew);
        }
    }
}
