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
            Console.WriteLine(board.AddHumanName + "\n" + board.WaitForInput);
            HumanName = Console.ReadLine();
        }

        public void SaveTheResultToFile(CBoard board, CMachine machine, CHuman human)
        {
            FileName = Resources.gameSavedDataFileName;
            HumanNameMessage = Resources.playerNameMessage;
            CheckSaveDirectoryExsits();
            GetNameFromTheConsole(board);
            ResultContent = ResultTimeStamp
                                             + HumanNameMessage
                                             + HumanName
                                             + board.WinnerInfo.Values
                                             + board.PlayerPointMessage
                                             + human.Score
                                             + board.MachinePointMessage
                                             + machine.Score
                                             + board.PlayerChoosedOptionMessage
                                             + board.ChoosedGameItems[0]
                                             + board.MachineChoosedOptionMessage
                                             + board.ChoosedGameItems[1];
            ResultFullPath = DirectoryPath + FileName;
            File.AppendAllText(ResultFullPath, ResultContent);
        }
    }
}
