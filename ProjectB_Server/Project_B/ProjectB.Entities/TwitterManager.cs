﻿using ProjectB.Data.Sql;
using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Entities
{
    public class TwitterManager
    {
        private DataTable getSocialActivist = new DataTable();

        public List<SocialActivistModel> FillSocialActivistListFromDB()
        {
            List<SocialActivistModel> SocialActivistList = new List<SocialActivistModel>();

            getSocialActivist.Clear();
            SocialActivistList.Clear();
            DS_Twitter DS_Twitter = new DS_Twitter();
            getSocialActivist = DS_Twitter.Send_getSocialActivistListQuery();
            int NumOfRows_Activist = getSocialActivist.Rows.Count;

            for (int i = 0; i < NumOfRows_Activist; i++)
            {
                SocialActivistModel SA = new SocialActivistModel();
                SA.Code = (int)getSocialActivist.Rows[i][0];
                SA.Twitter_Name = (string)getSocialActivist.Rows[i][7];
                SocialActivistList.Add(SA);
            }
            return SocialActivistList;
        }




        private DataTable getAllCampaigns = new DataTable();

        public List<CampaignsModel> FillAllCampaignsListFromDB()
        {
            List<CampaignsModel> CampaignList = new List<CampaignsModel>();

            getAllCampaigns.Clear();
            CampaignList.Clear();
            DS_Twitter DS_Twitter = new DS_Twitter();
            getAllCampaigns = DS_Twitter.Send_getAllCampaignsListQuery();
            int NumOfRows_Campaigns = getAllCampaigns.Rows.Count;

            for (int i = 0; i < NumOfRows_Campaigns; i++)
            {
                CampaignsModel Campaign = new CampaignsModel();
                Campaign.Code = (int)getAllCampaigns.Rows[i][0];
                Campaign.Hashtag = (string)getAllCampaigns.Rows[i][4];
                Campaign.Link_URL = (string)getAllCampaigns.Rows[i][3];
                CampaignList.Add(Campaign);
            }
            return CampaignList;
        }




        public void UpdateTweetAndMoneyInDB(TweetsModel newTweet)
        {
            DS_Twitter DS_Twitter = new DS_Twitter();
            DS_Twitter.UpdateTweetAndSA_MoneyQuery(newTweet);
        }

   




        private DataTable getCampaignByCode = new DataTable();

        public List<CampaignsModel> ShowCampaignNameAndHashtagByCodeFromDB(string code)
        {
            List<CampaignsModel> CampaignByCodeList = new List<CampaignsModel>();

            getCampaignByCode.Clear();
            CampaignByCodeList.Clear();
            DS_Twitter DS_Twitter = new DS_Twitter();
            getCampaignByCode = DS_Twitter.Send_getAllCampaignsListQuery();
            int NumOfRows_Campaigns = getCampaignByCode.Rows.Count;

            for (int i = 0; i < NumOfRows_Campaigns; i++)
            {
                if ((int)getCampaignByCode.Rows[i][0] == Int32.Parse(code))
                {
                    CampaignsModel Campaign = new CampaignsModel();
                    Campaign.Hashtag = (string)getCampaignByCode.Rows[i][4];
                    Campaign.Name = (string)getCampaignByCode.Rows[i][1];
                    CampaignByCodeList.Add(Campaign);
                }
               
            }
            return CampaignByCodeList;
        }



        
        public DataTable TwitsTable = new DataTable();
        public DataTable ShowAllTwitsFromDB()
        {
            TwitsTable.Clear();
            DS_Twitter DS_Twitter = new DS_Twitter();
            return TwitsTable = DS_Twitter.ReadAllTwitsFromDB();
        }
    }
}
