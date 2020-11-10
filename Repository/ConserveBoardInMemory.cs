using GameOfLifeApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLifeApi2.Repository
{
    public class ConserveBoardInMemory : ConserveBoard
    {
        private static  Board  Board;

        public ConserveBoardInMemory()
        {
            Board = new Board(new int[,] { { 1, 1 } });
        }
        public Board Get()
        {
            return Board;
        }

        public void Set(Board newBoard)
        {
            Board = newBoard;
            //Board = new Board(newBoard);
          
        }

        public Board Update()
        {
             return Board.Next_generation();
        }
    }
}
