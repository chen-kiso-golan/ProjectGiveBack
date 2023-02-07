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
using RestSharp;
using ProjectB.Model;
using ProjectB.Entities;
using System.Text.Json;
using Microsoft.SqlServer.Server;

namespace ProjectB.MicroServer
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", Route = "Users/{action}/{Value?}/{Value2?}")] HttpRequest req,
        string action, string Value, string Value2, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            string requestBody;
            string responseMessage;
            switch (action)
            {
                //---------------------------------------RegisterApplications
                case "get-role":

                    var rolesURL = $"https://dev-bexlompeu36s5051.us.auth0.com/api/v2/users/{Value}/roles";
                    var client = new RestClient(rolesURL);
                    var request = new RestRequest("", Method.Get);
                    request.AddHeader("authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjBYNXVGZ1NBOWZsMnhjMk1BV1lxRyJ9.eyJpc3MiOiJodHRwczovL2Rldi1iZXhsb21wZXUzNnM1MDUxLnVzLmF1dGgwLmNvbS8iLCJzdWIiOiJ5NzVqZmVFQk1XSnBmYzhtcWkycEV4MXIwZHFOSllrN0BjbGllbnRzIiwiYXVkIjoiaHR0cHM6Ly9kZXYtYmV4bG9tcGV1MzZzNTA1MS51cy5hdXRoMC5jb20vYXBpL3YyLyIsImlhdCI6MTY3MzYzMzA3MCwiZXhwIjoxNjc2MjI1MDcwLCJhenAiOiJ5NzVqZmVFQk1XSnBmYzhtcWkycEV4MXIwZHFOSllrNyIsInNjb3BlIjoicmVhZDpjbGllbnRfZ3JhbnRzIGNyZWF0ZTpjbGllbnRfZ3JhbnRzIGRlbGV0ZTpjbGllbnRfZ3JhbnRzIHVwZGF0ZTpjbGllbnRfZ3JhbnRzIHJlYWQ6dXNlcnMgdXBkYXRlOnVzZXJzIGRlbGV0ZTp1c2VycyBjcmVhdGU6dXNlcnMgcmVhZDp1c2Vyc19hcHBfbWV0YWRhdGEgdXBkYXRlOnVzZXJzX2FwcF9tZXRhZGF0YSBkZWxldGU6dXNlcnNfYXBwX21ldGFkYXRhIGNyZWF0ZTp1c2Vyc19hcHBfbWV0YWRhdGEgcmVhZDp1c2VyX2N1c3RvbV9ibG9ja3MgY3JlYXRlOnVzZXJfY3VzdG9tX2Jsb2NrcyBkZWxldGU6dXNlcl9jdXN0b21fYmxvY2tzIGNyZWF0ZTp1c2VyX3RpY2tldHMgcmVhZDpjbGllbnRzIHVwZGF0ZTpjbGllbnRzIGRlbGV0ZTpjbGllbnRzIGNyZWF0ZTpjbGllbnRzIHJlYWQ6Y2xpZW50X2tleXMgdXBkYXRlOmNsaWVudF9rZXlzIGRlbGV0ZTpjbGllbnRfa2V5cyBjcmVhdGU6Y2xpZW50X2tleXMgcmVhZDpjb25uZWN0aW9ucyB1cGRhdGU6Y29ubmVjdGlvbnMgZGVsZXRlOmNvbm5lY3Rpb25zIGNyZWF0ZTpjb25uZWN0aW9ucyByZWFkOnJlc291cmNlX3NlcnZlcnMgdXBkYXRlOnJlc291cmNlX3NlcnZlcnMgZGVsZXRlOnJlc291cmNlX3NlcnZlcnMgY3JlYXRlOnJlc291cmNlX3NlcnZlcnMgcmVhZDpkZXZpY2VfY3JlZGVudGlhbHMgdXBkYXRlOmRldmljZV9jcmVkZW50aWFscyBkZWxldGU6ZGV2aWNlX2NyZWRlbnRpYWxzIGNyZWF0ZTpkZXZpY2VfY3JlZGVudGlhbHMgcmVhZDpydWxlcyB1cGRhdGU6cnVsZXMgZGVsZXRlOnJ1bGVzIGNyZWF0ZTpydWxlcyByZWFkOnJ1bGVzX2NvbmZpZ3MgdXBkYXRlOnJ1bGVzX2NvbmZpZ3MgZGVsZXRlOnJ1bGVzX2NvbmZpZ3MgcmVhZDpob29rcyB1cGRhdGU6aG9va3MgZGVsZXRlOmhvb2tzIGNyZWF0ZTpob29rcyByZWFkOmFjdGlvbnMgdXBkYXRlOmFjdGlvbnMgZGVsZXRlOmFjdGlvbnMgY3JlYXRlOmFjdGlvbnMgcmVhZDplbWFpbF9wcm92aWRlciB1cGRhdGU6ZW1haWxfcHJvdmlkZXIgZGVsZXRlOmVtYWlsX3Byb3ZpZGVyIGNyZWF0ZTplbWFpbF9wcm92aWRlciBibGFja2xpc3Q6dG9rZW5zIHJlYWQ6c3RhdHMgcmVhZDppbnNpZ2h0cyByZWFkOnRlbmFudF9zZXR0aW5ncyB1cGRhdGU6dGVuYW50X3NldHRpbmdzIHJlYWQ6bG9ncyByZWFkOmxvZ3NfdXNlcnMgcmVhZDpzaGllbGRzIGNyZWF0ZTpzaGllbGRzIHVwZGF0ZTpzaGllbGRzIGRlbGV0ZTpzaGllbGRzIHJlYWQ6YW5vbWFseV9ibG9ja3MgZGVsZXRlOmFub21hbHlfYmxvY2tzIHVwZGF0ZTp0cmlnZ2VycyByZWFkOnRyaWdnZXJzIHJlYWQ6Z3JhbnRzIGRlbGV0ZTpncmFudHMgcmVhZDpndWFyZGlhbl9mYWN0b3JzIHVwZGF0ZTpndWFyZGlhbl9mYWN0b3JzIHJlYWQ6Z3VhcmRpYW5fZW5yb2xsbWVudHMgZGVsZXRlOmd1YXJkaWFuX2Vucm9sbG1lbnRzIGNyZWF0ZTpndWFyZGlhbl9lbnJvbGxtZW50X3RpY2tldHMgcmVhZDp1c2VyX2lkcF90b2tlbnMgY3JlYXRlOnBhc3N3b3Jkc19jaGVja2luZ19qb2IgZGVsZXRlOnBhc3N3b3Jkc19jaGVja2luZ19qb2IgcmVhZDpjdXN0b21fZG9tYWlucyBkZWxldGU6Y3VzdG9tX2RvbWFpbnMgY3JlYXRlOmN1c3RvbV9kb21haW5zIHVwZGF0ZTpjdXN0b21fZG9tYWlucyByZWFkOmVtYWlsX3RlbXBsYXRlcyBjcmVhdGU6ZW1haWxfdGVtcGxhdGVzIHVwZGF0ZTplbWFpbF90ZW1wbGF0ZXMgcmVhZDptZmFfcG9saWNpZXMgdXBkYXRlOm1mYV9wb2xpY2llcyByZWFkOnJvbGVzIGNyZWF0ZTpyb2xlcyBkZWxldGU6cm9sZXMgdXBkYXRlOnJvbGVzIHJlYWQ6cHJvbXB0cyB1cGRhdGU6cHJvbXB0cyByZWFkOmJyYW5kaW5nIHVwZGF0ZTpicmFuZGluZyBkZWxldGU6YnJhbmRpbmcgcmVhZDpsb2dfc3RyZWFtcyBjcmVhdGU6bG9nX3N0cmVhbXMgZGVsZXRlOmxvZ19zdHJlYW1zIHVwZGF0ZTpsb2dfc3RyZWFtcyBjcmVhdGU6c2lnbmluZ19rZXlzIHJlYWQ6c2lnbmluZ19rZXlzIHVwZGF0ZTpzaWduaW5nX2tleXMgcmVhZDpsaW1pdHMgdXBkYXRlOmxpbWl0cyBjcmVhdGU6cm9sZV9tZW1iZXJzIHJlYWQ6cm9sZV9tZW1iZXJzIGRlbGV0ZTpyb2xlX21lbWJlcnMgcmVhZDplbnRpdGxlbWVudHMgcmVhZDphdHRhY2tfcHJvdGVjdGlvbiB1cGRhdGU6YXR0YWNrX3Byb3RlY3Rpb24gcmVhZDpvcmdhbml6YXRpb25zIHVwZGF0ZTpvcmdhbml6YXRpb25zIGNyZWF0ZTpvcmdhbml6YXRpb25zIGRlbGV0ZTpvcmdhbml6YXRpb25zIGNyZWF0ZTpvcmdhbml6YXRpb25fbWVtYmVycyByZWFkOm9yZ2FuaXphdGlvbl9tZW1iZXJzIGRlbGV0ZTpvcmdhbml6YXRpb25fbWVtYmVycyBjcmVhdGU6b3JnYW5pemF0aW9uX2Nvbm5lY3Rpb25zIHJlYWQ6b3JnYW5pemF0aW9uX2Nvbm5lY3Rpb25zIHVwZGF0ZTpvcmdhbml6YXRpb25fY29ubmVjdGlvbnMgZGVsZXRlOm9yZ2FuaXphdGlvbl9jb25uZWN0aW9ucyBjcmVhdGU6b3JnYW5pemF0aW9uX21lbWJlcl9yb2xlcyByZWFkOm9yZ2FuaXphdGlvbl9tZW1iZXJfcm9sZXMgZGVsZXRlOm9yZ2FuaXphdGlvbl9tZW1iZXJfcm9sZXMgY3JlYXRlOm9yZ2FuaXphdGlvbl9pbnZpdGF0aW9ucyByZWFkOm9yZ2FuaXphdGlvbl9pbnZpdGF0aW9ucyBkZWxldGU6b3JnYW5pemF0aW9uX2ludml0YXRpb25zIHJlYWQ6b3JnYW5pemF0aW9uc19zdW1tYXJ5IGNyZWF0ZTphY3Rpb25zX2xvZ19zZXNzaW9ucyBjcmVhdGU6YXV0aGVudGljYXRpb25fbWV0aG9kcyByZWFkOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMgdXBkYXRlOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMgZGVsZXRlOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMiLCJndHkiOiJjbGllbnQtY3JlZGVudGlhbHMifQ.RMO9xq6QWeBrCUedX5-gCXDsyyzAaKmR3NVFwT2j_dZKsqpmU5s3Ure1Gu73fm8U-T0Gte-xX-_IlMdJgEo0jzP8vF3zbyg_TceHxxS2dON1VM9mN8Uz_i8I57HmYIGP1OSfdhbomoLuO72yevc1UnlVX5DHu95ZZAHYAukdBgWbt97EX1r3TUW52HL937XGANkMu2y3sCA17z7-QsBv0JiY_mXKYFOpQXHAyRbXuhttmds5Uyweh9LbOqkeYQTJHDw9x59IlcSR286ElkeGml6SWRLDaZATbXiVqOFrCNayk_6J4Nz20VAyRs20KwYchutvNocqeIvfgl-k66tirw");
                    var response = client.Execute(request);
                    if (response.IsSuccessful)
                    {
                        var json = JArray.Parse(response.Content);
                        return new OkObjectResult(json);
                    }
                    else
                    {
                        return new NotFoundResult();
                    }

                case "get-UserInfoData":

                    responseMessage = JsonConvert.SerializeObject(MainManager.Instance.RegisterApplicationsManager.ShowUserInfoFromDB(Value, Value2));
                    return new OkObjectResult(responseMessage);


                //-----------------------------------------------BuisnessCompanies
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


                //-----------------------------------------------Campaigns
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


                //-----------------------------------------------ContactUs
                case "ContactUsPost":
                    ContactUsModel FormData = new ContactUsModel();
                    FormData = System.Text.Json.JsonSerializer.Deserialize<ContactUsModel>(req.Body);
                    MainManager.Instance.ContactUsManager.SendContactUsToDB(FormData);
                    break;


                //-----------------------------------------------NonProfitOrganization
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


                //-----------------------------------------------Orders
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


                //-----------------------------------------------Products
                case "getAllProductsFromDB":
                    responseMessage = JsonConvert.SerializeObject(MainManager.Instance.ProductsManager.ShowAllProductsFromDB());
                    return new OkObjectResult(responseMessage);

                case "ProductPost":
                    ProductsModel ProductsData = new ProductsModel();
                    ProductsData = System.Text.Json.JsonSerializer.Deserialize<ProductsModel>(req.Body);
                    MainManager.Instance.ProductsManager.SendProductToDB(ProductsData);
                    break;


                //-----------------------------------------------SocialActivist
                case "getAllActivistsFromDB":
                    responseMessage = JsonConvert.SerializeObject(MainManager.Instance.SocialActivistManager.ShowAllActivistsFromDB());
                    return new OkObjectResult(responseMessage);

                case "ActivistPost":
                    SocialActivistModel ActivistData = new SocialActivistModel();
                    ActivistData = System.Text.Json.JsonSerializer.Deserialize<SocialActivistModel>(req.Body);
                    MainManager.Instance.SocialActivistManager.SendActivistToDB(ActivistData);
                    break;





                default:
                    break;

            }


            return null;
        }
    }
}
