using Flexi_Work.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Flexi_Work_Tests.RegistrationTests
{
    internal class EmployeeRegistrationTest
    {
        [Test]
        public void Post_WithValidEmployeeInfo_ReturnsOkWithEmployee()
        {
            // Arrange
            var controller = new EmployeeRegistrationController();
            var employee = new EmployeeInfo
            {
                EmployeeName = "John Doe",
                EmployeePhoneNumber = "1234567890",
                EmployeeEmailId = "john@example.com",
                Password = "password123"
            };

            // Act
            var result = controller.Post(employee);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<EmployeeInfo>(okResult.Value);

            var returnedEmployee = okResult.Value as EmployeeInfo;
            Assert.AreEqual(employee.EmployeeName, returnedEmployee.EmployeeName);
            Assert.AreEqual(employee.EmployeePhoneNumber, returnedEmployee.EmployeePhoneNumber);
            Assert.AreEqual(employee.EmployeeEmailId, returnedEmployee.EmployeeEmailId);
        }

    }
}
