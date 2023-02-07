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
    public class CampaignsManager
    {

        public DataTable CampaignsTable = new DataTable();
        public DataTable ShowAllCampaignsFromDB()
        {
            CampaignsTable.Clear();
            DS_Campaigns DS_Campaigns = new DS_Campaigns();
            return CampaignsTable = DS_Campaigns.ReadAllCampaignsFromDB();
        }



        public DataTable CampaignNames = new DataTable();
        public DataTable ShowAllCampaignNamesFromDB()
        {
            CampaignNames.Clear();
            DS_Campaigns DS_Campaigns = new DS_Campaigns();
            return CompaniesNames = DS_Campaigns.ReadCampaignNamesFromDB();
        }


        public int ShowCampaignCodeByNameFromDB(string Name)
        {
            DS_Campaigns DS_Campaigns = new DS_Campaigns();
            return DS_Campaigns.ReadCampaignCodeByNameFromDB(Name);
        }


        public void SendCampaignToDB(CampaignsModel form)
        {
            DS_Campaigns DS_Campaigns = new DS_Campaigns();
            DS_Campaigns.EnterCampaignToDB(form);
        }


        public void DeleteCampaign(string Code)
        {
            DS_Campaigns DS_Campaigns = new DS_Campaigns();
            DS_Campaigns.DeleteCampaign(Code);
        }



        public void UpdateCampaign(CampaignsModel Campaign)
        {
            DS_Campaigns DS_Campaigns = new DS_Campaigns();
            DS_Campaigns.UpdateCampaignInDB(Campaign);
        }
    }
}
