using System;
using System.Collections.Generic;
using RPSLSGAMEver5.Properties;

namespace RPSLSGAMEver5
{
    public class Board : IBoard, IBoardContent
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
        public string[] ChoosedGameItems { get; set; } = new string[2];
        public string Title { get; set; }
        public string WelcomeMessage { get; set; }
        public string WaitForInput { get; set; }
        public string AvailableItems { get; set; }
        public string ItemsEqual { get; set; }
        public string HitValidKey { get; set; }
        

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
        public string PlayerWinMessage { get; set; }
        public string PlayerPointMessage { get; set; }
        public string PlayerChoosedOptionMessage { get; set; }
        public string MachineChoosedOptionMessage { get; set; }
        public string MachinePointMessage { get; set; }
        public string PlayerLoseMessage { get; set; }
        public string FinalizeNavigation { get; set; }
        public string GameRulesMessage { get; set; }
        public string GameRulesNavigation { get; set; }

        public void Initialize(Human human, Machine machine, ResultSave resultSave)
        {
            LoadBoardContentResources();
            LoadWelcomeScreen(human);
            MenuNavigation(human, machine, resultSave);
        }
        public void LoadBoardContentResources()
        {
            Title = Resources.gameTitle;
            WelcomeMessage = Resources.gameWelcomeMessage;
            WaitForInput = Resources.WaitForInputMessage;
            AvailableItems = Resources.gameAvailableItems;
            ItemsEqual = Resources.gameItemsEqualMessage;
            HitValidKey = Resources.playerHitValidKeyMessage;
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
        public void LoadWelcomeScreen(Human human)
        {
            Console.Title = Title;
            Console.WriteLine(WelcomeMessage + "\n" + "\n" + WaitForInput);
            human.Getkey(this);
            
        }
        public void MenuNavigation(Human human, Machine machine, ResultSave resultSave)
        {
            GetChoosedMenuItem(human);
            switch (ChoosedMenu)
            {
                case "Start the Game":
                    GameCore(human, machine, resultSave);
                    break;
                case "Game Help":
                    Help(human, machine, resultSave);
                    break;
                case "Back to the Menu":
                    LoadWelcomeScreen(human);
                    break;
                case "Save the Result":
                    resultSave.SaveingProcess(this,machine,human);
                    
                    
                    break;
                case "Quit the Game":
                    Environment.Exit(0);
                    break;
            }
        }
        public string GetChoosedMenuItem(Human human)
        {
            ChoosedMenu = GameMenu[human.Choosedkey];
            return ChoosedMenu;
        }
        public void GameCore(Human human, Machine machine, ResultSave resultSave)
        {
            ScoreReset(human, machine);
            Console.Clear();
            Console.WriteLine(AvailableItems + "\n" +"\n" + WaitForInput);
            human.Getkey(this);
            machine.Getkey(this);
            GetChoosedGameItem(human, machine);
            ItemsEqualityCheck(human, machine);
            LoadGameCompareItems();
            RuleValidator();
            ChooseTheWinner(ChoosedGameItems[0], ChoosedGameItems[1], human, machine);
            ShowTheResult(human, machine);           
            Console.WriteLine("\n"+FinalizeNavigation + "\n" + "\n" + WaitForInput);
            human.Getkey(this);
            MenuNavigation(human, machine, resultSave);
        }
        public void ScoreReset(Human human, Machine machine)
        {
            human.Score = 0;
            machine.Score = 0;
        }
        public string[] GetChoosedGameItem(Human human, Machine machine)
        {
            ChoosedGameItems[0] = GameItems[human.Choosedkey];
            ChoosedGameItems[1] = GameItems[machine.Choosedkey];
            return ChoosedGameItems;
        }
        public void ItemsEqualityCheck(Human human, Machine machine)
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
        public void LoadGameCompareItems()
        {
            GameCompareChoosedItems = new Tuple<string, string>(ChoosedGameItems[0], ChoosedGameItems[1]);
        }
        public string RuleValidator()
        {
            if (RuleCheck.ContainsKey(GameCompareChoosedItems))
            {
                Winner = RuleCheck[GameCompareChoosedItems];
            }

            return Winner;
        }

        public void ChooseTheWinner(string optionOne, string optionTwo,Human human, Machine machine)
        {
            if (optionOne == Winner)
            {
                human.Score++;
                
            }
            if (optionTwo == Winner)
            {
                machine.Score++;
            }
        }
        public void ShowTheResult(Human human, Machine machine)
        {
            Console.Clear();
            if (human.Score > machine.Score)
            {
                Console.WriteLine(PlayerWinMessage + "\n" 
                                              + Winner + "\n"
                                              + PlayerPointMessage + "\n"
                                              + human.Score + "\n"
                                              + PlayerChoosedOptionMessage + "\n"
                                              + ChoosedGameItems[0] + "\n"
                                              + MachineChoosedOptionMessage + "\n"
                                              + ChoosedGameItems[1] + "\n"); 
            }
            else
            {
                Console.WriteLine(PlayerLoseMessage
                                              + Winner + "\n"
                                              + MachinePointMessage + "\n"
                                              + machine.Score + "\n"
                                              + PlayerChoosedOptionMessage + "\n"
                                              + ChoosedGameItems[0] + "\n"
                                              + MachineChoosedOptionMessage + "\n"
                                              + ChoosedGameItems[1] + "\n");
            }
        }
        public void Help(Human human, Machine machine, ResultSave resultSave)
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
