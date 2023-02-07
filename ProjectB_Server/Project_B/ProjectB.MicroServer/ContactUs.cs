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
    public static class ContactUs
    {
        [FunctionName("ContactUs")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", Route = "ContactUs/{action}/{Value?}/{Value2?}")] HttpRequest req,
        string action, string Value, string Value2, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            string requestBody;
            string responseMessage;
            switch (action)
            {
                case "ContactUsPost":
                    ContactUsModel FormData = new ContactUsModel();
                    FormData = System.Text.Json.JsonSerializer.Deserialize<ContactUsModel>(req.Body);
                    MainManager.Instance.ContactUsManager.SendContactUsToDB(FormData);
                    break;

                default:
                    break;
            }

            return null;
        }
    }
}
