using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RPSLSGAMEver5
{
    public interface IContent
    {
        string Title { get; set; }
        string WelcomeMessage { get; set; }
        string WaitForInput { get; set; }
        string AvailableItems { get; set; }
        string ItemsEqual { get; set; }
        string HitValidKey { get; set; }
        string HumanName { get; set; }

        void LoadContentResources();
    }
}
