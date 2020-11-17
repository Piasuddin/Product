using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWesite.DAL.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Category Categories { get; set; }
    }
}
