using System.Collections.Generic;
namespace oop3
{
    /// <summary>
    /// класс инфы для сериализации
    /// </summary>
    public class SerializationInfo
    {
        public List<FigureInfo> Figures { get; set; }
        public bool IsFirstPlayerMove { get; set; }
        public bool IsFirstPlayerHuman { get; set; }
        public bool IsSecondPlayerHuman { get; set; }
    }
}
