using ProjectB.Data.Sql;
using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Entities
{
    public class ReportsManager
    {
        public void ShowAllCampaignsFromDB(CampaignsModel report)
        {
            DS_Forms dS_ContactUS = new DS_Forms();
            dS_ContactUS.EnterContactUsToDB(form);
        }
    }
}
