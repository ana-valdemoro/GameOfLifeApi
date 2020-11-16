using System;
using System.Collections.Generic;


namespace GameOfLifeApi2.Models {

    public class Cell
    {
        public Boolean IsAlive { set; get; }
        public int PositionX { set; get; }
        public int PositionY { set; get; }

        public Cell(int[] position, Boolean status)
        {
            IsAlive = status;
            this.PositionX = position[0];
            this.PositionY = position[1];
        }

    }
    
}
