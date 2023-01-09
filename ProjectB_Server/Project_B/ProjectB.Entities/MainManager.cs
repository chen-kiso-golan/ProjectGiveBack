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
        private MainManager()
        {
            FormsManager=new FormsManager();
            ReportsManager=new ReportsManager();
        }

        private static readonly MainManager instance = new MainManager();
        public static MainManager Instance { get { return instance; } }
    }
}
