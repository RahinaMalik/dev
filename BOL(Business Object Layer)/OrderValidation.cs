using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL_Business_Object_Layer_
{
    public class OrderValidation
    {
        public int OrderID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public System.DateTime OrderDate { get; set; }
        [Required]
        public int RestaurantID { get; set; }
        [Required]
        public int MenuItemID { get; set; }
        [Required]
        public int ItemQuantity { get; set; }
        [Required]
        public double OrderAmount { get; set; }
        [Required]
        public int DiningTableId { get; set; }
    }
}
