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
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", Route = "Users/{action}/{IdNumber?}")] HttpRequest req,
        string action, string IdNumber, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            string requestBody;
            switch (action)
            {
                //GET FUNCTIONS
                case "get-role":

                    //var rolesURL = $"https://dev-yvfkvt7guh4kvmut.us.auth0.com/api/v2/users/{IdNumber}/roles";
                    //var client = new RestClient(rolesURL);
                    //var request = new RestRequest("", Method.Get);
                    //request.AddHeader("authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjdBR3I4SFdQdmx6MmFIQnVEZ3RkTyJ9.eyJpc3MiOiJodHRwczovL2Rldi15dmZrdnQ3Z3VoNGt2bXV0LnVzLmF1dGgwLmNvbS8iLCJzdWIiOiJXNk41UEFHNk01QUxhMFlpMTFuNGd0emhETks2dWFlOEBjbGllbnRzIiwiYXVkIjoiaHR0cHM6Ly9kZXYteXZma3Z0N2d1aDRrdm11dC51cy5hdXRoMC5jb20vYXBpL3YyLyIsImlhdCI6MTY3MzA2MDgzMywiZXhwIjoxNjc1NjUyODMzLCJhenAiOiJXNk41UEFHNk01QUxhMFlpMTFuNGd0emhETks2dWFlOCIsInNjb3BlIjoicmVhZDpjbGllbnRfZ3JhbnRzIGNyZWF0ZTpjbGllbnRfZ3JhbnRzIGRlbGV0ZTpjbGllbnRfZ3JhbnRzIHVwZGF0ZTpjbGllbnRfZ3JhbnRzIHJlYWQ6dXNlcnMgdXBkYXRlOnVzZXJzIGRlbGV0ZTp1c2VycyBjcmVhdGU6dXNlcnMgcmVhZDp1c2Vyc19hcHBfbWV0YWRhdGEgdXBkYXRlOnVzZXJzX2FwcF9tZXRhZGF0YSBkZWxldGU6dXNlcnNfYXBwX21ldGFkYXRhIGNyZWF0ZTp1c2Vyc19hcHBfbWV0YWRhdGEgcmVhZDp1c2VyX2N1c3RvbV9ibG9ja3MgY3JlYXRlOnVzZXJfY3VzdG9tX2Jsb2NrcyBkZWxldGU6dXNlcl9jdXN0b21fYmxvY2tzIGNyZWF0ZTp1c2VyX3RpY2tldHMgcmVhZDpjbGllbnRzIHVwZGF0ZTpjbGllbnRzIGRlbGV0ZTpjbGllbnRzIGNyZWF0ZTpjbGllbnRzIHJlYWQ6Y2xpZW50X2tleXMgdXBkYXRlOmNsaWVudF9rZXlzIGRlbGV0ZTpjbGllbnRfa2V5cyBjcmVhdGU6Y2xpZW50X2tleXMgcmVhZDpjb25uZWN0aW9ucyB1cGRhdGU6Y29ubmVjdGlvbnMgZGVsZXRlOmNvbm5lY3Rpb25zIGNyZWF0ZTpjb25uZWN0aW9ucyByZWFkOnJlc291cmNlX3NlcnZlcnMgdXBkYXRlOnJlc291cmNlX3NlcnZlcnMgZGVsZXRlOnJlc291cmNlX3NlcnZlcnMgY3JlYXRlOnJlc291cmNlX3NlcnZlcnMgcmVhZDpkZXZpY2VfY3JlZGVudGlhbHMgdXBkYXRlOmRldmljZV9jcmVkZW50aWFscyBkZWxldGU6ZGV2aWNlX2NyZWRlbnRpYWxzIGNyZWF0ZTpkZXZpY2VfY3JlZGVudGlhbHMgcmVhZDpydWxlcyB1cGRhdGU6cnVsZXMgZGVsZXRlOnJ1bGVzIGNyZWF0ZTpydWxlcyByZWFkOnJ1bGVzX2NvbmZpZ3MgdXBkYXRlOnJ1bGVzX2NvbmZpZ3MgZGVsZXRlOnJ1bGVzX2NvbmZpZ3MgcmVhZDpob29rcyB1cGRhdGU6aG9va3MgZGVsZXRlOmhvb2tzIGNyZWF0ZTpob29rcyByZWFkOmFjdGlvbnMgdXBkYXRlOmFjdGlvbnMgZGVsZXRlOmFjdGlvbnMgY3JlYXRlOmFjdGlvbnMgcmVhZDplbWFpbF9wcm92aWRlciB1cGRhdGU6ZW1haWxfcHJvdmlkZXIgZGVsZXRlOmVtYWlsX3Byb3ZpZGVyIGNyZWF0ZTplbWFpbF9wcm92aWRlciBibGFja2xpc3Q6dG9rZW5zIHJlYWQ6c3RhdHMgcmVhZDppbnNpZ2h0cyByZWFkOnRlbmFudF9zZXR0aW5ncyB1cGRhdGU6dGVuYW50X3NldHRpbmdzIHJlYWQ6bG9ncyByZWFkOmxvZ3NfdXNlcnMgcmVhZDpzaGllbGRzIGNyZWF0ZTpzaGllbGRzIHVwZGF0ZTpzaGllbGRzIGRlbGV0ZTpzaGllbGRzIHJlYWQ6YW5vbWFseV9ibG9ja3MgZGVsZXRlOmFub21hbHlfYmxvY2tzIHVwZGF0ZTp0cmlnZ2VycyByZWFkOnRyaWdnZXJzIHJlYWQ6Z3JhbnRzIGRlbGV0ZTpncmFudHMgcmVhZDpndWFyZGlhbl9mYWN0b3JzIHVwZGF0ZTpndWFyZGlhbl9mYWN0b3JzIHJlYWQ6Z3VhcmRpYW5fZW5yb2xsbWVudHMgZGVsZXRlOmd1YXJkaWFuX2Vucm9sbG1lbnRzIGNyZWF0ZTpndWFyZGlhbl9lbnJvbGxtZW50X3RpY2tldHMgcmVhZDp1c2VyX2lkcF90b2tlbnMgY3JlYXRlOnBhc3N3b3Jkc19jaGVja2luZ19qb2IgZGVsZXRlOnBhc3N3b3Jkc19jaGVja2luZ19qb2IgcmVhZDpjdXN0b21fZG9tYWlucyBkZWxldGU6Y3VzdG9tX2RvbWFpbnMgY3JlYXRlOmN1c3RvbV9kb21haW5zIHVwZGF0ZTpjdXN0b21fZG9tYWlucyByZWFkOmVtYWlsX3RlbXBsYXRlcyBjcmVhdGU6ZW1haWxfdGVtcGxhdGVzIHVwZGF0ZTplbWFpbF90ZW1wbGF0ZXMgcmVhZDptZmFfcG9saWNpZXMgdXBkYXRlOm1mYV9wb2xpY2llcyByZWFkOnJvbGVzIGNyZWF0ZTpyb2xlcyBkZWxldGU6cm9sZXMgdXBkYXRlOnJvbGVzIHJlYWQ6cHJvbXB0cyB1cGRhdGU6cHJvbXB0cyByZWFkOmJyYW5kaW5nIHVwZGF0ZTpicmFuZGluZyBkZWxldGU6YnJhbmRpbmcgcmVhZDpsb2dfc3RyZWFtcyBjcmVhdGU6bG9nX3N0cmVhbXMgZGVsZXRlOmxvZ19zdHJlYW1zIHVwZGF0ZTpsb2dfc3RyZWFtcyBjcmVhdGU6c2lnbmluZ19rZXlzIHJlYWQ6c2lnbmluZ19rZXlzIHVwZGF0ZTpzaWduaW5nX2tleXMgcmVhZDpsaW1pdHMgdXBkYXRlOmxpbWl0cyBjcmVhdGU6cm9sZV9tZW1iZXJzIHJlYWQ6cm9sZV9tZW1iZXJzIGRlbGV0ZTpyb2xlX21lbWJlcnMgcmVhZDplbnRpdGxlbWVudHMgcmVhZDphdHRhY2tfcHJvdGVjdGlvbiB1cGRhdGU6YXR0YWNrX3Byb3RlY3Rpb24gcmVhZDpvcmdhbml6YXRpb25zIHVwZGF0ZTpvcmdhbml6YXRpb25zIGNyZWF0ZTpvcmdhbml6YXRpb25zIGRlbGV0ZTpvcmdhbml6YXRpb25zIGNyZWF0ZTpvcmdhbml6YXRpb25fbWVtYmVycyByZWFkOm9yZ2FuaXphdGlvbl9tZW1iZXJzIGRlbGV0ZTpvcmdhbml6YXRpb25fbWVtYmVycyBjcmVhdGU6b3JnYW5pemF0aW9uX2Nvbm5lY3Rpb25zIHJlYWQ6b3JnYW5pemF0aW9uX2Nvbm5lY3Rpb25zIHVwZGF0ZTpvcmdhbml6YXRpb25fY29ubmVjdGlvbnMgZGVsZXRlOm9yZ2FuaXphdGlvbl9jb25uZWN0aW9ucyBjcmVhdGU6b3JnYW5pemF0aW9uX21lbWJlcl9yb2xlcyByZWFkOm9yZ2FuaXphdGlvbl9tZW1iZXJfcm9sZXMgZGVsZXRlOm9yZ2FuaXphdGlvbl9tZW1iZXJfcm9sZXMgY3JlYXRlOm9yZ2FuaXphdGlvbl9pbnZpdGF0aW9ucyByZWFkOm9yZ2FuaXphdGlvbl9pbnZpdGF0aW9ucyBkZWxldGU6b3JnYW5pemF0aW9uX2ludml0YXRpb25zIHJlYWQ6b3JnYW5pemF0aW9uc19zdW1tYXJ5IGNyZWF0ZTphY3Rpb25zX2xvZ19zZXNzaW9ucyBjcmVhdGU6YXV0aGVudGljYXRpb25fbWV0aG9kcyByZWFkOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMgdXBkYXRlOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMgZGVsZXRlOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMiLCJndHkiOiJjbGllbnQtY3JlZGVudGlhbHMifQ.vFQ_U1kcHYTM93H9SOtD4jNel744N6zNeWGRRkFqZXHZQziY8awBfQ65ZJoJgi4qY8pKmwWDWO1PYIHoRhZmGvaBO9PHE5WOEJLz_Gg5jaofPpi3PEFGSbVgLWed41sDnVM8YQbRnONp9rOyY3_QiJeydHozdhd6h7WVKlzO-8FA0ggL5vM9DOrfjh0ByETyZki710jcrIkj2FLBQjCQlAdAS9v3eCUpcJTnP6U9kNoC2XlZiECUVmNDZUVbPf-j9JqqH6pgjiFiSIOnUsxxdP7IBJptyqzbaTwJFrkmih4oDM6JS8HsJE5fUnBkaGThcUawSO54UgDbihRdTASMcA");
                    //var response = client.Execute(request);
                    //if (response.IsSuccessful)
                    //{
                    //    var json = JArray.Parse(response.Content);
                    //    return new OkObjectResult(json);
                    //}
                    //else
                    //{
                    //    return new NotFoundResult();
                    //}


                case "getAllCampaignsFromDB":
                    string responseMessage = JsonConvert.SerializeObject(MainManager.Instance.ReportsManager.ShowAllCampaignsFromDB());
                    return new OkObjectResult(responseMessage);



                //POST FUNCTIONS
                case "ContactUsPost":
                    ContactUsModel FormData = new ContactUsModel();
                    FormData = System.Text.Json.JsonSerializer.Deserialize<ContactUsModel>(req.Body);
                    MainManager.Instance.FormsManager.SendContactUsToDB(FormData);
                    break;

                case "ActivistPost":
                    SocialActivistModel ActivistData = new SocialActivistModel();
                    ActivistData = System.Text.Json.JsonSerializer.Deserialize<SocialActivistModel>(req.Body);
                    MainManager.Instance.FormsManager.SendActivistToDB(ActivistData);
                    break;
                    
                case "CompanyPost":
                    BuisnessCompaniesModel CompanyData = new BuisnessCompaniesModel();
                    CompanyData = System.Text.Json.JsonSerializer.Deserialize<BuisnessCompaniesModel>(req.Body);
                    MainManager.Instance.FormsManager.SendCompanyToDB(CompanyData);
                    break;
                    
                case "NpoPost":
                    NonProfitOrganizationModel NpoData = new NonProfitOrganizationModel();
                    NpoData = System.Text.Json.JsonSerializer.Deserialize<NonProfitOrganizationModel>(req.Body);
                    MainManager.Instance.FormsManager.SendNpoToDB(NpoData);
                    break;
                    
                case "CampaignPost":
                    CampaignsModel CampaignsData = new CampaignsModel();
                    CampaignsData = System.Text.Json.JsonSerializer.Deserialize<CampaignsModel>(req.Body);
                    MainManager.Instance.FormsManager.SendCampaignToDB(CampaignsData);
                    break;
                    
                case "ProductPost":
                    ProductsModel ProductsData = new ProductsModel();
                    ProductsData = System.Text.Json.JsonSerializer.Deserialize<ProductsModel>(req.Body);
                    MainManager.Instance.FormsManager.SendProductToDB(ProductsData);
                    break;


                //UPDATE FUNCTIONS
                case "update":
                    //requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                    //M_Products product = System.Text.Json.JsonSerializer.Deserialize<M_Products>(requestBody);
                    //MainManager.Instance.ProductManager1.Update_Product(product);
                    break;

                
                
                //DELETE FUNCTIONS
                case "deleteCampaign":
                    MainManager.Instance.ChangesManager.DeleteCampaign(Code);
                    break;

                default:
                    break;

            }


            return null;
        }
    }
}
