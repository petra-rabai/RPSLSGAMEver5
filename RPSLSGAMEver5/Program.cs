namespace RPSLSGAMEver5
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Human human = new Human();
            Machine machine = new Machine();
            ResultSave resultSave = new ResultSave();
            board.Initialize(human, machine, resultSave);
        }
    }
}
