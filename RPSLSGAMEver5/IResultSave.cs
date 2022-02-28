namespace RPSLSGAMEver5
{
    public interface IResultSave
    {
        bool DirectoryExist { get; set; }
        string DirectoryPath { get; set; }
        string ResultContent { get; set; }
        string ResultTimeStamp { get; set; }
        string ResultFullPath { get; set; }
        string FileName { get; set; }
        string HumanNameMessage { get; set; }
        string HumanName { get; set; }
        string AddHumanName { get; set; }
        void GetNameFromTheConsole(Board board);
        void CheckSaveDirectoryExsits();
        void SaveTheResultToFile(Board board, Machine machine, Human human);
        void LoadResultContent();
        void SaveingProcess(Board board, Machine machine, Human human);
    }
}