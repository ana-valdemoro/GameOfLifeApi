using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameOfLifeApi2.DataTransferObjects;
using GameOfLifeApi2.Models;
using GameOfLifeApi2.Repository;
using GameOfLifeAPI2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;

namespace GameOfLifeApi2.Controllers
{
    [Route("api/GameOfLife")]
    [ApiController]
    public class GameOfLifeController : ControllerBase
    {
        //public static Board InitialBoard = new Board(new int[,] { { 1, 1 } });
        public ConserveBoard ConserveBoardInMemory;

        public GameOfLifeController(ConserveBoard board)
        {
            ConserveBoardInMemory = board;
        }


        [HttpGet]
        public ActionResult<BoardDTO> GetCurrentBoard()
        {
            var board = ConserveBoardInMemory.Get();
            var boardResult = BoardToDTO(board);
            return Ok(boardResult);


        }

        [HttpPost]
        public ActionResult<BoardDTO> ObtainNextBoard()
        {
            var board = ConserveBoardInMemory.Update();
            var boardResult = BoardToDTO(board);
            return Ok(boardResult);
        }

        /*[HttpPost("{id}")]
        [Consumes("text/plain")]
        public string JsonStringBody([FromBody] string content)
        {
            
            ConserveBoardInMemory.Set(JsonConvert.DeserializeObject<Board>(content));
          
            return "pepa";
            //Json configuration = JsonConvert.SerializeObject(content);

        }*/
        [HttpPost("{id}")]
        public ActionResult<BoardDTO> InitializeBoard([FromBody] BoardDTO content)
        {
             //ConserveBoardInMemory.Set(content);
            //var boardResult = BoardToDTO(board);
            return Ok(content);
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
            };
    }
}


