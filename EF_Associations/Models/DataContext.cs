using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF_Associations.Models
{
    public class DataContext: DbContext
    {
        //Only need to track the root class 
        //ie category -< movies -< Actions
        public IDbSet<Category > Categories { get; set; }

        public DataContext()
        {
            Database.SetInitializer(new DatabaseInitializer());  // This will call the database seed
            this.Configuration.LazyLoadingEnabled = false;

 

        }
    }
}