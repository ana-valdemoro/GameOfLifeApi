using GameOfLife.Models;
using Microsoft.Extensions.Configuration;

namespace GameOfLifeApi2.Resources
{
    public class ConserveBoardInMemory : IConserveBoard
    {
        private static  Board  Board;
        private FileWriter fileWriter ;

        public ConserveBoardInMemory(IConfiguration configuration)
        {
            
            fileWriter = new FileWriter(configuration);
        }

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
            fileWriter.WriteBoardLog(Board);
            return Board;

        }
    }
}
