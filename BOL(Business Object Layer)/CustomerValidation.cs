using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL_Business_Object_Layer_
{
    public class CustomerValidation
    {
        public int CustomerID { get; set; }
        [Required]
        public int RestaurantID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string MobileNo { get; set; }
    }
}
