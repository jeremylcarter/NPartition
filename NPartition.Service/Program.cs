using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace NPartition.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            try
            {
                if (WindowsServiceHelper.ManageServiceIfRequested(Environment.GetCommandLineArgs()))
                    return;
            }
            catch (Exception)
            {
            }

            if (Environment.CommandLine.Contains("-console"))
            {
                WindowsServiceHelper.RunAsConsoleIfRequested<NPartitionService>();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                    new NPartitionService()
                };

                ServiceBase.Run(ServicesToRun);
            }

        }
    }
}
