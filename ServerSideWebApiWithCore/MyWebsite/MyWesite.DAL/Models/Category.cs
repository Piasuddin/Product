using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWesite.DAL.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public long? ParentCategoryId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
