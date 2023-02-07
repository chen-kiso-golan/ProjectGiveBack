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
    public class SocialActivistManager
    {
        public DataTable ActivistsTable = new DataTable();
        public DataTable ShowAllActivistsFromDB()
        {
            ActivistsTable.Clear();
            DS_SocialActivist DS_SocialActivist = new DS_SocialActivist();
            return ActivistsTable = DS_SocialActivist.ReadAllActivistsFromDB();
        }


        public void SendActivistToDB(SocialActivistModel form)
        {
            DS_SocialActivist DS_SocialActivist = new DS_SocialActivist();
            DS_SocialActivist.EnterActivistToDB(form);
        }
    }
}
