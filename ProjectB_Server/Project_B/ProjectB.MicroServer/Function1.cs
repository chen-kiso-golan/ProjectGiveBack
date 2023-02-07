//using System;
//using System.IO;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.WebJobs;
//using Microsoft.Azure.WebJobs.Extensions.Http;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using RestSharp;
//using ProjectB.Model;
//using ProjectB.Entities;
//using System.Text.Json;
//using Microsoft.SqlServer.Server;

//namespace ProjectB.MicroServer
//{
//    public static class Function1
//    {
//        [FunctionName("Function1")]
//        public static async Task<IActionResult> Run(
//        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", Route = "Users/{action}/{Value?}/{Value2?}")] HttpRequest req,
//        string action, string Value, string Value2, ILogger log)
//        {
//            log.LogInformation("C# HTTP trigger function processed a request.");


//            string requestBody;
//            string responseMessage;
//            switch (action)
//            {
             


//                //-----------------------------------------------Products
               

//                //-----------------------------------------------SocialActivist
               




//                default:
//                    break;

//            }


//            return null;
//        }
//    }
//}
