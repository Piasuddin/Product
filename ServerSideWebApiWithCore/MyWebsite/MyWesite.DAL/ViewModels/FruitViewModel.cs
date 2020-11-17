using System;
using System.Collections.Generic;
using System.Text;

namespace MyWesite.DAL.ViewModels
{
    public class ProductViewModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
    public class ProductDetailsViewModel: ProductViewModel
    {
        public string CategoryName { get; set; }
    }
}
