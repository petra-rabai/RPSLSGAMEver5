using NUnit.Framework;
using RPSLSGAMEver5;

namespace RPSLSTESTS
{
    public class CMachineTest
    {
        [Test]
        public void CheckGetKeySuccess()
        {
            CMachine machine = new CMachine();
            CBoard board = new CBoard();

            machine.Getkey(board);

            Assert.IsNotNull(machine.Choosedkey);
        }

        [TestCase('Z')]
        [Test]
        public void CheckChoosedKeyIsvalidSuccess( char expectedChoosedKey)
        {
            CMachine machine = new CMachine();
            CBoard board = new CBoard();

            machine.CheckChoosedKeyIsvalid(board);

            Assert.IsTrue(!board.GameItems.ContainsKey(expectedChoosedKey));

        }

    }
}
