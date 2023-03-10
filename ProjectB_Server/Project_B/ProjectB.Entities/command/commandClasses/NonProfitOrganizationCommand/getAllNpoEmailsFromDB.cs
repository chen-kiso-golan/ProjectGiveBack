using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ProjectB.Entities.command.commandClasses.NonProfitOrganizationCommand
{
    public class getAllNpoEmailsFromDB : CommandManager, ICommand
    {
        public getAllNpoEmailsFromDB(LogManager log) : base(log)
        {
        }

        public object Execute(params object[] param)
        {
            try
            {
                Log.LogEvent(@"Entities \ command \ NonProfitOrganizationCommand \ getAllNpoEmailsFromDB ran Successfully - ");

                return JsonConvert.SerializeObject(MainManager.Instance.NonProfitOrganizationManager.ShowAllNpoEmailsFromDB());

            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

            return JsonConvert.SerializeObject(null);
        }


    }
}
