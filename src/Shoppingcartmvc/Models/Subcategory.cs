using System;
using System.Collections.Generic;

namespace Shoppingcartmvc.Models
{
    public partial class Subcategory
    {
        public int Id { get; set; }
        public string Parentid { get; set; }
        public string Name { get; set; }
        public string Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifieddate { get; set; }
        public string Modifiedby { get; set; }
    }
}
