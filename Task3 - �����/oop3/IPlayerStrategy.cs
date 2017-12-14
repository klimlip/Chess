using System.Collections.Generic;
namespace oop3
{
    /// <summary>
    /// интерфейс для паттерна Strategy, Context = Player
    /// </summary>
    public interface IPlayerStrategy
    {
        void DoMove(List<Move> possibleMoves);//метод хода
    }
}
