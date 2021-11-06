using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPSLSGAMEver5.Properties;

namespace RPSLSGAMEver5
{
    public class CBoard : IBoard, IContent
    {
        public Dictionary<char, string> GameMenu { get; set; } = new Dictionary<char, string>
        {
            ['E'] = "Start the Game",
            ['H'] = "Game Help",
            ['B'] = "Back to the Menu",
            ['C'] = "Save the Result",
            ['Q'] = "Quit the Game"
        };
        public Dictionary<char, string> GameItems { get; set; } = new Dictionary<char, string>
        {
            ['P'] = "Paper",
            ['S'] = "Scissor",
            ['V'] = "Spock",
            ['R'] = "Rock",
            ['L'] = "Lizard"

        };
        public string ChoosedMenu { get; set; }
        public string[] ChoosedGameItems { get; set; }
        public string Title { get; set; }
        public string WelcomeMessage { get; set; }
        public string WaitForInput { get; set; }
        public string AvailableItems { get; set; }
        public string ItemsEqual { get; set; }
        public string HitValidKey { get; set; }
        public string AddHumanName { get; set; }

        public Dictionary<Tuple<string, string>, string> RuleCheck { get; } =
           new Dictionary<Tuple<string, string>, string>()
           {
                {new Tuple<string, string>("Paper", "Scissor"), "Scissor"},
                {new Tuple<string, string>("Scissor", "Paper"), "Scissor"},
                {new Tuple<string, string>("Rock", "Scissor"), "Rock"},
                {new Tuple<string, string>("Scissor", "Rock"), "Rock"},
                {new Tuple<string, string>("Rock", "Lizard"), "Rock"},
                {new Tuple<string, string>("Lizard", "Rock"), "Rock"},
                {new Tuple<string, string>("Lizard", "Spock"), "Lizard"},
                {new Tuple<string, string>("Spock", "Lizard"), "Lizard"},
                {new Tuple<string, string>("Spock", "Scissor"), "Spock"},
                {new Tuple<string, string>("Scissor", "Spock"), "Spock"},
                {new Tuple<string, string>("Scissor", "Lizard"), "Scissor"},
                {new Tuple<string, string>("Lizard", "Scissor"), "Scissor"},
                {new Tuple<string, string>("Paper", "Lizard"), "Lizard"},
                {new Tuple<string, string>("Lizard", "Paper"), "Lizard"},
                {new Tuple<string, string>("Paper", "Spock"), "Paper"},
                {new Tuple<string, string>("Spock", "Paper"), "Paper"},
                {new Tuple<string, string>("Rock", "Spock"), "Spock"},
                {new Tuple<string, string>("Spock", "Rock"), "Spock"},
                {new Tuple<string, string>("Rock", "Paper"), "Paper"},
                {new Tuple<string, string>("Paper", "Rock"), "Paper"}
           };
        public Tuple<string, string> GameCompareChoosedItems { get; set; }
        public string Winner { get; set; }
        public Dictionary<Tuple<string, string>, string> WinnerInfo { get; set; }
        public string PlayerWinMessage { get; set; }
        public string PlayerPointMessage { get; set; }
        public string PlayerChoosedOptionMessage { get; set; }
        public string MachineChoosedOptionMessage { get; set; }
        public string MachinePointMessage { get; set; }
        public string PlayerLoseMessage { get; set; }
        public string FinalizeNavigation { get; set; }
        public string GameRulesMessage { get; set; }
        public string GameRulesNavigation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ChooseTheWinner(string optionOne, string optionTwo,CHuman human, CMachine machine)
        {
            if (optionOne == Winner)
            {
                WinnerInfo.Add(GameCompareChoosedItems, optionOne);
                human.Score++;
                
            }
            if (optionTwo == Winner)
            {
                WinnerInfo.Add(GameCompareChoosedItems, optionTwo);
                machine.Score++;
            }
        }

        public void GameCore(CHuman human, CMachine machine, CResultSave resultSave)
        {
            ScoreReset(human, machine);
            Console.WriteLine(AvailableItems + "\n" + WaitForInput);
            human.Getkey(this);
            machine.Getkey(this);
            GetChoosedGameItem(human, machine);
            ItemsEqualityCheck(human, machine);
            LoadGameCompareItems();
            RuleValidator();
            ChooseTheWinner(ChoosedGameItems[0], ChoosedGameItems[1],human,machine);
            ShowTheResult(human, machine);
            Console.WriteLine(FinalizeNavigation + "\n" + WaitForInput);
            human.Getkey(this);
            GetChoosedMenuItem(human);
            MenuNavigation(human, machine,resultSave);
        }

        public string[] GetChoosedGameItem(CHuman human, CMachine machine)
        {
            ChoosedGameItems[0] = GameItems[human.Choosedkey];
            ChoosedGameItems[1] = GameItems[machine.Choosedkey];
            return ChoosedGameItems;
        }

        public string GetChoosedMenuItem(CHuman human)
        {
            ChoosedMenu = GameMenu[human.Choosedkey];
            return ChoosedMenu;
        }

        public void Initialize(CHuman human, CMachine machine, CResultSave resultSave)
        {
            LoadContentResources();
            LoadWelcomeScreen(human,machine,resultSave);
        }

        public void ItemsEqualityCheck(CHuman human, CMachine machine)
        {
            if (ChoosedGameItems[0] == ChoosedGameItems[1])
            {
                Console.WriteLine(ItemsEqual);
                human.CheckChoosedKeyIsvalid(this);
                human.Getkey(this);
                machine.Getkey(this);
                GetChoosedGameItem(human, machine);
            }
        }

        public void LoadContentResources()
        {
            Title = Resources.gameTitle;
            WelcomeMessage = Resources.gameWelcomeMessage;
            WaitForInput = Resources.WaitForInputMessage;
            AvailableItems = Resources.gameAvailableItems;
            ItemsEqual = Resources.gameItemsEqualMessage;
            HitValidKey = Resources.playerHitValidKeyMessage;
            AddHumanName = Resources.playerAddNameMessage;
            PlayerWinMessage = Resources.playerWinMessage;
            PlayerPointMessage = Resources.playerPointMessage;
            PlayerChoosedOptionMessage = Resources.playerChoosedOptionMessage;
            MachineChoosedOptionMessage = Resources.machineChoosedOtionMessage;
            MachinePointMessage = Resources.machinePointMessage;
            PlayerLoseMessage = Resources.playerLoseMessage;
            FinalizeNavigation = Resources.playerGameFinalizeNavigationMessage;
            GameRulesMessage = Resources.gameRulesMessage;
            GameRulesNavigation = Resources.playerGameRulesNavigationMessage;
        }

        public void LoadGameCompareItems()
        {
            GameCompareChoosedItems = new Tuple<string, string>(ChoosedGameItems[0],ChoosedGameItems[1]);
        }

        public void MenuNavigation(CHuman human, CMachine machine, CResultSave resultSave)
        {
            GetChoosedMenuItem(human);
            switch (ChoosedMenu)
            {
                case "Start the Game":
                    GameCore(human,machine,resultSave);
                    break;
                case "Game Help":
                    Help(human, machine,resultSave);
                    break;
                case "Back to the Menu":
                    LoadWelcomeScreen(human,machine,resultSave);
                    break;
                case "Save the Result":
                    resultSave.SaveTheResultToFile(this,machine,human);
                    break;
                case "Quit the Game":
                    Environment.Exit(0);
                    break;
            }
        }

        public string RuleValidator()
        {
            if (RuleCheck.ContainsKey(GameCompareChoosedItems))
            {
                Winner = RuleCheck[GameCompareChoosedItems];
            }

            return Winner;
        }

        public void ScoreReset(CHuman human, CMachine machine)
        {
            human.Score = 0;
            machine.Score = 0;
        }

        public void ShowTheResult(CHuman human, CMachine machine)
        {
            if (human.Score > machine.Score)
            {
                Console.WriteLine(PlayerWinMessage
                                              + WinnerInfo[GameCompareChoosedItems]
                                              + PlayerPointMessage
                                              + human.Score
                                              + PlayerChoosedOptionMessage
                                              + ChoosedGameItems[0]
                                              + MachineChoosedOptionMessage
                                              + ChoosedGameItems[1]);
            }
            else
            {
                Console.WriteLine(PlayerLoseMessage
                                              + WinnerInfo[GameCompareChoosedItems]
                                              + MachinePointMessage
                                              + machine.Score
                                              + PlayerChoosedOptionMessage
                                              + ChoosedGameItems[0]
                                              + MachineChoosedOptionMessage
                                              + ChoosedGameItems[1]);
            }
        }

        public void LoadWelcomeScreen(CHuman human, CMachine machine, CResultSave resultSave)
        {
            Console.Title = Title;
            Console.WriteLine(WelcomeMessage + "\n" + WaitForInput);
            human.Getkey(this);
            GetChoosedMenuItem(human);
            MenuNavigation(human,machine,resultSave);
        }

        public void Help(CHuman human, CMachine machine, CResultSave resultSave)
        {
            Console.WriteLine(GameRulesMessage
                              + "\n"
                              + GameRulesNavigation
                              + "\n"
                              + WaitForInput);
            human.Getkey(this);
            GetChoosedMenuItem(human);
            MenuNavigation(human, machine,resultSave);

        }
    }
}
