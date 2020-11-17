using GameOfLifeApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLifeApi2.DataTransferObjects
{
    public class BoardMapper
    {
        public static Board DTOtoBoard(BoardDTO boardDTO)
        {
            Board board = new Board();
            foreach (CellDTO cellDTO in boardDTO.Table) board.Table.Add(DTOtoCell(cellDTO));

            return board;

        }
        public static Cell DTOtoCell(CellDTO cellDTO)
        {
            int[] coordinates = new int[] { cellDTO.PositionX, cellDTO.PositionY };
            return new Cell(coordinates, cellDTO.IsAlive);
        }

    }
}
