﻿using System.Collections.Generic;

namespace GameOfLifeApi2.Models
{
    public class Board
    {

        public List<Cell> Table { set; get; }

        public Board(int[,] values)
        {
            Table = new List<Cell>(values.GetLength(0));
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    int[] coordinates = new int[] { i, j };
                    if (values[i, j] == 0)
                    {
                        Table.Add(new Cell(coordinates, false));
                    }
                    else
                    {
                        Table.Add(new Cell(coordinates, true));
                    }
                }
            }

        }

        public Board()
        {
            Table = new List<Cell>();
        }

        public Board Next_generation()
        {
            List<Cell> nextGeneration = this.Table.ConvertAll(cell => {
                int[] coordinates = new int[] { cell.PositionX, cell.PositionY };
                return new Cell(coordinates, cell.IsAlive);
            });
            foreach (Cell cell in nextGeneration)
            {
                int aliveNeighbours = CountAliveNeighbours(this.Table, cell);
                cell.IsAlive = UpdateCellStatus(cell, aliveNeighbours);

            }
            Table = nextGeneration;
            return this;
        }

        private static bool UpdateCellStatus(Cell cell, int aliveNeighbours)
        {
            if (cell.IsAlive)
            {
                if (aliveNeighbours < 2 | aliveNeighbours > 3) return false;

            }
            else
            {
                if (aliveNeighbours == 3) return true;
            }
            return cell.IsAlive;
        }

        public static int CountAliveNeighbours(List<Cell> initial_table, Cell cell)
        {
            int aliveNeighbours = 0;

            aliveNeighbours += CountNeighbours(initial_table, cell.PositionX, cell.PositionY + 1);
            aliveNeighbours += CountNeighbours(initial_table, cell.PositionX, cell.PositionY - 1);
            aliveNeighbours += CountNeighbours(initial_table, cell.PositionX + 1, cell.PositionY);
            aliveNeighbours += CountNeighbours(initial_table, cell.PositionX - 1, cell.PositionY);
            aliveNeighbours += CountNeighbours(initial_table, cell.PositionX + 1, cell.PositionY + 1);
            aliveNeighbours += CountNeighbours(initial_table, cell.PositionX - 1, cell.PositionY + 1);
            aliveNeighbours += CountNeighbours(initial_table, cell.PositionX + 1, cell.PositionY - 1);
            aliveNeighbours += CountNeighbours(initial_table, cell.PositionX - 1, cell.PositionY - 1);

            return aliveNeighbours;
        }

        public static int CountNeighbours(List<Cell> initial_table, int positionX, int positionY)
        {
            int aliveNeighbours = 0;
            Cell result = initial_table.Find(cell2 => (cell2.PositionX == positionX && cell2.PositionY == positionY));
            if (result != null && result.IsAlive) aliveNeighbours++;
            return aliveNeighbours;
        }

    }
}
