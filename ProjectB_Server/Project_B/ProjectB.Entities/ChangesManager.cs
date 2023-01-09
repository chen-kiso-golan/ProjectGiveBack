using ProjectB.Data.Sql;
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
    }
}
