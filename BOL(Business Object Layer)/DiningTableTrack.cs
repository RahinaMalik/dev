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
    
    public partial class DiningTableTrack
    {
        public int DiningTableTrackID { get; set; }
        public int DiningTableID { get; set; }
        public string TableStatus { get; set; }
    
        public virtual DiningTable DiningTable { get; set; }
    }
}
