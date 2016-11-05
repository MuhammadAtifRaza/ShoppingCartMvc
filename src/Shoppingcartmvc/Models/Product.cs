using System;
using System.Collections.Generic;

namespace Shoppingcartmvc.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Subcategory { get; set; }
        public string Parentcategory { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifieddate { get; set; }
        public string Modifiedby { get; set; }
    }
}
