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

        public DataTable ReadAllActivistsFromDB()
        {
            string SQLquery = "select * from Social_Activist";
            return SqlDB.ReadFormDB(SQLquery);
        }

        public DataTable ReadAllCompaniesFromDB()
        {
            string SQLquery = "select * from Buisness_Companies";
            return SqlDB.ReadFormDB(SQLquery);
        }

        public DataTable ReadAllNpoFromDB()
        {
            string SQLquery = "select * from Non_Profit_Organizations";
            return SqlDB.ReadFormDB(SQLquery);
        }
        
        public DataTable ReadAllNpoEmailsFromDB()
        {
            string SQLquery = "select Email from Non_Profit_Organizations";
            return SqlDB.ReadFormDB(SQLquery);
        }
        
        public DataTable ReadAllCompaniesNamesFromDB()
        {
            string SQLquery = "select Name from Buisness_Companies";
            return SqlDB.ReadFormDB(SQLquery);
        }


    }
}
