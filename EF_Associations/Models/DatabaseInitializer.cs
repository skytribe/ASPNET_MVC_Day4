using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF_Associations.Models
{
    public enum CategoryType { Action, Comedy, Documentary }

    public class DatabaseInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            // This will seed the categories and movies collection

            var categories = new List<Category> {
                new Category {Id=CategoryType.Action , 
                              Name="Action", 
                              Movies = new List<Movie> {}},

                new Category {Id=CategoryType.Comedy , 
                              Name="Comedy",  
                              Movies =  new List<Movie> {}},

                new Category {Id=CategoryType.Documentary , 
                              Name="Space", 
                              Movies =  new List<Movie> {}}
            };


            //Create Movies
            var m = new Movie { Name = "Star Wars", Director = "Lucas" };
            var m2 = new Movie { Name = "Memento", Director = "Nolan" };
            var m3 = new Movie { Name = "King Kong", Director = "Jackson" };

            //Add Movies to Categories
            categories[(int)CategoryType.Action].Movies.Add(m);
            categories[(int)CategoryType.Comedy].Movies.Add(m2);
            categories[(int)CategoryType.Action].Movies.Add(m3);




            categories.ForEach(c => context.Categories.Add(c));



        }
    }
}