using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectB.Model;
using ProjectB.Dal;
using System.Data;

namespace ProjectB.Data.Sql
{
    public class DS_Twitter
    {
        public void UpdateTweetAndSA_MoneyQuery(TweetsModel newTweet)
        {
            string updateQuery = "if not exists(select Code from Tweets where Tweet_id like '" + newTweet.Tweet_id + "')\r\n\tbegin\r\n\t\tinsert into Tweets values (" + newTweet.SA_code + ", " + newTweet.Campaign_code + ", '" + newTweet.Hashtag + "', '" + newTweet.Link_URL + "', '" + newTweet.Tweet_Content + "', getdate(), '" + newTweet.Tweet_id + "')\r\n\t\tupdate Social_Activist set Money = Money + 10 where Code = " + newTweet.SA_code + "\r\n\tend";
            SqlDB.WriteToDB(updateQuery);
        }

        public DataTable Send_getSocialActivistListQuery()
        {
            return SqlDB.ReadFormDB("select * from Social_Activist");
        }

        public DataTable Send_getAllCampaignsListQuery()
        {
            return SqlDB.ReadFormDB("select * from Campaigns");
        }
        
        public DataTable ReadAllTwitsFromDB()
        {
            string SQLquery = "select * from Tweets";
            return SqlDB.ReadFormDB(SQLquery);
        }



    }
}
