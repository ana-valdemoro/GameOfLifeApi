using System;
using System.Collections.Generic;


namespace GameOfLifeAPI2.Models {

    public class Cell
    {
        public Boolean isAlive { set; get; }
        public int PositionX { set; get; }
        public int PositionY { set; get; }

        public Cell(int[] position, Boolean status)
        {
            isAlive = status;
            this.PositionX = position[0];
            this.PositionY = position[1];
        }

    }
    
}
