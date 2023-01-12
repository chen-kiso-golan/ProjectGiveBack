using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectB.Dal;

namespace ProjectB.Data.Sql
{
    public class DS_Forms
    {
        public void EnterContactUsToDB(ContactUsModel form)
        {
            string SQLquery = "insert into Contact_Us values ('"+ form.Name+ "','"+ form.Message + "','"+ form.Phone+ "','"+ form.Email+ "',getdate())";
            SqlDB.WriteToDB(SQLquery);
        }

        public void EnterActivistToDB(SocialActivistModel form)
        {
            string SQLquery = "insert into Social_Activist values ('" + form.Name + "','" + form.Email + "','" + form.Address + "','" + form.PhoneNumber + "',0,'" + form.Image + "')";
            SqlDB.WriteToDB(SQLquery);
        }

        public void EnterCompanyToDB(BuisnessCompaniesModel form)
        {
            string SQLquery = "insert into Buisness_Companies values ('" + form.Name + "','" + form.Email + "','" + form.Image + "')";
            SqlDB.WriteToDB(SQLquery);
        }

        public void EnterNpoToDB(NonProfitOrganizationModel form)
        {
            string SQLquery = "insert into Non_Profit_Organizations values ('" + form.Name + "','" + form.Email + "','" + form.Website_URL + "' ,'" + form.Image + "')";
            SqlDB.WriteToDB(SQLquery);
        }
        
         public void EnterCampaignToDB(CampaignsModel form)
        {
            string SQLquery = "insert into Campaigns values ('" + form.Name + "','" + form.Email + "','" + form.Link_URL + "' ,'" + form.Hashtag + "',null,'" + form.Image + "','" + form.Is_Active + "')";
            SqlDB.WriteToDB(SQLquery);
        }
        public void EnterProductToDB(ProductsModel form)
        {
            string SQLquery = "insert into Products values ('" + form.Name + "','" + form.Price + "','" + form.Units_In_Stock + "' ,'" + form.BC_code + "','" + form.Campaign_code + "','" + form.Image + "')";
            SqlDB.WriteToDB(SQLquery);
        }
        
        public void EnterNpoCodeByEmailToDB(string data)
        {
            string SQLquery = "update Campaigns set NPO_code = (SELECT Code FROM Non_Profit_Organizations WHERE Email = '"+ data + "') WHERE Email = '" + data + "'"; 
            SqlDB.WriteToDB(SQLquery);
        }
        
    
    }
}
