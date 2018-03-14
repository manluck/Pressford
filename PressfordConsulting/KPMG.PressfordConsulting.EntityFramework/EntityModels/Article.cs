using System;

namespace KPMG.PressfordConsulting.EntityFramework.Models
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }
        public int Likes { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
