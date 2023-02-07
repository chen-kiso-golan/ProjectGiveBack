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
    public class DS_NonProfitOrganization
    {

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


        public void EnterNpoToDB(NonProfitOrganizationModel form)
        {
            string SQLquery = "insert into Non_Profit_Organizations values ('" + form.Name + "','" + form.Email + "','" + form.Website_URL + "' ,'" + form.Image + "')";
            SqlDB.WriteToDB(SQLquery);
        }


        public void EnterNpoCodeByEmailToDB(string data)
        {
            string SQLquery = "update Campaigns set NPO_code = (SELECT Code FROM Non_Profit_Organizations WHERE Email = '" + data + "') WHERE Email = '" + data + "'";
            SqlDB.WriteToDB(SQLquery);
        }



    }
}
