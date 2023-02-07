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
    public class DS_BuisnessCompanies
    {
        public DataTable ReadAllCompaniesFromDB()
        {
            string SQLquery = "select * from Buisness_Companies";
            return SqlDB.ReadFormDB(SQLquery);
        }


        public DataTable ReadAllCompaniesNamesFromDB(string email)
        {
            string SQLquery = "select Name from Buisness_Companies where Email = '" + email + "'";
            return SqlDB.ReadFormDB(SQLquery);
        }



        public int ReadBcCodeByNameFromDB(string Name)
        {
            string SQLquery = "select Code from Buisness_Companies where Name='" + Name + "'";
            int code = (int)SqlDB.GetScalarFromDB(SQLquery);
            return code;
        }



        public int ReadBcCodeByEmailFromDB(string email)
        {
            string SQLquery = "select Code from Buisness_Companies where Email='" + email + "'";
            int code = (int)SqlDB.GetScalarFromDB(SQLquery);
            return code;
        }


        public void EnterCompanyToDB(BuisnessCompaniesModel form)
        {
            string SQLquery = "insert into Buisness_Companies values ('" + form.Name + "','" + form.Email + "','" + form.Image + "')";
            SqlDB.WriteToDB(SQLquery);
        }
    }
}
