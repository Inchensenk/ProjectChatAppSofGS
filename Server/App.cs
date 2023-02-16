using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class App
    {
        private ConnectionController _connectionController;
        public App()
        {
            _connectionController = new ConnectionController();
        }

        public async Task LaunchAsync()
        {
            await _connectionController.RunAsync();
        }
    
    }
}
