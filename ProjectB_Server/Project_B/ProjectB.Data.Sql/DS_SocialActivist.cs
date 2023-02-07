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
    public class DS_SocialActivist
    {
        public DataTable ReadAllActivistsFromDB()
        {
            string SQLquery = "select * from Social_Activist";
            return SqlDB.ReadFormDB(SQLquery);
        }


        public void EnterActivistToDB(SocialActivistModel form)
        {
            string SQLquery = "insert into Social_Activist values ('" + form.Name + "','" + form.Email + "','" + form.Address + "','" + form.PhoneNumber + "',0,'" + form.Image + "','" + form.Twitter_Name + "')";
            SqlDB.WriteToDB(SQLquery);
        }
    }
}
