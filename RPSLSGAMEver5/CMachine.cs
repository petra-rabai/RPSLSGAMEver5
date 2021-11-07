using System;
using System.Collections.Generic;
using System.Linq;

namespace RPSLSGAMEver5
{
   public class CMachine : IPlayer
    {
        public char Choosedkey { get; set; }
        public int Score { get; set; }

        public char Getkey(CBoard board)
        {
            Random choose = new Random();
            int chooseHelper = choose.Next(board.GameItems.Count);
            char gameDictionaryKey = board.GameItems.Keys.ElementAt(chooseHelper);
            Choosedkey = gameDictionaryKey;
            
            CheckChoosedKeyIsvalid(board);

            return Choosedkey;
        }

        public void CheckChoosedKeyIsvalid(CBoard board)
        {
            if (!board.GameItems.ContainsKey(Choosedkey))
            {
                foreach (KeyValuePair<char, string> gameItempair in board.GameItems)
                {
                    Console.WriteLine(gameItempair.Key + " - " + gameItempair.Value + "\n");
                }
            }
        }
    }
}
