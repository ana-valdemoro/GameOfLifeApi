using GameOfLifeApi2.Models;

namespace GameOfLifeApi2.Resources
{
    public interface IConserveBoard
    {
        public void Set(Board newBoard);
        public Board Get();
        public Board Update();
    }
}
