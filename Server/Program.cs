using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            App app = new App();
            await app.LaunchAsync();
        }
        
    }
}
