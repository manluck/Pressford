using System;

namespace KPMG.PressfordConsulting.Models
{
    public class ArticleModel
    {
        public int ArticleId { get; }
        public string Title { get; }
        public string Body { get; }
        public DateTime PublishDate { get; }
        public int Likes { get; }

        public ArticleModel(int articleId, string title, string body, DateTime publishDate, int likes)
        {
            ArticleId = articleId;
            Title = title;
            Body = body;
            PublishDate = publishDate;
            Likes = likes;
        }
    }
}