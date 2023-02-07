using ProjectB.Dal;
using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Data.Sql
{
    public class DS_Orders
    {

        public DataTable ReadAllOrdersFromDB()
        {
            string SQLquery = "select * from Orders";
            return SqlDB.ReadFormDB(SQLquery);
        }


        public void EnterOrderToDB(ProductsModel data)
        {
            string SQLquery = "insert into Orders values (null ,'" + data.BC_code + "','" + data.Campaign_code + "' ,'" + data.Code + "',getdate(),0)";
            SqlDB.WriteToDB(SQLquery);
        }


        public void UpdateOrderIsSentInDB(OrdersModel Order)
        {
            string SqlQuery = "update Orders set Is_Sent = 1 where Code = " + Order.Code.ToString();
            SqlDB.WriteToDB(SqlQuery);
        }
    }
}
