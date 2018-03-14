using System;

namespace KPMG.PressfordConsulting.EntityFramework.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
