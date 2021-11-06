using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLSGAMEver5
{
    class Program
    {
        static void Main(string[] args)
        {
            CBoard board = new CBoard();
            CHuman human = new CHuman();
            CMachine machine = new CMachine();
            CResultSave resultSave = new CResultSave();
            board.Initialize(human, machine, resultSave);
        }
    }
}
