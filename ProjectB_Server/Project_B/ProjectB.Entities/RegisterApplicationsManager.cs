using ProjectB.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ProjectB.Entities
{
    public class RegisterApplicationsManager: BaseEntity
    {

        public RegisterApplicationsManager(LogManager log) : base(log) { }




        public DataTable userinfo = new DataTable();
        public DataTable ShowUserInfoFromDB(string email, string role)
        {
            try
            {
                Log.LogEvent(@"Entities \ RegisterApplicationsManager \ ShowUserInfoFromDB ran Successfully - ");
                userinfo.Clear();
                DS_RegisterApplications DS_RegisterApplications = new DS_RegisterApplications();
                return userinfo = DS_RegisterApplications.ReadUserInfoFromDB(email, role);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return userinfo;
        }
    }
}
