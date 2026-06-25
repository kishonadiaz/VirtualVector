using Microsoft.VisualStudio.Extensibility.UI;

namespace VirtualVector.Scene_View
{
    /// <summary>
    /// A remote user control to use as tool window UI content.
    /// </summary>
    internal class Scene_ViewContent : RemoteUserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Scene_ViewContent" /> class.
        /// </summary>
        public Scene_ViewContent()
            : base(dataContext: new Scene_ViewData())
        {
        }
    }
}
