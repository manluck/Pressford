using KPMG.PressfordConsulting.EntityFramework.DAL;
using KPMG.PressfordConsulting.EntityFramework.Models;
using System.Linq;

namespace KPMG.PressfordConsulting.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<PressfordConsultingDbContext, Employee>, IEmployeeRepository
    {
        public Employee GetSingle(int employeeId)
        {
            var query = GetAll().FirstOrDefault(x => x.EmployeeID == employeeId);
            return query;
        }
    }
}
