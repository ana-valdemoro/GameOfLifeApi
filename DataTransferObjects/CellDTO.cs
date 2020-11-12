using System;
using System.ComponentModel.DataAnnotations;

namespace GameOfLifeApi2.DataTransferObjects
{
    public class CellDTO{
        [Required]
        public Boolean IsAlive { set; get; }
        [Required]
        public int PositionX { set; get; }
        [Required]
        public int PositionY { set; get; }

    }
}
