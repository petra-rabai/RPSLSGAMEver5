using RPSLSGAMEver5.Properties;
using System;
using System.IO;

namespace RPSLSGAMEver5
{
    public class ResultSave : IResultSave
    {
        public string DirectoryPath { get; set; } = Settings.Default.DefaultFolderPath;
        public string ResultContent { get; set; }
        public string ResultTimeStamp { get; set; } = DateTime.Now.ToString("\n MM/dd/yyyy h:mm tt\n");
        public bool DirectoryExist { get; set; }
        public string ResultFullPath { get; set; }
        public string FileName { get; set; }
        public string HumanNameMessage { get; set; }
        public string HumanName { get; set; }
        public string AddHumanName { get; set; }

        public void SaveingProcess(Board board, Machine machine, Human human)
        {
            Console.Clear();
            LoadResultContent();
            CheckSaveDirectoryExsits();
            GetNameFromTheConsole(board);
            SaveTheResultToFile(board, machine, human);
            Console.WriteLine("Result saved successful!");
            Console.WriteLine("Hit the Q key to Quit the Game");
            human.Getkey(board);
            board.MenuNavigation(human, machine, this);
        }

        public void LoadResultContent()
        {
            AddHumanName = Resources.playerAddNameMessage;
            FileName = Resources.gameSavedDataFileName;
            HumanNameMessage = Resources.playerNameMessage;
        }

        public void CheckSaveDirectoryExsits()
        {
            DirectoryExist = Directory.Exists(DirectoryPath);
            if (!DirectoryExist)
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }

        public void GetNameFromTheConsole(Board board)
        {
            
            Console.WriteLine(AddHumanName + "\n"+"\n" + board.WaitForInput);
            HumanName = Console.ReadLine();
        }

        public void SaveTheResultToFile(Board board, Machine machine, Human human)
        {   
            ResultContent = ResultTimeStamp + "\n"
                                             + HumanNameMessage + "\n"
                                             + HumanName + "\n"
                                             + "The Winner is: "+board.Winner + "\n"
                                             + board.PlayerPointMessage + "\n"
                                             + human.Score + "\n"
                                             + board.MachinePointMessage + "\n"
                                             + machine.Score + "\n"
                                             + board.PlayerChoosedOptionMessage + "\n"
                                             + board.ChoosedGameItems[0] + "\n"
                                             + board.MachineChoosedOptionMessage + "\n"
                                             + board.ChoosedGameItems[1];
            ResultFullPath = DirectoryPath + FileName;
            File.AppendAllText(ResultFullPath, ResultContent);
        }
    }
}
