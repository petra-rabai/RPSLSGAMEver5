using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLSGAMEver5
{
    public interface IBoard
    {
        Dictionary<char, string> GameMenu { get; set; }
        Dictionary<char, string> GameItems { get; set; }
        Dictionary<Tuple<string, string>, string> RuleCheck { get; }
        int Score { get; set;}
        string[] ChoosedGameItems { get; set; }
        string ChoosedMenu { get; set; }
        string[] GetChoosedGameItem(CHuman human, CMachine machine);
        string GetChoosedMenuItem(CHuman human);
        void MenuNavigation(CHuman human);
        void WelcomeScreenInitialize(CHuman human);
        void GameCore();
    }
}
