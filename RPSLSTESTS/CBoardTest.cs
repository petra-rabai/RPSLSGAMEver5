using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RPSLSGAMEver5;

namespace RPSLSTESTS
{
    internal class CBoardTest
    {
        [Test]

        public void CheckLoadBoardContentResourcesSuccess()
        {
            CBoard board = new CBoard();
            board.LoadBoardContentResources();
        }

        [TestCase('E', "Start the Game")]
        [TestCase('B', "Back to the Menu")]
        [TestCase('C', "Save the Result")]
        [TestCase('H', "Game Help")]
        [TestCase('Q', "Quit the Game")]
        [Test]
        public void CheckGetChoosedMenuItemSuccess(char testKey, string testMenu)
        {
            CHuman human = new CHuman();
            CBoard board = new CBoard();

            human.Choosedkey = testKey;

            board.GetChoosedMenuItem(human);

            Assert.AreEqual(testMenu, board.ChoosedMenu);
        }
        
        [TestCase(0)]
        [Test]
        public void CheckScoreResetSuccess(int testScore)
        {
            CBoard board = new CBoard();
            CMachine machine = new CMachine();
            CHuman human = new CHuman();

            board.ScoreReset(human, machine);

            Assert.AreEqual(testScore, human.Score);
            Assert.AreEqual(testScore, machine.Score);
        }

        [TestCase('V','R')]
        [Test]
        public void CheckGetChoosedGameItemLoadSuccess(char testHumanKey,char testMachineKey) 
        {
            CBoard board = new CBoard();
            CMachine machine = new CMachine();
            CHuman human = new CHuman();
            human.Choosedkey = testHumanKey;
            machine.Choosedkey = testMachineKey;

            board.GetChoosedGameItem(human, machine);

            Assert.IsNotEmpty(board.ChoosedGameItems[0]);
            Assert.IsNotEmpty(board.ChoosedGameItems[1]);

        }

        [TestCase("Paper","Rock")]
        [TestCase("Paper","Scissor")]
        [Test]
        public void CheckCoreFunctionsSuccess(string testGameItemOne, string testGameItemTwo) 
        {
            CBoard board = new CBoard();
            CMachine machine = new CMachine();
            CHuman human = new CHuman();

            board.ChoosedGameItems[0] = testGameItemOne;
            board.ChoosedGameItems[1] = testGameItemTwo;

            board.LoadGameCompareItems();
            board.RuleValidator();
            board.ChooseTheWinner(testGameItemOne, testGameItemTwo, human, machine);
            board.ShowTheResult(human, machine);

            Assert.IsNotEmpty(board.GameCompareChoosedItems.ToString());
            Assert.IsNotEmpty(board.Winner);
        }

    }
}
