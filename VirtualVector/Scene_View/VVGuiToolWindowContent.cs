using Microsoft.VisualStudio.Extensibility.UI;

namespace VirtualVector.Scene_View
{
    /// <summary>
    /// A remote user control to use as tool window UI content.
    /// </summary>
    public class VVGuiToolWindowContent : RemoteUserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VVGuiToolWindowContent" /> class.
        /// </summary>
        public VVGuiToolWindowContent()
            : base(dataContext: new VVGuiToolWindowData())
        {
            
        }
    }
}
