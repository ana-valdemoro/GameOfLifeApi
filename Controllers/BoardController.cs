using GameOfLifeApi2.DataTransferObjects;
using GameOfLifeApi2.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameOfLifeApi2.Controllers
{
    [Route("api/Board")]
    [Produces("application/json")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        public IConserveBoard ConserveBoardInMemory;

        public BoardController(IConserveBoard board)
        {
            ConserveBoardInMemory = board;
        }

        /// <summary>
        /// Get current board saved in memory.
        /// </summary>
        /// <response code="200">Action completed successfully</response>
        /// <response code="404">Board not founded</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BoardDTO> GetCurrentBoard()
        {
            var board = ConserveBoardInMemory.Get();
            if (board == null) return NotFound("Board was not found in memory");
            var boardResult = board.ToDTO();
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
            var boardResult = board.ToDTO();
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
        /// <response code="400">Bad request</response>
        [Consumes("application/json")] 
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BoardDTO> SetBoard([FromBody] BoardDTO boardDTO)
        {
            if(boardDTO == null || !ModelState.IsValid) return BadRequest("Board is null");
            var board = BoardMapper.DTOtoBoard(boardDTO);
            ConserveBoardInMemory.Set(board);
            var ResultBoardDTO = ConserveBoardInMemory.Get().ToDTO();
            return Ok(ResultBoardDTO);
        }

       
    }
}


