using ProjectB.Dal;
using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Data.Sql
{
    public class DS_ContactUs
    {
        public void EnterContactUsToDB(ContactUsModel form)
        {
            string SQLquery = "insert into Contact_Us values ('" + form.Name + "','" + form.Message + "','" + form.Phone + "','" + form.Email + "',getdate())";
            SqlDB.WriteToDB(SQLquery);
        }
    }
}
