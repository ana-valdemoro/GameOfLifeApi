using GameOfLifeApi2.DataTransferObjects;
using GameOfLifeApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLifeApi2.Commands
{
    public interface ICommand
    {
        //protected readOnly IConserveBoard conserveBoard;
       
        BoardDTO Execute();
        private static BoardDTO BoardToDTO(Board board)
        {
            BoardDTO boardDTO = new BoardDTO { Table = new List<CellDTO>() };
            foreach (Cell cell in board.Table) boardDTO.Table.Add(CellToDTO(cell));
            return boardDTO;
        }


        private static CellDTO CellToDTO(Cell cell) =>
            new CellDTO
            {
                IsAlive = cell.IsAlive,
                PositionX = cell.PositionX,
                PositionY = cell.PositionY
            };
        private static Board DTOtoBoard(BoardDTO boardDTO)
        {
            Board board = new Board();
            foreach (CellDTO cellDTO in boardDTO.Table) board.Table.Add(DTOtoCell(cellDTO));

            return board;

        }
        private static Cell DTOtoCell(CellDTO cellDTO)
        {
            int[] coordinates = new int[] { cellDTO.PositionX, cellDTO.PositionY };
            return new Cell(coordinates, cellDTO.IsAlive);
        }
    }
}
