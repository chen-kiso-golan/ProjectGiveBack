using ProjectB.Data.Sql;
using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ProjectB.Entities
{
    public class ContactUsManager: BaseEntity
    {
        public ContactUsManager(LogManager log) : base(log) { }


        public void SendContactUsToDB(ContactUsModel form)
        {
            try
            {
                Log.LogEvent(@"Entities \ ContactUsManager \ SendContactUsToDB ran Successfully - ");
                DS_ContactUs DS_ContactUs = new DS_ContactUs();
                DS_ContactUs.EnterContactUsToDB(form);
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }

    }
}
