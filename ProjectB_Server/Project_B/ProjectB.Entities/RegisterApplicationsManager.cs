using ProjectB.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Entities
{
    public class RegisterApplicationsManager
    {


        public DataTable userinfo = new DataTable();
        public DataTable ShowUserInfoFromDB(string email, string role)
        {
            userinfo.Clear();
            DS_RegisterApplications DS_RegisterApplications = new DS_RegisterApplications();
            return userinfo = DS_RegisterApplications.ReadUserInfoFromDB(email, role);
        }
    }
}
