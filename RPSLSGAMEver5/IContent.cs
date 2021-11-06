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
        string AddHumanName { get; set; }
        string PlayerWinMessage { get; set; }
        string PlayerPointMessage { get; set; }
        string PlayerChoosedOptionMessage { get; set; }
        string MachineChoosedOptionMessage { get; set; }
        string MachinePointMessage { get; set; }
        string PlayerLoseMessage { get; set; }
        string FinalizeNavigation { get; set; }
        string GameRulesMessage { get; set; }
        string GameRulesNavigation { get; set; }

        void LoadContentResources();
    }
}
