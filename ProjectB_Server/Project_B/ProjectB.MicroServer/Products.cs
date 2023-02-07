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
    public static class Products
    {
        [FunctionName("Products")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", Route = "Products/{action}/{Value?}/{Value2?}")] HttpRequest req,
        string action, string Value, string Value2, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            string requestBody;
            string responseMessage;
            switch (action)
            {
                case "getAllProductsFromDB":
                    responseMessage = JsonConvert.SerializeObject(MainManager.Instance.ProductsManager.ShowAllProductsFromDB());
                    return new OkObjectResult(responseMessage);

                case "ProductPost":
                    ProductsModel ProductsData = new ProductsModel();
                    ProductsData = System.Text.Json.JsonSerializer.Deserialize<ProductsModel>(req.Body);
                    MainManager.Instance.ProductsManager.SendProductToDB(ProductsData);
                    break;


                default:
                    break;
            }

            return null;
        }
    }
}
