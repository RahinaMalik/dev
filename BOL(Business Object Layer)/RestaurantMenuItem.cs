//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL_Business_Object_Layer_
{
    using System;
    using System.Collections.Generic;
    
    public partial class RestaurantMenuItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RestaurantMenuItem()
        {
            this.OrderTables = new HashSet<OrderTable>();
        }
    
        public int MenuItemID { get; set; }
        public int CuisineID { get; set; }
        public string ItemName { get; set; }
        public Nullable<double> ItemPrice { get; set; }
    
        public virtual Cuisine Cuisine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderTable> OrderTables { get; set; }
    }
}