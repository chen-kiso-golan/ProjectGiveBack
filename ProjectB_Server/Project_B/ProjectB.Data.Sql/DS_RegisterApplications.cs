using ProjectB.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Data.Sql
{
    public class DS_RegisterApplications
    {
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
