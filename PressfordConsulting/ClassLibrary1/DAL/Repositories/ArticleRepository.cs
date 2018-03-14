using KPMG.PressfordConsulting.EntityFramework.DAL;
using KPMG.PressfordConsulting.EntityFramework.Models;
using System.Linq;

namespace KPMG.PressfordConsulting.Data.Repositories
{
    public class ArticleRepository : GenericRepository<PressfordConsultingDbContext, Article>, IArticleRepository
    {
        public Article GetSingle(int articleId)
        {
            var query = GetAll().FirstOrDefault(x => x.ArticleID == articleId);
            return query;
        }
    }
}
