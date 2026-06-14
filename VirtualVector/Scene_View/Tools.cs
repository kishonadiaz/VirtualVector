using Microsoft.VisualStudio.Extensibility.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VirtualVector.Scene_View
{
    public class Tools:ToolBar
    {
       public  Tools() {
            this.Name = "Tools";

       }

        public static ToolbarConfiguration MyToolbar => new("%VirtualVector.MyToolbar.DisplayName%")
        {
            Placements = new[] {
                CommandPlacement.VsctParent(new Guid("{d309f791-903f-11d0-9efc-00a0c911004f}"),0000,0)


            },
            Children = new[]
          {
                ToolbarChild.Command<testcommand>(),
            },
        };
    }
}
