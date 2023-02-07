using ProjectB.Data.Sql;
using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Entities
{
    public class ContactUsManager
    {
        public void SendContactUsToDB(ContactUsModel form)
        {
            DS_ContactUs DS_ContactUs = new DS_ContactUs();
            DS_ContactUs.EnterContactUsToDB(form);
        }

    }
}
