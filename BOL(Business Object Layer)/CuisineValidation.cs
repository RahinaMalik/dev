using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL_Business_Object_Layer_
{
    public class CuisineValidation
    {
        [Required(ErrorMessage = "Select Resturant is required")]
        public int RestaurantID { get; set; }

        [Required(ErrorMessage = "Cuisine Name is required")]
        public string CuisineName { get; set; }

        [MetadataType(typeof(CuisineValidation))]
        public partial class Cuisine
        {
        }
    }
}
