using KPMG.PressfordConsulting.EntityFramework.DAL;
using KPMG.PressfordConsulting.EntityFramework.Models;
using System.Linq;

namespace KPMG.PressfordConsulting.Data.Repositories
{
    public class PublisherRepository : GenericRepository<PressfordConsultingDbContext, Publisher>, IPublisherRepository
    {
        public Publisher GetSingle(int publisherId)
        {
            var query = GetAll().FirstOrDefault(x => x.PublisherID == publisherId);
            return query;
        }
    }
}
