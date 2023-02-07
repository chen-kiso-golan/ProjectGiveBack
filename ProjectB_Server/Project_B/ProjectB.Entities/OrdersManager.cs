using ProjectB.Data.Sql;
using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Entities
{
    public class OrdersManager
    {
        public DataTable Orders = new DataTable();
        public DataTable ShowAllOrdersFromDB()
        {
            Orders.Clear();
            DS_Orders DS_Orders = new DS_Orders();
            return Orders = DS_Orders.ReadAllOrdersFromDB();
        }



        public void SendOrderToDB(ProductsModel data)
        {
            DS_Orders DS_Orders = new DS_Orders();
            DS_Orders.EnterOrderToDB(data);
        }



        public void UpdateOrderIsSent(OrdersModel Order)
        {
            DS_Orders DS_Orders = new DS_Orders();
            DS_Orders.UpdateOrderIsSentInDB(Order);
        }
    }
}
