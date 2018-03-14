using KPMG.PressfordConsulting.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.PressfordConsulting.Data.Repositories
{
    public interface IArticleRepository : IGenericRepository<Article>
    {

        Article GetSingle(int articleId);
    }
}
