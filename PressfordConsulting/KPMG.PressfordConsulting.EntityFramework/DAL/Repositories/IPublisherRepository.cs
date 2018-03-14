using KPMG.PressfordConsulting.EntityFramework.Models;

namespace KPMG.PressfordConsulting.Data.Repositories
{
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {

        Publisher GetSingle(int publisherId);
    }
}
