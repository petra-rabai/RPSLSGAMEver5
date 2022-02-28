using NUnit.Framework;
using RPSLSGAMEver5;

namespace RPSLSTESTS
{
    public class MachineTest
    {
        [Test]
        public void CheckGetKeySuccess()
        {
            Machine machine = new Machine();
            Board board = new Board();

            machine.Getkey(board);

            Assert.IsNotNull(machine.Choosedkey);
        }

        [TestCase('Z')]
        [Test]
        public void CheckChoosedKeyIsvalidSuccess( char expectedChoosedKey)
        {
            Machine machine = new Machine();
            Board board = new Board();

            machine.CheckChoosedKeyIsvalid(board);

            Assert.IsTrue(!board.GameItems.ContainsKey(expectedChoosedKey));

        }

    }
}
