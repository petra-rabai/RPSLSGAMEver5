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
        string[] GetChoosedGameItem(Human human, Machine machine);
        string GetChoosedMenuItem(Human human);
        void MenuNavigation(Human human, Machine machine, ResultSave resultSave);
        void Initialize(Human human, Machine machine, ResultSave resultSave);
        void LoadWelcomeScreen(Human human);
        void GameCore(Human human, Machine machine, ResultSave resultSave);
        void ItemsEqualityCheck(Human human, Machine machine);
        void LoadGameCompareItems();
        string RuleValidator();
        void ChooseTheWinner(string optionOne, string optionTwo, Human human, Machine machine);
        void ScoreReset(Human human, Machine machine);
        void ShowTheResult(Human human, Machine machine);
        void Help(Human human, Machine machine, ResultSave resultSave);
    }
}
