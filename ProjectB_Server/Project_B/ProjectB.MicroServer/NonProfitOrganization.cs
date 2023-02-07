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
    public static class NonProfitOrganization
    {
        [FunctionName("NonProfitOrganization")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", Route = "NonProfitOrganization/{action}/{Value?}/{Value2?}")] HttpRequest req,
        string action, string Value, string Value2, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            string requestBody;
            string responseMessage;
            switch (action)
            {
                case "getAllNpoFromDB":
                    responseMessage = JsonConvert.SerializeObject(MainManager.Instance.NonProfitOrganizationManager.ShowAllNpoFromDB());
                    return new OkObjectResult(responseMessage);

                case "getAllNpoEmailsFromDB":
                    responseMessage = JsonConvert.SerializeObject(MainManager.Instance.NonProfitOrganizationManager.ShowAllNpoEmailsFromDB());
                    return new OkObjectResult(responseMessage);

                case "NpoPost":
                    NonProfitOrganizationModel NpoData = new NonProfitOrganizationModel();
                    NpoData = System.Text.Json.JsonSerializer.Deserialize<NonProfitOrganizationModel>(req.Body);
                    MainManager.Instance.NonProfitOrganizationManager.SendNpoToDB(NpoData);
                    break;

                case "NpoCodeByEmailPost":
                    //string NpoCodeByEmailData = System.Text.Json.JsonSerializer.Deserialize<string>(req.Body);
                    MainManager.Instance.NonProfitOrganizationManager.SendNpoCodeByEmailToDB(Value);
                    break;

                default:
                    break;
            }

            return null;
        }
    }
}
