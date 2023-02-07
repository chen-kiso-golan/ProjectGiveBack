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
    public class DS_Products
    {

        public DataTable ReadAllProductsFromDB()
        {
            string SQLquery = "select * from Products";
            return SqlDB.ReadFormDB(SQLquery);
        }



        public void EnterProductToDB(ProductsModel form)
        {
            string SQLquery = "insert into Products values ('" + form.Name + "','" + form.Price + "','" + form.Units_In_Stock + "' ,'" + form.BC_code + "','" + form.Campaign_code + "','" + form.Image + "')";
            SqlDB.WriteToDB(SQLquery);
        }

    }
}
