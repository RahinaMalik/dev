using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL_Business_Object_Layer_
{
    public class BillsValidation
    {
        public int BillsID { get; set; }

        [Required]
        public int OrderID { get; set; }
        [Required]
        public int RestaurantID { get; set; }
        [Required]
        public double BillAmount { get; set; }
        [Required]
        public int CustomerID { get; set; }
    }
}
