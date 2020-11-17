using System;
using System.Collections.Generic;
using System.Text;

namespace MyWesite.DAL.ViewModels
{
    public class CategoryViewModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public long? ParentCategoryId { get; set; }
        public long? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
