using System;
using System.Collections.Generic;

namespace Shoppingcartmvc.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifieddate { get; set; }
        public string Modifiedby { get; set; }
        public string Email { get; set; }
    }
}
