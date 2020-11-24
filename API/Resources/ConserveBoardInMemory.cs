using GameOfLife.Models;

namespace GameOfLifeApi2.Resources
{
    public class ConserveBoardInMemory : IConserveBoard
    {
        private static  Board  Board;

        public Board Get()
        {
            return Board;
        }

        public Board Set(Board newBoard)
        {
            Board = newBoard;
            return Board;
        }

        public Board Update()
        {
            Board.NextGeneration();
            FileWriter.WriteBoardLog(Board);
            return Board;

        }
    }
}
