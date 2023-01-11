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

    





    }
}
