using System;
using System.Collections.Generic;


namespace GameOfLifeAPI2.Models {

    public class Cell
    {
        public Boolean isAlive { set; get; }
        public int positionX { set; get; }
        public int positionY { set; get; }

        public Cell(int[] position, Boolean status)
        {
            isAlive = status;
            this.positionX = position[0];
            this.positionY = position[1];
        }

    }
    
}
