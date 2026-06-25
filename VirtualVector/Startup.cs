using EnvDTE80;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Editor;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualVector.Until;

namespace VirtualVector
{
    [VisualStudioContribution]
    public class Startup 
    {
       public  Startup() {
            
            EnvDTE80.DTE2 _dte2 = Package.GetGlobalService(typeof(EnvDTE.DTE)) as EnvDTE80.DTE2;
            DTE2 _dte = _dte2 as DTE2;

            TransferData transferData = new TransferData();

            //System.Windows.Forms.MessageBox.Show("Template loaded successfully kkkkk Visual Studio 2026!");


            Task.Run(async () =>
            {
                await Task.Delay(4000);
                //await transferData.TransferFoldersLiveAsync();
                if (_dte != null)
                {


                    System.Windows.Forms.MessageBox.Show($"VV Wizard Error: asjfkhakldjfs");
                    // Your _dte object is now fully ready to use
                    //System.Diagnostics.Debug.WriteLine($"Connected to: {_dte.Name} {_dte}");
                }
            });

        }
    }
}
