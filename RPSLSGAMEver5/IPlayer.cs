using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLSGAMEver5
{
   public interface IPlayer
    {
        char Choosedkey { get; set; }
        int Score { get; set; }
        char Getkey(CBoard board);
        void CheckChoosedKeyIsvalid(CBoard board);

    }
}
