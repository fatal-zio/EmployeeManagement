using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Services;
using EmployeeManagement.Test.Services;

namespace EmployeeManagement.Test.Fixtures
{
    public class EmployeeServiceFixture
    {
        public IEmployeeManagementRepository EmployeeManagementTestDataRepository { get; } 
        public EmployeeService EmployeeService { get; }


        public EmployeeServiceFixture()
        {
            EmployeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            EmployeeService = new EmployeeService(EmployeeManagementTestDataRepository, new EmployeeFactory());
        }
    }
}
