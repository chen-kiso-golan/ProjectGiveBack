using ProjectB.Data.Sql;
using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ProjectB.Entities
{
    public class NonProfitOrganizationManager: BaseEntity
    {
        public NonProfitOrganizationManager(LogManager log) : base(log) { }



        public DataTable NpoTable = new DataTable();
        public DataTable ShowAllNpoFromDB()
        {
            try
            {
                Log.LogEvent(@"Entities \ NonProfitOrganizationManager \ ShowAllNpoFromDB ran Successfully - ");
                NpoTable.Clear();
                DS_NonProfitOrganization DS_NonProfitOrganization = new DS_NonProfitOrganization();
                return NpoTable = DS_NonProfitOrganization.ReadAllNpoFromDB();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return NpoTable;
        }



        public DataTable NpoEmails = new DataTable();
        public DataTable ShowAllNpoEmailsFromDB()
        {
            try
            {
                Log.LogEvent(@"Entities \ NonProfitOrganizationManager \ ShowAllNpoEmailsFromDB ran Successfully - ");
                NpoEmails.Clear();
                DS_NonProfitOrganization DS_NonProfitOrganization = new DS_NonProfitOrganization();
                return NpoEmails = DS_NonProfitOrganization.ReadAllNpoEmailsFromDB();
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
            return NpoEmails;
        }



        public void SendNpoToDB(NonProfitOrganizationModel form)
        {
            try
            {
                Log.LogEvent(@"Entities \ NonProfitOrganizationManager \ SendNpoToDB ran Successfully - ");
                DS_NonProfitOrganization DS_NonProfitOrganization = new DS_NonProfitOrganization();
                DS_NonProfitOrganization.EnterNpoToDB(form);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }


        public void SendNpoCodeByEmailToDB(string data)
        { 
            try
            {
                Log.LogEvent(@"Entities \ NonProfitOrganizationManager \ SendNpoCodeByEmailToDB ran Successfully - ");
                DS_NonProfitOrganization DS_NonProfitOrganization = new DS_NonProfitOrganization();
                DS_NonProfitOrganization.EnterNpoCodeByEmailToDB(data);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }
    }
}
