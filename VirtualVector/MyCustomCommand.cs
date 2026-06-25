using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVector
{
    public class MyCustomCommand
    {
        private readonly System.Diagnostics.TraceSource _logger;
        private readonly EnvDTE80.DTE2 _dte;

        public MyCustomCommand(System.Diagnostics.TraceSource logger, EnvDTE80.DTE2 dte)
        {
            _logger = logger;
            _dte = dte;
        }
        public void Execute()
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            // Now you can call your ToolWindow command safely
            //_dte.ExecuteCommand("VirtulVector.Scene_View.VVGuiToolWindowCommand");
        }
    }
}
