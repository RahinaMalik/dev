using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL_Business_Object_Layer_;
using DAL_Data_Access_Layer_;

namespace BLL_Business_Logic_Layer_
{
    public class OrderBs
    {
        private OrderDb objDb;

        public OrderBs()
        {
            objDb = new OrderDb();
        }
        public void Insert(OrderTable order)
        {
            objDb.Insert(order);

        }
    }
}
