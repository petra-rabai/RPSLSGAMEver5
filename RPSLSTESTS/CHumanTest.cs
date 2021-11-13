using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
