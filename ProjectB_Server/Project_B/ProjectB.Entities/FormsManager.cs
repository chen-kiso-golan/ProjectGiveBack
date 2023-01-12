using ProjectB.Data.Sql;
using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Entities
{
    public class FormsManager
    {
        public void SendContactUsToDB(ContactUsModel form)
        {
            DS_Forms dS_ContactUS = new DS_Forms();
            dS_ContactUS.EnterContactUsToDB(form);
        }

        public void SendActivistToDB(SocialActivistModel form)
        {
            DS_Forms dS_Activist = new DS_Forms();
            dS_Activist.EnterActivistToDB(form);
        }

        public void SendCompanyToDB(BuisnessCompaniesModel form)
        {
            DS_Forms dS_Company = new DS_Forms();
            dS_Company.EnterCompanyToDB(form);
        }

        public void SendNpoToDB(NonProfitOrganizationModel form)
        {
            DS_Forms dS_Npo = new DS_Forms();
            dS_Npo.EnterNpoToDB(form);
        }
        
        public void SendCampaignToDB(CampaignsModel form)
        {
            DS_Forms dS_Campaign = new DS_Forms();
            dS_Campaign.EnterCampaignToDB(form);
        }

        public void SendProductToDB(ProductsModel form)
        {
            DS_Forms dS_Product = new DS_Forms();
            dS_Product.EnterProductToDB(form);
        }
        
        public void SendNpoCodeByEmailToDB(string data)
        {
            DS_Forms dS_Campaign = new DS_Forms();
            dS_Campaign.EnterNpoCodeByEmailToDB(data);
        }
    }
}
