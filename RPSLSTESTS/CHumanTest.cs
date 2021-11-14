using NUnit.Framework;
using RPSLSGAMEver5;

namespace RPSLSTESTS
{
    internal class CHumanTest
    {
        [Test]
        public void CheckChoosedKeyIsvalidSuccess()
        {
            CHuman human = new CHuman();
            CBoard board = new CBoard();
            human.CheckChoosedKeyIsvalid(board);
        }
    }
}
