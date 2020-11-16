using GameOfLifeApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLifeApi2.Resources
{
    public class ConserveBoardInMemory : ConserveBoard
    {
        private static  Board  Board;

        public Board Get()
        {
            return Board;
        }

        public void Set(Board newBoard)
        {
            Board = newBoard;         
        }

        public Board Update()
        {
             return Board.Next_generation();
        }
    }
}
