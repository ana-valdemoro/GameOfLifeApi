using GameOfLifeApi2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLifeApi2.Resources
{
    public class ConserveBoardInMemory : ConserveBoard
    {
        private static  Board  Board;

        public Board Get()
        {
            FileWriter.WriteTimeStamp(Board);
            return Board;
        }

        public void Set(Board newBoard)
        {
            Board = newBoard;
            FileWriter.WriteTimeStamp(Board);
        }

        public Board Update()
        {
            Board.Next_generation();
            FileWriter.WriteTimeStamp(Board);
            return Board;

        }
    }
}
