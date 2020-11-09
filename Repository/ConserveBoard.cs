using GameOfLifeApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLifeApi2.Repository
{
    public interface ConserveBoard
    {
        public void Set(Board newBoard);
        public Board Get();
        public Board Update();
    }
}
