﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Net.IO
{
    /// <summary>
    /// Конструктор пакетов
    /// </summary>
    public class PacketBuilder
    {
        /// <summary>
        /// Создает поток, резервным хранилищем которого является память.
        /// </summary>
        MemoryStream _ms;
        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }

        /// <summary>
        /// Записывает байт в текущее положение текущего потока.
        /// </summary>
        /// <param name="opCode"></param>
        public void WriteOpCode(byte opCode)
        {
            _ms.WriteByte(opCode);
        }


        public void WriteMessage(string msg)
        {
            var unicodeMessage = Encoding.UTF8.GetBytes(msg);

            var msgLenght = unicodeMessage.Length;

            _ms.Write(BitConverter.GetBytes(msgLenght));

            _ms.Write(unicodeMessage);
        }
        public byte[] GetPacketBytes()
        {
            return _ms.ToArray();
        }
    }
}
