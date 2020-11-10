using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameOfLifeApi2.DataTransferObjects;
using GameOfLifeApi2.Models;
using GameOfLifeApi2.Repository;
using GameOfLifeAPI2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameOfLifeApi2.Controllers
{
    [Route("api/GameOfLife")]
    [Produces("application/json")]
    [ApiController]
    public class GameOfLifeController : ControllerBase
    {
        //public static Board InitialBoard = new Board(new int[,] { { 1, 1 } });
        public ConserveBoard ConserveBoardInMemory;

        public GameOfLifeController(ConserveBoard board)
        {
            ConserveBoardInMemory = board;
        }

        /// <summary>
        /// Get current board saved in memory.
        /// </summary>
        /// <response code="200">Action completed successfully</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<BoardDTO> GetCurrentBoard()
        {
            var board = ConserveBoardInMemory.Get();
            var boardResult = BoardToDTO(board);
            return Ok(boardResult);


        }
        /// <summary>
        /// Advance one the current state of the board.
        /// </summary>
        /// <returns>A board with next state of Cells</returns>
        /// <response code="200">Action completed successfully</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<BoardDTO> ObtainNextBoard()
        {
            var board = ConserveBoardInMemory.Update();
            var boardResult = BoardToDTO(board);
            return Ok(boardResult);
        }

        /// <summary>
        /// Set Board in Memory
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /SetBoard
        ///     {
        ///        "table": [
        ///            {
        ///                "isAlive": true,
        ///                "positionX": 0,
        ///                "positionY": 0
        ///            },
        ///            {
        ///                "isAlive": true,
        ///               "positionX": 0,
        ///               "positionY": 1
        ///            }
        ///       ]
        ///    }
        /// </remarks>
        /// <response code="200">True, action completed successfully</response>
        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> SetBoard([FromBody] BoardDTO boardDTO)
        {
            var board = DTOtoBoard(boardDTO);
            ConserveBoardInMemory.Set(board);
            return Ok(true);
        }

        private static Board DTOtoBoard(BoardDTO boardDTO)
        {
            Board board = new Board();
            foreach (CellDTO cellDTO in boardDTO.Table) board.Table.Add(DTOtoCell(cellDTO));

            return board; 

        }
        private static Cell DTOtoCell(CellDTO cellDTO)
        {
            int[] coordinates = new int[] { cellDTO.PositionX, cellDTO.PositionY };
            return new Cell(coordinates , cellDTO.IsAlive);
        }

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
    }
}


