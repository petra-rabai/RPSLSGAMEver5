using System;
using System.Collections.Generic;

namespace RPSLSGAMEver5
{
    public class Human : IPlayer
    {
        public char Choosedkey { get; set; }
        public int Score { get; set; }

        public char Getkey(Board board)
        {
            ReadKeyboard();
            while ((!board.GameMenu.ContainsKey(Choosedkey)) && (!board.GameItems.ContainsKey(Choosedkey)))
            {
                CheckChoosedKeyIsvalid(board);
                ReadKeyboard();
            }

            return Choosedkey;
        }

        public void CheckChoosedKeyIsvalid(Board board)
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
