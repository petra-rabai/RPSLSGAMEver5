using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLSGAMEver5
{
    public class CHuman : IPlayer
    {
        public char Choosedkey { get; set; }

        public char Getkey(CBoard board)
        {
            ReadKeyboard();
            while ((!board.GameMenu.ContainsKey(Choosedkey)) && (!board.GameItems.ContainsKey(Choosedkey)))
            {
                CheckChoosedKeyIsvalid(board);
                ReadKeyboard();
            }

            return Choosedkey;
        }

        public void CheckChoosedKeyIsvalid(CBoard board)
        {
            Console.WriteLine(board.HitValidKey);

            foreach (KeyValuePair<char, string> gameMenupair in board.GameMenu)
            {
                Console.WriteLine(gameMenupair.Key + " - " + gameMenupair.Value + "\n");
            }
            foreach (KeyValuePair<char, string> gameItempair in board.GameItems)
            {
                Console.WriteLine(gameItempair.Key + " - " + gameItempair.Value + "\n");
            }

            Console.WriteLine(board.WaitForInput);
        }

        public void ReadKeyboard()
        {
            ConsoleKeyInfo hitkey = Console.ReadKey();
            Choosedkey = Char.Parse(hitkey.Key.ToString());
        }
    }
}
