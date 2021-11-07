using System;
using System.Collections.Generic;

namespace RPSLSGAMEver5
{
    public interface IBoard
    {
        Dictionary<char, string> GameMenu { get; set; }
        Dictionary<char, string> GameItems { get; set; }
        Dictionary<Tuple<string, string>, string> RuleCheck { get; }
        string[] ChoosedGameItems { get; set; }
        string ChoosedMenu { get; set; }
        Tuple<string, string> GameCompareChoosedItems { get; set; }
        string Winner { get; set; }
        string[] GetChoosedGameItem(CHuman human, CMachine machine);
        string GetChoosedMenuItem(CHuman human);
        void MenuNavigation(CHuman human, CMachine machine, CResultSave resultSave);
        void Initialize(CHuman human, CMachine machine, CResultSave resultSave);
        void LoadWelcomeScreen(CHuman human);
        void GameCore(CHuman human, CMachine machine, CResultSave resultSave);
        void ItemsEqualityCheck(CHuman human, CMachine machine);
        void LoadGameCompareItems();
        string RuleValidator();
        void ChooseTheWinner(string optionOne, string optionTwo, CHuman human, CMachine machine);
        void ScoreReset(CHuman human, CMachine machine);
        void ShowTheResult(CHuman human, CMachine machine);
        void Help(CHuman human, CMachine machine, CResultSave resultSave);
    }
}
