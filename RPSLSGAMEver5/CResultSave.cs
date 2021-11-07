using RPSLSGAMEver5.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLSGAMEver5
{
    public class CResultSave : IResultSave
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
        public void CheckSaveDirectoryExsits()
        {
            DirectoryExist = Directory.Exists(DirectoryPath);
            if (!DirectoryExist)
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }

        public void GetNameFromTheConsole(CBoard board)
        {
            
            Console.WriteLine(AddHumanName + "\n" + board.WaitForInput);
            HumanName = Console.ReadLine();
        }

        public void LoadResultContent()
        {
            AddHumanName = Resources.playerAddNameMessage;
            FileName = Resources.gameSavedDataFileName;
            HumanNameMessage = Resources.playerNameMessage;
        }

        public void SaveTheResultToFile(CBoard board, CMachine machine, CHuman human)
        {
            LoadResultContent();
            CheckSaveDirectoryExsits();
            GetNameFromTheConsole(board);
            ResultContent = ResultTimeStamp
                                             + HumanNameMessage + "\n"
                                             + HumanName + "\n"
                                             + board.WinnerInfo[board.GameCompareChoosedItems] + "\n"
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
