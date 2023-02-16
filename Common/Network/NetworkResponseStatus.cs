using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Network
{
    /// <summary>
    /// Статус ответа на запрос о сетевом сообщении
    /// </summary>
    public enum NetworkResponseStatus : byte
    {
        Successful,
        Failed,
        FatalError
    }
}
