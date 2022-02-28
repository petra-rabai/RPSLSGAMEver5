namespace RPSLSGAMEver5
{
   public interface IPlayer
    {
        char Choosedkey { get; set; }
        int Score { get; set; }
        char Getkey(Board board);
        void CheckChoosedKeyIsvalid(Board board);

    }
}
