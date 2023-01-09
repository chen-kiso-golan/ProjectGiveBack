using ProjectB.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Data.Sql
{
    public class DS_Changes
    {
        public void DeleteCampaign(string Code)
        {
            string SqlQuery = "delete from Campaigns where Code = " + Code;
            SqlDB.WriteToDB(SqlQuery);
        }
    }
}
