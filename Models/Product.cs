//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace clonePetService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<int> PC_Id { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> inventery { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Icon { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreateBy { get; set; }
    
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
