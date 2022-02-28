using NUnit.Framework;
using RPSLSGAMEver5;

namespace RPSLSTESTS
{
    internal class BoardTest
    {
        [Test]

        public void CheckLoadBoardContentResourcesSuccess()
        {
            Board board = new Board();
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
            Human human = new Human();
            Board board = new Board();

            human.Choosedkey = testKey;

            board.GetChoosedMenuItem(human);

            Assert.AreEqual(testMenu, board.ChoosedMenu);
        }
        
        [TestCase(0)]
        [Test]
        public void CheckScoreResetSuccess(int testScore)
        {
            Board board = new Board();
            Machine machine = new Machine();
            Human human = new Human();

            board.ScoreReset(human, machine);

            Assert.AreEqual(testScore, human.Score);
            Assert.AreEqual(testScore, machine.Score);
        }

        [TestCase('V','R')]
        [Test]
        public void CheckGetChoosedGameItemLoadSuccess(char testHumanKey,char testMachineKey) 
        {
            Board board = new Board();
            Machine machine = new Machine();
            Human human = new Human();
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
            Board board = new Board();
            Machine machine = new Machine();
            Human human = new Human();

            board.ChoosedGameItems[0] = testGameItemOne;
            board.ChoosedGameItems[1] = testGameItemTwo;

            board.LoadGameCompareItems();
            board.RuleValidator();
            board.ChooseTheWinner(testGameItemOne, testGameItemTwo, human, machine);
            board.ShowTheResult(human, machine);

        }

    }
}
