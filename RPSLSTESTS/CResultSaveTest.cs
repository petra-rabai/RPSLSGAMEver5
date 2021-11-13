using NUnit.Framework;
using RPSLSGAMEver5;
using System.IO;

namespace RPSLSTESTS
{
    public class CResultSaveTests
    {
        [TestCase("C:\\Test\\")]
        [Test]
        public void CheckCreateGameResultDirectorySuccess(string expectedGameDirectory)
        {
            CResultSave resultSave = new CResultSave
            {
                DirectoryPath = expectedGameDirectory
            };
            resultSave.CheckSaveDirectoryExsits();

            DirectoryAssert.Exists(expectedGameDirectory);
            Assert.IsFalse(resultSave.DirectoryExist);
            Directory.Delete(expectedGameDirectory);
        }

        [Test]
        public void CheckResultSavingSuccess()
        {
            CHuman human = new CHuman();
            CMachine machine = new CMachine();
            CResultSave resultSave = new CResultSave();
            CBoard board = new CBoard();
            var temporaryFileName = "SavingTest.txt";
            resultSave.FileName = temporaryFileName;
            resultSave.HumanName = "Test";
            human.Score = 1;
            board.ChoosedGameItems[0] = "Scissor";
            machine.Score = 1;
            board.ChoosedGameItems[1] = "Scissor"; ;

            resultSave.SaveTheResultToFile(board, machine,human);
            string expectedFileName = resultSave.ResultFullPath;
            string expectedFileData = resultSave.ResultContent;

            DirectoryAssert.Exists(resultSave.DirectoryPath);
            FileAssert.Exists(expectedFileName);
            Assert.AreEqual(expectedFileData, resultSave.ResultContent);
            Assert.IsNotEmpty(resultSave.ResultTimeStamp);
            File.Delete(temporaryFileName);
        }

        [Test]
        public void CheckLoadResultContentSuccess()
        {
            CResultSave resultSave = new CResultSave();
            var expectedAddHumanName = "";
            var expectedFileName = "";
            var expectedHumanNameMessage = "";

            resultSave.LoadResultContent();

            Assert.AreNotEqual(expectedAddHumanName, resultSave.AddHumanName);
            Assert.AreNotEqual(expectedFileName, resultSave.FileName);
            Assert.AreNotEqual(expectedHumanNameMessage, resultSave.HumanNameMessage);

        }

    }
}