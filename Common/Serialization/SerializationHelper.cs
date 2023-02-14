using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace Common.Serialization
{
    /// <summary>
    /// Обертка над ProtoBuf для сериализации и десериализации
    /// </summary>
    public static class SerializationHelper
    {
        /// <summary>
        /// Сереализация
        /// </summary>
        /// <typeparam name="T">Тип класса, объект которого сериализует метод</typeparam>
        /// <param name="obj">сереализируемый объект</param>
        /// <returns>массив байт</returns>
        public static byte[] Serialize<T>(T obj)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    Serializer.Serialize(memoryStream, obj);
                    return memoryStream.ToArray();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Десериализует массив байтов в объект типа T
        /// </summary>
        /// <typeparam name="T">Тип класса, объект которого возвращает метод</typeparam>
        /// <param name="data">Данные в виде массива байт</param>
        /// <returns>объект типа T</returns>
        public static T Deserialize<T>(byte[] data)
        {
            try
            {
                using (var stream = new MemoryStream(data))
                {
                    T obj = Serializer.Deserialize<T>(stream);
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
