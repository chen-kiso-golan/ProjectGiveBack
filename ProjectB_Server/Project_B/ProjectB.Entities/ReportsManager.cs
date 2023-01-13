using ProjectB.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Entities
{
    public class ReportsManager
    {
        public DataTable CampaignsTable = new DataTable();
        public DataTable ShowAllCampaignsFromDB()
        {
            CampaignsTable.Clear();
            DS_Reports ds_Reports = new DS_Reports();
            return CampaignsTable = ds_Reports.ReadAllCampaignsFromDB();
        }

        public DataTable ProductsTable = new DataTable();
        public DataTable ShowAllProductsFromDB()
        {
            ProductsTable.Clear();
            DS_Reports ds_Reports = new DS_Reports();
            return ProductsTable = ds_Reports.ReadAllProductsFromDB();
        }

        public DataTable ActivistsTable = new DataTable();
        public DataTable ShowAllActivistsFromDB()
        {
            ActivistsTable.Clear();
            DS_Reports ds_Reports = new DS_Reports();
            return ActivistsTable = ds_Reports.ReadAllActivistsFromDB();
        }

        public DataTable CompaniesTable = new DataTable();
        public DataTable ShowAllCompaniesFromDB()
        {
            CompaniesTable.Clear();
            DS_Reports ds_Reports = new DS_Reports();
            return CompaniesTable = ds_Reports.ReadAllCompaniesFromDB();
        }

        public DataTable NpoTable = new DataTable();
        public DataTable ShowAllNpoFromDB()
        {
            NpoTable.Clear();
            DS_Reports ds_Reports = new DS_Reports();
            return NpoTable = ds_Reports.ReadAllNpoFromDB();
        }
        
        public DataTable NpoEmails = new DataTable();
        public DataTable ShowAllNpoEmailsFromDB()
        {
            NpoEmails.Clear();
            DS_Reports ds_Reports = new DS_Reports();
            return NpoEmails = ds_Reports.ReadAllNpoEmailsFromDB();
        }
        
        public DataTable CompaniesNames = new DataTable();
        public DataTable ShowAllCompaniesNamesFromDB()
        {
            CompaniesNames.Clear();
            DS_Reports ds_Reports = new DS_Reports();
            return CompaniesNames = ds_Reports.ReadAllCompaniesNamesFromDB();
        }
        
        public int ShowBcCodeByNameFromDB(string Name)
        {
            DS_Reports ds_Reports = new DS_Reports();
            return ds_Reports.ReadBcCodeByNameFromDB(Name);
        }

        public DataTable CampaignNames = new DataTable();
        public DataTable ShowAllCampaignNamesFromDB()
        {
            CampaignNames.Clear();
            DS_Reports ds_Reports = new DS_Reports();
            return CompaniesNames = ds_Reports.ReadCampaignNamesFromDB();
        }
        
        public int ShowCampaignCodeByNameFromDB(string Name)
        {
            DS_Reports ds_Reports = new DS_Reports();
            return ds_Reports.ReadCampaignCodeByNameFromDB(Name);
        }








    }
}
