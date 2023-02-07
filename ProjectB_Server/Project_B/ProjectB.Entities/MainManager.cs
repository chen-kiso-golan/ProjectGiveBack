using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ProjectB.Entities
{
    public class MainManager 
    {
        //BuisnessCompanies
        //Campaigns
        //ContactUs
        //NonProfitOrganization
        //Orders
        //Products
        //RegisterApplications
        //SocialActivist
        //Tweets

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

        private static readonly MainManager instance = new MainManager();
        public static MainManager Instance { get { return instance; } }

        private void AppDomainInitializer()
        {
            //LogManager = new LogManager(providerType File);
           
            TwitterManager = new TwitterManager();
            BuisnessCompaniesManager = new BuisnessCompaniesManager();
            CampaignsManager = new CampaignsManager();
            ContactUsManager = new ContactUsManager();
            NonProfitOrganizationManager = new NonProfitOrganizationManager();
            OrdersManager = new OrdersManager();
            ProductsManager = new ProductsManager();
            SocialActivistManager = new SocialActivistManager();
            RegisterApplicationsManager = new RegisterApplicationsManager();
        }
    }
}
