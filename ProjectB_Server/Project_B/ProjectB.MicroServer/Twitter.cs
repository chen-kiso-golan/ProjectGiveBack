using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectB.Entities;
using RestSharp;
using System.Collections.Generic;
using Tweetinvi;

namespace ProjectB.MicroServer
{
    public static class Twitter
    {
        [FunctionName("Twitter")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "twitter/{action}/{value?}")] HttpRequest req, string action, string value, ILogger log)
        {
            object data;
            dynamic dataD;

            var userClient = new TwitterClient("GVJCrGcAszLmp8UhxU9zDxbdp", "Ru9lrw53v3GMd1YsNYZ9EYFAQHoFWAUditYpODGG6UPtnRbutZ", "1614624082481319936-0CYgQCagpgk7yVDPtqgxepESGy0iYM", "4xt1SZP0gRvSPyIlhVLjbWmT5n9GZvnWvcsijdqZlXtVM");

            var user = await userClient.Users.GetAuthenticatedUserAsync();
            Console.WriteLine(user);

            switch (action)
            {
                case "get-twitterPostForUpdate":

                    List<M_SocialActivist> SAList = MainManager.Instance.twitterManager.FillSocialActivistListFromDB();

                    List<M_Campaign> CampaignsList = MainManager.Instance.twitterManager.FillAllCampaignsListFromDB();

                    foreach (M_SocialActivist SA in SAList)
                    {
                        if (SA.Twitter_Name[0] == '@')
                        {
                            SA.Twitter_Name = SA.Twitter_Name.Substring(1);
                        }
                        foreach (M_Campaign Campaign in CampaignsList)
                        {
                            if (Campaign.HashTag[0] == '#')
                            {
                                Campaign.HashTag = Campaign.HashTag.Substring(1);
                            }

                            var tweetsURL = $"https://api.twitter.com/2/tweets/search/recent?query=from:{SA.Twitter_Name}%20%23SocialProject%20%23{Campaign.HashTag}";
                            var client = new RestClient(tweetsURL);
                            var request = new RestRequest("", Method.Get);
                            request.AddHeader("authorization", "Bearer AAAAAAAAAAAAAAAAAAAAAJ3ylAEAAAAA0muRGFRM09JIYksa%2FtxrUYgdaaE%3DcE5AmZjdexW8e42WeZ31SneoK9xPGg9b0KfUe3xCLOjEKX1aKt");
                            var response = client.Execute(request);
                            Console.WriteLine(response.Content);
                            if (response.IsSuccessful && !response.Content.Contains("\"result_count\":0"))
                            {
                                JObject json = JObject.Parse(response.Content);

                                JArray tweets = (JArray)json["data"];

                                foreach (var tweet in tweets)
                                {
                                    string tweetId = tweet["id"].ToString();
                                    string tweet_Content = tweet["text"].ToString();
                                    M_Tweets newTweet = new M_Tweets();
                                    newTweet.SA_code = SA.Code;
                                    newTweet.Campaign_code = Campaign.Code;
                                    newTweet.HashTag = Campaign.HashTag;
                                    newTweet.Landing_Page_URL = Campaign.Landing_Page_URL;
                                    newTweet.Tweet_Content = tweet_Content;
                                    newTweet.Tweet_id = tweetId;
                                    MainManager.Instance.twitterManager.UpdateTweetAndMoneyInDB(newTweet);
                                }
                            }
                        }
                    }
                    return null;

                case "post-MakeATweet":
                    dataD = JsonConvert.DeserializeObject(await new StreamReader(req.Body).ReadToEndAsync());
                    if (dataD.Quantity > 1)
                    {
                        var tweet = await userClient.Tweets.PublishTweetAsync("#" + dataD.Twitter_Name + " just donated " + dataD.Quantity + " " + dataD.ProductName + "`s to support the " + dataD.CampaignName + " campaign, thank you for your kind donatinon\nsearch #SocialProject and " + dataD.CampaignHashTag + " for more info!");
                        Console.WriteLine("You published the tweet : " + tweet);
                    }
                    else
                    {
                        var tweet = await userClient.Tweets.PublishTweetAsync("#" + dataD.Twitter_Name + " just donated " + dataD.ProductName + " to support the " + dataD.CampaignName + " campaign, thank you for your kind donatinon\nsearch #SocialProject and " + dataD.CampaignHashTag + " for more info!");
                        Console.WriteLine("You published the tweet : " + tweet);
                    }

                    break;

                default:
                    break;
            }

            return null;
        }
    }
}
