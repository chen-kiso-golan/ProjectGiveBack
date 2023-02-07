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
    public static class Orders
    {
        [FunctionName("Orders")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", Route = "Orders/{action}/{Value?}/{Value2?}")] HttpRequest req,
        string action, string Value, string Value2, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            string requestBody;
            string responseMessage;
            switch (action)
            {
                case "getAllOrdersFromDB":
                    responseMessage = JsonConvert.SerializeObject(MainManager.Instance.OrdersManager.ShowAllOrdersFromDB());
                    return new OkObjectResult(responseMessage);

                case "OrderPost":
                    ProductsModel OrderData = new ProductsModel();
                    OrderData = System.Text.Json.JsonSerializer.Deserialize<ProductsModel>(req.Body);
                    MainManager.Instance.OrdersManager.SendOrderToDB(OrderData);
                    break;

                case "UpdateOrderIsSent":
                    requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                    OrdersModel Order = System.Text.Json.JsonSerializer.Deserialize<OrdersModel>(requestBody);
                    MainManager.Instance.OrdersManager.UpdateOrderIsSent(Order);
                    break;

                default:
                    break;
            }

            return null;
        }
    }
}
