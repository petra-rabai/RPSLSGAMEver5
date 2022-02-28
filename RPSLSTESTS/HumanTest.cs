using NUnit.Framework;
using RPSLSGAMEver5;

namespace RPSLSTESTS
{
    internal class HumanTest
    {
        [Test]
        public void CheckChoosedKeyIsvalidSuccess()
        {
            Human human = new Human();
            Board board = new Board();
            human.CheckChoosedKeyIsvalid(board);
        }
    }
}
