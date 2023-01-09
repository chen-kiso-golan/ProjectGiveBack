using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Entities
{
    public class MainManager
    {
        public FormsManager FormsManager;
        public ReportsManager ReportsManager;
        public ChangesManager ChangesManager;
        private MainManager()
        {
            FormsManager=new FormsManager();
            ReportsManager=new ReportsManager();
            ChangesManager=new ChangesManager();    
        }

        private static readonly MainManager instance = new MainManager();
        public static MainManager Instance { get { return instance; } }
    }
}
