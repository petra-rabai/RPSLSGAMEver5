namespace RPSLSGAMEver5
{
    public interface IResultSave
    {
        bool DirectoryExist { get; set; }
        string DirectoryPath { get; set; }
        string ResultContent { get; set; }
        string ResultTimeStamp { get; set; }

        void CheckSaveDirectoryExsits();
        void SaveTheResultToFile();
    }
}