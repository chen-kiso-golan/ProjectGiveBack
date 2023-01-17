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
        
        public DataTable ReadAllCompaniesNamesFromDB(string email)
        {
            string SQLquery = "select Name from Buisness_Companies where Email = '"+ email + "'";
            return SqlDB.ReadFormDB(SQLquery);
        }

        public int ReadBcCodeByNameFromDB(string Name)
        {
            string SQLquery = "select Code from Buisness_Companies where Name='"+ Name + "'";
            int code = (int)SqlDB.GetScalarFromDB(SQLquery);
            return code;
        }
        
        public int ReadBcCodeByEmailFromDB(string email)
        {
            string SQLquery = "select Code from Buisness_Companies where Email='" + email + "'";
            int code = (int)SqlDB.GetScalarFromDB(SQLquery);
            return code;
        }


        public DataTable ReadCampaignNamesFromDB()
        {
            string SQLquery = "select Name from Campaigns";
            return SqlDB.ReadFormDB(SQLquery);
        }
        
        public int ReadCampaignCodeByNameFromDB(string Name)
        {
            string SQLquery = "select Code from Campaigns where Name='" + Name + "'";
            int code = (int)SqlDB.GetScalarFromDB(SQLquery);
            return code;
        }
        
        public DataTable ReadAllOrdersFromDB()
        {
            string SQLquery = "select * from Orders";
            return SqlDB.ReadFormDB(SQLquery);
        }

        public DataTable ReadUserInfoFromDB(string email, string role)
        {
            if (role == "NPO")
            {
                return SqlDB.ReadFormDB("select * from Non_Profit_Organizations where Email='" + email + "' ");
            }
            else if (role == "BC")
            {
                return SqlDB.ReadFormDB("select * from Buisness_Companies where Email='" + email + "' ");
            }
            else
            {
                return SqlDB.ReadFormDB("select * from Social_Activist where Email='" + email + "' ");
            }
        }
        
    }
}
