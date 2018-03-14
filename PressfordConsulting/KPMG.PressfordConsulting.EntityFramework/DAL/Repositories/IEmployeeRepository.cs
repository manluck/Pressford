using KPMG.PressfordConsulting.EntityFramework.Models;

namespace KPMG.PressfordConsulting.Data.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Employee GetSingle(int employeeId);
    }
}
