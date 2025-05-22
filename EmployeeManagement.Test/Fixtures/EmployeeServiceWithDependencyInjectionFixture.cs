using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Services;
using EmployeeManagement.Test.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Test.Fixtures
{
    public class EmployeeServiceWithDependencyInjectionFixture : IDisposable
    {
        private readonly ServiceProvider _serviceProvider;

        public EmployeeServiceWithDependencyInjectionFixture()
        {
            var services = new ServiceCollection();
            services.AddScoped<EmployeeFactory>();
            services.AddScoped<IEmployeeManagementRepository, EmployeeManagementTestDataRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public IEmployeeManagementRepository EmployeeManagementTestRepository
        {
            get
            {
                return _serviceProvider.GetRequiredService<IEmployeeManagementRepository>();
            }
        }

        public IEmployeeService EmployeeService
        {
            get
            {
                return _serviceProvider.GetRequiredService<IEmployeeService>();
            }
        }


        public void Dispose()
        {
            // add cleanup code here if needed
        }
    }
}
