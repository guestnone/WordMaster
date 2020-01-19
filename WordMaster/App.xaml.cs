using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Serilog;

namespace WordMaster
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ILogger logger;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("WordMaster.log").CreateLogger();
        }
    }
}
