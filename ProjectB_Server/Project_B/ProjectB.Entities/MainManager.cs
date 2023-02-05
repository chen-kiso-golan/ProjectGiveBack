﻿using ProjectB.Model;
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

        public FormsManager FormsManager;
        public ReportsManager ReportsManager;
        public ChangesManager ChangesManager;
        public TwitterManager TwitterManager;
        private MainManager()
        {
            AppDomainInitializer();
        }

        private static readonly MainManager instance = new MainManager();
        public static MainManager Instance { get { return instance; } }

        private void AppDomainInitializer()
        {
            //LogManager = new LogManager(providerType File);
            FormsManager = new FormsManager();
            ReportsManager = new ReportsManager();
            ChangesManager = new ChangesManager();
            TwitterManager = new TwitterManager();
        }
    }
}
