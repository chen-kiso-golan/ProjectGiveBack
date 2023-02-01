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
using ProjectB.Model;

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
            string requestBody;
            string responseMessage;

            var userClient = new TwitterClient("GVJCrGcAszLmp8UhxU9zDxbdp", "Ru9lrw53v3GMd1YsNYZ9EYFAQHoFWAUditYpODGG6UPtnRbutZ", "1614624082481319936-0CYgQCagpgk7yVDPtqgxepESGy0iYM", "4xt1SZP0gRvSPyIlhVLjbWmT5n9GZvnWvcsijdqZlXtVM");

            var user = await userClient.Users.GetAuthenticatedUserAsync();
            Console.WriteLine(user);

            switch (action)
            {
                case "getAllTweetsToUpdateDB":

                    List<SocialActivistModel> SAList = MainManager.Instance.TwitterManager.FillSocialActivistListFromDB();

                    List<CampaignsModel> CampaignsList = MainManager.Instance.TwitterManager.FillAllCampaignsListFromDB();

                    foreach (SocialActivistModel SA in SAList)
                    {
                        if (SA.Twitter_Name[0] == '@')
                        {
                            SA.Twitter_Name = SA.Twitter_Name.Substring(1);
                        }
                        foreach (CampaignsModel Campaign in CampaignsList)
                        {
                            if (Campaign.Hashtag[0] == '#')
                            {
                                Campaign.Hashtag = Campaign.Hashtag.Substring(1);
                            }

                            var tweetsURL = $"https://api.twitter.com/2/tweets/search/recent?query=from:{SA.Twitter_Name}%20%23ProjectGiveBack%20%23{Campaign.Hashtag}";
                            var client = new RestClient(tweetsURL);
                            var request = new RestRequest("", Method.Get);
                            request.AddHeader("authorization", "Bearer AAAAAAAAAAAAAAAAAAAAAJ3ylAEAAAAAFbDmCEfjTCygLp0Z9ZamO2QScfk%3DURTsiJZ2SKqZhjdYUYBns23NXt1iuA7AJ60HOBfDrMtYouhquo");
                            var response = client.Execute(request);
                            Console.WriteLine(response.Content);
                            if (response.IsSuccessful && !response.Content.Contains("\"result_count\":0"))
                            {
                                JObject json = JObject.Parse(response.Content);

                                JArray tweets = (JArray)json["data"];

                                foreach (var tweet1 in tweets)
                                {
                                    string tweetId = tweet1["id"].ToString();
                                    string tweet_Content = tweet1["text"].ToString();
                                    TweetsModel newTweet = new TweetsModel();
                                    newTweet.SA_code = SA.Code;
                                    newTweet.Campaign_code = Campaign.Code;
                                    newTweet.Hashtag = Campaign.Hashtag;
                                    newTweet.Link_URL = Campaign.Link_URL;
                                    newTweet.Tweet_Content = tweet_Content;
                                    newTweet.Tweet_id = tweetId;
                                    MainManager.Instance.TwitterManager.UpdateTweetAndMoneyInDB(newTweet);
                                }
                            }
                        }
                    }
                    return null;

                case "post-MakeATweet":
                    dataD = JsonConvert.DeserializeObject(await new StreamReader(req.Body).ReadToEndAsync());
                    var tweet = await userClient.Tweets.PublishTweetAsync("#" + dataD.Twitter_Name + " just donated " + dataD.ProductName + " to support the " + dataD.CampaignName + " campaign, thank you for your kind donatinon\nsearch #ProjectGiveBack and " + dataD.CampaignHashtag + " for more info!");
                    Console.WriteLine("You published the tweet : " + tweet);

                    break;

                case "getCampaignNameAndHashtagByCodeFromDB":

                    List<CampaignsModel> CampaignsList2 = MainManager.Instance.TwitterManager.ShowCampaignNameAndHashtagByCodeFromDB(value);
                    responseMessage = System.Text.Json.JsonSerializer.Serialize(CampaignsList2);
                    return new OkObjectResult(responseMessage);

                default:
                    break;
            }

            return null;
        }
    }
}
