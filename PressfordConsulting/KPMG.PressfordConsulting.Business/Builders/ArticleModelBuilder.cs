using KPMG.PressfordConsulting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.PressfordConsulting.Data.Builders
{
    public class ArticleModelBuilder
    {
        private int _articleId;
        private string _title ;
        private string _body ;
        private DateTime _publishDate ;
        private int _likes ;

        private ArticleModelBuilder(int articleId, string title, string body, DateTime publishDate, int likes)
        {
            _articleId = articleId;
            _title = title;
            _body = body;
            _publishDate = publishDate;
            _likes = likes;
        }

        public static ArticleModelBuilder Default()
        {
            return new ArticleModelBuilder(0, string.Empty, string.Empty, DateTime.Now, 0);
        }

        public ArticleModelBuilder ArticleId(int articleId)
        {
            _articleId = articleId;
            return this;
        }

        public ArticleModelBuilder Title(string title)
        {
            _title = title;
            return this;
        }

        public ArticleModelBuilder Body(string body)
        {
            _body = body;
            return this;
        }

        public ArticleModelBuilder PublishedDate(DateTime publishedDate)
        {
            _publishDate = publishedDate;
            return this;
        }

        public ArticleModelBuilder Likes(int likes)
        {
            _likes = likes;
            return this;
        }

        public ArticleModel Build()
        {
            return new ArticleModel(_articleId, _title, _body, _publishDate, _likes);
        }
    }
}
