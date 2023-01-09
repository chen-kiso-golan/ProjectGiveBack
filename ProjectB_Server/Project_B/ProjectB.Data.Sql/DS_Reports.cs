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
    public class DS_Reports
    {
        public DataTable ReadAllCampaignsFromDB()
        {
            string SQLquery = "select * from Campaigns";
            return SqlDB.ReadFormDB(SQLquery);
        }

        public DataTable ReadAllProductsFromDB()
        {
            string SQLquery = "select * from Products";
            return SqlDB.ReadFormDB(SQLquery);
        }
    }
}
