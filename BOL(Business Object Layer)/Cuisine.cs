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
    
    public partial class Cuisine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cuisine()
        {
            this.RestaurantMenuItems = new HashSet<RestaurantMenuItem>();
        }
    
        public int CuisineID { get; set; }
        public int RestaurantID { get; set; }
        public string CuisineName { get; set; }
    
        public virtual Restaurant Restaurant { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestaurantMenuItem> RestaurantMenuItems { get; set; }
    }
}
