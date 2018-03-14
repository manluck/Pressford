using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPMG.PressfordConsulting.EntityFramework.Models
{
    public class Publisher
    {
        [ForeignKey("Employee")]
        public int PublisherID { get; set; }
        public string AliasName { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
