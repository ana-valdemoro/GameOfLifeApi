using GameOfLife.DataTransferObjects;
using GameOfLifeApi2.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights;

namespace GameOfLifeApi2.Controllers {
    [Route("api/Board")]
    [Produces("application/json")]
    [ApiController]
    public class BoardController : ControllerBase {
        public IConserveBoard ConserveBoardInMemory;
        private readonly ILogger Logger;
        private TelemetryClient telemetry;



        public BoardController(IConserveBoard board, ILogger<BoardController> logger, TelemetryClient telemetryClient) {
            ConserveBoardInMemory = board;
            Logger = logger;
            telemetry = telemetryClient;
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
            telemetry.TrackEvent("Custom HTTP GET method");
            Logger.LogInformation("Call to HTTP GET Method");
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
            telemetry.TrackEvent("Custom HTTP Post method");
            Logger.LogInformation("Call to HTTP Post Method");
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
            telemetry.TrackEvent("Custom HTTP Post Method in /SetBoard URL");
            Logger.LogInformation("Call to HTTP Post Method in /SetBoard URL");
            if (boardDTO == null || !ModelState.IsValid) return BadRequest("Board is null");
            var board = BoardMapper.DTOtoBoard(boardDTO);
            var ResultBoardDTO = ConserveBoardInMemory.Set(board).ToDTO();
            return Ok(ResultBoardDTO);
        }

       
    }
}


