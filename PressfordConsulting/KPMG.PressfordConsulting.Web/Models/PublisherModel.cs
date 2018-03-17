using System.Collections.Generic;

namespace KPMG.PressfordConsulting.Models
{
    public class EmployeeModel
    {
        public IEnumerable<ArticleModel> Articles { get; set; }
        public int? PublisherId { get; set; }
        public string PublisherAliasName { get; set; }
        public int EmployeeId { get; set; }
        public bool IsPublisher { get; set; }
    }
}