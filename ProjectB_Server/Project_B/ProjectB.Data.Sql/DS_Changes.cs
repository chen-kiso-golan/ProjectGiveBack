using ProjectB.Dal;
using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Data.Sql
{
    public class DS_Changes
    {
        public void DeleteCampaign(string Code)
        {
            string SqlQuery = "delete from Campaigns where Code = " + Code;
            SqlDB.WriteToDB(SqlQuery);
        }

        public void UpdateCampaignInDB(CampaignsModel Campaign)
        {
            string SqlQuery = "update Campaigns set Hashtag = '" + Campaign.Hashtag + "', Is_Active = '" + Campaign.Is_Active + "', Image = '" + Campaign.Image + "', Link_URL = '" + Campaign.Link_URL + "', NPO_code = '" + Campaign.NPO_code.ToString() + "', Name = " + Campaign.Name + ", Email = " + Campaign.Email + " where Code = " + Campaign.Code.ToString();
            SqlDB.WriteToDB(SqlQuery);
        }

      
    }
}
