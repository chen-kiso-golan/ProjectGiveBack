using ProjectB.Entities.command.commandClasses.CampaignsCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ProjectB.Entities.command
{

    public class CommandManager : BaseEntity
    {

        public CommandManager(LogManager log) : base(log) { }



        private Dictionary<string, ICommand> _commandList = null;
        public Dictionary<string, ICommand> CommandList
        {
            get
            {
                if (_commandList == null) init();
                return _commandList;
            }
        }


        private void init()
        {
            try
            {
                Log.LogEvent(@"Entities \ command \ CommandManager \ init ran Successfully - ");

                //Build all Dictionary
                _commandList = new Dictionary<string, ICommand>
            {
                //Campaigns
                { "getAllCampaignsFromDB", new getAllCampaignsFromDB(Log)},
                { "getAllCampaignNamesFromDB", new getAllCampaignNamesFromDB(Log)},
                { "getCampaignCodeByNameFromDB", new getCampaignCodeByNameFromDB(Log)},
                { "CampaignPost", new CampaignPost(Log)},
                { "UpdateCampaign", new UpdateCampaign(Log)},
                { "deleteCampaign", new deleteCampaign(Log)},

            };


            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }
    }

    
}
