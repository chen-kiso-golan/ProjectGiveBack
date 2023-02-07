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
    public class NonProfitOrganizationManager
    {

        public DataTable NpoTable = new DataTable();
        public DataTable ShowAllNpoFromDB()
        {
            NpoTable.Clear();
            DS_NonProfitOrganization DS_NonProfitOrganization = new DS_NonProfitOrganization();
            return NpoTable = DS_NonProfitOrganization.ReadAllNpoFromDB();
        }



        public DataTable NpoEmails = new DataTable();
        public DataTable ShowAllNpoEmailsFromDB()
        {
            NpoEmails.Clear();
            DS_NonProfitOrganization DS_NonProfitOrganization = new DS_NonProfitOrganization();
            return NpoEmails = DS_NonProfitOrganization.ReadAllNpoEmailsFromDB();
        }



        public void SendNpoToDB(NonProfitOrganizationModel form)
        {
            DS_NonProfitOrganization DS_NonProfitOrganization = new DS_NonProfitOrganization();
            DS_NonProfitOrganization.EnterNpoToDB(form);
        }


        public void SendNpoCodeByEmailToDB(string data)
        {
            DS_NonProfitOrganization DS_NonProfitOrganization = new DS_NonProfitOrganization();
            DS_NonProfitOrganization.EnterNpoCodeByEmailToDB(data);
        }
    }
}
