using KPMG.PressfordConsulting.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.PressfordConsulting.EntityFramework.DAL
{
    public class PressfordConsultingInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PressfordConsultingDbContext>
    {
        protected override void Seed(PressfordConsultingDbContext context)
        {
            var employees = new List<Employee>
            {
            new Employee{FirstName="James",LastName="Anderson",JoiningDate=DateTime.Parse("2018-02-01")},
            new Employee{FirstName="Virat",LastName="Kohli",JoiningDate=DateTime.Parse("2018-02-03")},
            new Employee{FirstName="Joe",LastName="Root",JoiningDate=DateTime.Parse("2018-02-04")},
            new Employee{FirstName="Nasser",LastName="Hussain",JoiningDate=DateTime.Parse("2018-02-10")},
            };

            employees.ForEach(x => context.Employees.Add(x));
            context.SaveChanges();

            //var publishers = new List<Publisher>
            //{
            //new Publisher{AliasName="Jamy"},
            //new Publisher{AliasName="Jamy"},
            //};
            //publishers.ForEach(x => context.Publishers.Add(x));
            //context.SaveChanges();
            context.Employees.Where(x => x.FirstName == "James").ToList().
                ForEach(x => context.Publishers.Add(new Publisher { AliasName = "Jamy", Employee = x }));
            context.SaveChanges();

            var articles = new List<Article>
            {
            new Article{PublisherId=1,Title="First Lesson",Body="This is the First Lesson", PublishDate=DateTime.Parse("2018-03-01"),Likes=0},
            };
            articles.ForEach(x => context.Articles.Add(x));
            context.SaveChanges();
        }
    }
}
