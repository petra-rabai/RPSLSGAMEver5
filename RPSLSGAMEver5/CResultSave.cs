using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLSGAMEver5
{
    public class CResultSave : IResultSave
    {
        public string DirectoryPath { get; set; }
        public string ResultContent { get; set; }
        public string ResultTimeStamp { get; set; }
        public bool DirectoryExist { get; set; }
        public void CheckSaveDirectoryExsits()
        {
            //
        }
        public void SaveTheResultToFile()
        {
            //
        }
    }
}
