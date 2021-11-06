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
        public int Score { get; set; }
        public string ChoosedMenu { get; set; }
        public string[] ChoosedGameItems { get; set; }
        public string Title { get; set; }
        public string WelcomeMessage { get; set; }
        public string WaitForInput { get; set; }
        public string AvailableItems { get; set; }
        public string ItemsEqual { get; set; }
        public string HitValidKey { get; set; }
        public string HumanName { get; set; }

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

        public void GameCore()
        {
            Console.WriteLine(AvailableItems);
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

        public void LoadContentResources()
        {
            Title = Resources.gameTitle;
            WelcomeMessage = Resources.gameWelcomeMessage;
            WaitForInput = Resources.WaitForInputMessage;
            AvailableItems = Resources.gameAvailableItems;
            ItemsEqual = Resources.gameItemsEqualMessage;
            HitValidKey = Resources.playerHitValidKeyMessage;
            HumanName = Resources.playerAddNameMessage;

        }

        public void MenuNavigation(CHuman human)
        {
            GetChoosedMenuItem(human);
            switch (ChoosedMenu)
            {
                case "Start the Game":
                    GameCore();
                    break;
                case "Game Help":
                    Help(player, machine, game);
                    break;
                case "Back to the Menu":
                    Initialize(player, machine, game);
                    break;
                case "Save the Result":
                    Saveing(player, machine);
                    break;
                case "Quit the Game":
                    Environment.Exit(0);
                    break;
            }
        }

        public void WelcomeScreenInitialize(CHuman human)
        {
            Console.Title = Title;
            Console.WriteLine(WelcomeMessage + "\n" + WaitForInput);
            human.Getkey(this);
            GetChoosedMenuItem(human);
            MenuNavigation(human);
        }


    }
}
