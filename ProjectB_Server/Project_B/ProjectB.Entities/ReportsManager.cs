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





    }
}
