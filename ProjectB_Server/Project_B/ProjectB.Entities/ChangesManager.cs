using ProjectB.Data.Sql;
using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Entities
{
    public class ChangesManager
    {
        public void DeleteCampaign(string Code)
        {
            DS_Changes dS_Changes = new DS_Changes();
            dS_Changes.DeleteCampaign(Code);
        }

        public void UpdateCampaign(CampaignsModel Campaign)
        {
            DS_Changes dS_Changes = new DS_Changes();
            dS_Changes.UpdateCampaignInDB(Campaign);
        }
        
        public void UpdateOrderIsSent(OrdersModel Order)
        {
            DS_Changes dS_Changes = new DS_Changes();
            dS_Changes.UpdateOrderIsSentInDB(Order);
        }
    }
}
