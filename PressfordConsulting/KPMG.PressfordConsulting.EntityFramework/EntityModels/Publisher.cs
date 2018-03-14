using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPMG.PressfordConsulting.EntityFramework.Models
{
    public class Publisher
    {
        public int PublisherID { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public string AliasName { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
