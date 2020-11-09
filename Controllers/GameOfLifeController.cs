using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameOfLifeApi2.Models;
using GameOfLifeApi2.Repository;
using GameOfLifeAPI2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public ActionResult<String> Get()
        {
            string board = JsonConvert.SerializeObject(ConserveBoardInMemory.Get());
            return Ok(board);
            

        }

        [HttpPost]
        public ActionResult<String> Post()
        {
            string board = JsonConvert.SerializeObject(ConserveBoardInMemory.Update());
            return Ok(board);
        }

        [HttpPost("{id}")]
        [Consumes("text/plain")]
        public string JsonStringBody([FromBody] string content)
        {
            
            ConserveBoardInMemory.Set(JsonConvert.DeserializeObject<Board>(content));
          
            return "pepa";
            //Json configuration = JsonConvert.SerializeObject(content);

        }

    }
}
