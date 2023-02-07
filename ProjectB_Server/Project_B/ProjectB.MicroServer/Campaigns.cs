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


            string requestBody;
            string responseMessage;
            switch (action)
            {
                case "getAllCampaignsFromDB":
                    responseMessage = JsonConvert.SerializeObject(MainManager.Instance.CampaignsManager.ShowAllCampaignsFromDB());
                    return new OkObjectResult(responseMessage);

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
