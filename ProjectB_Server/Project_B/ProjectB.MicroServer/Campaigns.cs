using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectB.Entities;
using ProjectB.Model;
using ProjectB.Entities.command;
using DotNetOpenAuth.OpenId;

namespace ProjectB.MicroServer
{
    public static class Campaigns
    {
        [FunctionName("Campaigns")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", Route = "Campaigns/{action}/{Value?}/{Value2?}")] HttpRequest req,
        string action, string Value, string Value2, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string dictionaryKey = action;
            string requestBody;
            string responseMessage;

            ICommand commmand = MainManager.Instance.CommandManager.CommandList[dictionaryKey];


            switch (action)
            {
                case "getAllCampaignsFromDB":
                    requestBody = await req.ReadAsStringAsync();
                    return new OkObjectResult(commmand.Execute(Value, requestBody));
                    //responseMessage = JsonConvert.SerializeObject(MainManager.Instance.CampaignsManager.ShowAllCampaignsFromDB());
                    //return new OkObjectResult(responseMessage);

                case "getAllCampaignNamesFromDB":
                    responseMessage = JsonConvert.SerializeObject(MainManager.Instance.CampaignsManager.ShowAllCampaignNamesFromDB());
                    return new OkObjectResult(responseMessage);

                case "getCampaignCodeByNameFromDB":
                    responseMessage = System.Text.Json.JsonSerializer.Serialize(MainManager.Instance.CampaignsManager.ShowCampaignCodeByNameFromDB(Value));
                    return new OkObjectResult(responseMessage);

                case "CampaignPost":
                    CampaignsModel CampaignsData = new CampaignsModel();
                    CampaignsData = System.Text.Json.JsonSerializer.Deserialize<CampaignsModel>(req.Body);
                    MainManager.Instance.CampaignsManager.SendCampaignToDB(CampaignsData);
                    break;

                case "UpdateCampaign":
                    requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                    CampaignsModel Campaign = System.Text.Json.JsonSerializer.Deserialize<CampaignsModel>(requestBody);
                    MainManager.Instance.CampaignsManager.UpdateCampaign(Campaign);
                    break;

                case "deleteCampaign":
                    MainManager.Instance.CampaignsManager.DeleteCampaign(Value);
                    break;

                default:
                    break;
            }

            return null;
        }
    }
}

//public static class Campaign
//{
//    [FunctionName("ProLobby")]
//    public static async Task<IActionResult> Run(
//        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", Route = "Campaigns/{action}/{Identifier?}")] HttpRequest req,
//        string action, string Identifier, ILogger log)
//    {
//        log.LogInformation("C# HTTP trigger function processed a request.");

//        string dictionaryKey = "Campaign." + action;
//        string requestBody;

//        ICommand commmand = MainManager.Instance.commandManager.CommandList[dictionaryKey];
//        try
//        {
//            if (commmand != null)
//            {

//                requestBody = await req.ReadAsStringAsync();
//                return new OkObjectResult(commmand.ExecuteCommand(Identifier, requestBody));
//            }
//            else
//            {

//                MainManager.Instance.myLogger.LogError("Problam Was Found With the Command", LoggingLibrary.LogLevel.Error);
//                return new BadRequestObjectResult("Problam Was Found");
//            }
//        }
//        catch (Exception ex)
//        {
//            MainManager.Instance.myLogger.LogException("Problam Was Found in Campaign Azure File", ex);
//            return new BadRequestObjectResult("Problam Was Found");
//        }


//    }
//}
