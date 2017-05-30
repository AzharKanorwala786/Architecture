using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Core.Models;

namespace Data.Data
{
    public class DBInitalize :DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Product.Add(new Product { Id = 1, Name = "Galaxy S8", Price = 300,CategoryId = 1 });

            context.Category.Add(new Category { Id = 1, Name = "Mobiles" });

            base.Seed(context);

            context.SaveChanges();
        }
    }
}
