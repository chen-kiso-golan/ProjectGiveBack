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
    public class ProductsManager
    {

        public DataTable ProductsTable = new DataTable();
        public DataTable ShowAllProductsFromDB()
        {
            ProductsTable.Clear();
            DS_Products DS_Products = new DS_Products();
            return ProductsTable = DS_Products.ReadAllProductsFromDB();
        }


        public void SendProductToDB(ProductsModel form)
        {
            DS_Products DS_Products = new DS_Products();
            DS_Products.EnterProductToDB(form);
        }
    }
}
