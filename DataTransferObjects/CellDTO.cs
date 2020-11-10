using GameOfLifeAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLifeApi2.DataTransferObjects
{
    public class CellDTO{
        public Boolean IsAlive { set; get; }
        public int PositionX { set; get; }
        public int PositionY { set; get; }

        public static CellDTO CellToDTO(Cell cell) =>
            new CellDTO
            {
                IsAlive = cell.IsAlive,
                PositionX = cell.PositionX,
                PositionY = cell.PositionY
            };
    }
}
