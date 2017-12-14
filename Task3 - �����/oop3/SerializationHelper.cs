using System.IO;
using System.Xml.Serialization;
namespace oop3
{
    /// <summary>
    /// класс для сериализации и десериализации
    /// </summary>
    public static class SerializationHelper
    {
        /// <summary>
        /// метод сериализации
        /// </summary>
        /// <param name="name"></param>
        /// <param name="info"></param>
        public static void Serialize(string name, SerializationInfo info)
        {
            using (var stream = GetSerializeStream(name))
            {
                var serializer = new XmlSerializer(typeof(SerializationInfo));
                serializer.Serialize(stream, info);
            }
        }

        /// <summary>
        /// метод получения сохраненных данных (десериализация)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static SerializationInfo Deserialize(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(SerializationInfo));
                return (SerializationInfo)serializer.Deserialize(stream);
            }
        }

        /// <summary>
        /// метод создания экземпляра класса Stream для сериализации
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static Stream GetSerializeStream(string name)
        {
            const string ext = ".save";
            var fullName = string.Format("{0}.{1}", name, ext);
            var stream = new FileStream(fullName, FileMode.Create);
            return stream;
        }
    }
}
