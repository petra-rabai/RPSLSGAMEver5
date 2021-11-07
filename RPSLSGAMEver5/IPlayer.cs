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
