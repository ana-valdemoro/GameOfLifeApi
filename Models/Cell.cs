using System;
using GameOfLifeApi2.DataTransferObjects;


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
        public CellDTO ToDTO() =>
            new CellDTO
            {
                IsAlive = IsAlive,
                PositionX = PositionX,
                PositionY = PositionY
            };

    }
    
}
