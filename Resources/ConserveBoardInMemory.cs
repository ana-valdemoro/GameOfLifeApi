using GameOfLifeApi2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            Board.Next_generation();
            FileWriter.WriteTimeStamp(Board);
            return Board;

        }
    }
}
