using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_Associations.Models
{
    public class Category
    {
        public CategoryType  Id { get; set; }
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }

    }
}