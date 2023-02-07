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
using ProjectB.Model;

namespace ProjectB.MicroServer
{
    public static class BuisnessCompanies
    {
        [FunctionName("BuisnessCompanies")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", Route = "BuisnessCompanies/{action}/{Value?}/{Value2?}")] HttpRequest req,
        string action, string Value, string Value2, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            string requestBody;
            string responseMessage;
            switch (action)
            {
                case "getAllCompaniesFromDB":
                    responseMessage = JsonConvert.SerializeObject(MainManager.Instance.BuisnessCompaniesManager.ShowAllCompaniesFromDB());
                    return new OkObjectResult(responseMessage);

                case "getAllCompaniesNamesFromDB":
                    responseMessage = JsonConvert.SerializeObject(MainManager.Instance.BuisnessCompaniesManager.ShowAllCompaniesNamesFromDB(Value));
                    return new OkObjectResult(responseMessage);

                case "getBcCodeByNameFromDB":
                    responseMessage = System.Text.Json.JsonSerializer.Serialize(MainManager.Instance.BuisnessCompaniesManager.ShowBcCodeByNameFromDB(Value));
                    return new OkObjectResult(responseMessage);

                case "getBcCodeByEmailFromDB":
                    responseMessage = System.Text.Json.JsonSerializer.Serialize(MainManager.Instance.BuisnessCompaniesManager.ShowBcCodeByEmailFromDB(Value));
                    return new OkObjectResult(responseMessage);

                case "CompanyPost":
                    BuisnessCompaniesModel CompanyData = new BuisnessCompaniesModel();
                    CompanyData = System.Text.Json.JsonSerializer.Deserialize<BuisnessCompaniesModel>(req.Body);
                    MainManager.Instance.BuisnessCompaniesManager.SendCompanyToDB(CompanyData);
                    break;

                default:
                    break;
            }

            return null;
        }
    }
}
