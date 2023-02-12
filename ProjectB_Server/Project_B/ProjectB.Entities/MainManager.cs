using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using static Utilities.LogManager;

namespace ProjectB.Entities
{
    public class MainManager 
    {

        private static readonly MainManager instance = new MainManager();
        public static MainManager Instance { get { return instance; } }


        public LogManager log;
        public TwitterManager TwitterManager;
        public BuisnessCompaniesManager BuisnessCompaniesManager;
        public CampaignsManager CampaignsManager;
        public ContactUsManager ContactUsManager;
        public NonProfitOrganizationManager NonProfitOrganizationManager;
        public OrdersManager OrdersManager;
        public ProductsManager ProductsManager;
        public SocialActivistManager SocialActivistManager;
        public RegisterApplicationsManager RegisterApplicationsManager;

        private MainManager()
        {
            AppDomainInitializer();
        }

        private void AppDomainInitializer()
        {
            try
            {
                log = new LogManager(providerType.File);
                TwitterManager = new TwitterManager(log);
                BuisnessCompaniesManager = new BuisnessCompaniesManager(log);
                CampaignsManager = new CampaignsManager(log);
                ContactUsManager = new ContactUsManager(log);
                NonProfitOrganizationManager = new NonProfitOrganizationManager(log);
                OrdersManager = new OrdersManager(log);
                ProductsManager = new ProductsManager(log);
                SocialActivistManager = new SocialActivistManager(log);
                RegisterApplicationsManager = new RegisterApplicationsManager(log);

                log.LogEvent(@"Entities \ MainManager \ AppDomainInitializer ran Successfully - ");
            }
            catch (Exception ex)
            {
                log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }
    }
}
