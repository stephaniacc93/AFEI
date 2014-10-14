//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AFEI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Provider
    {
        public Provider()
        {
            this.Histories = new HashSet<History>();
            this.Products = new HashSet<Product>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
    
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
