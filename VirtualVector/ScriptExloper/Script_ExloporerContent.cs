using Microsoft.VisualStudio.Extensibility.UI;

namespace VirtualVector.ScriptExloper
{
    /// <summary>
    /// A remote user control to use as tool window UI content.
    /// </summary>
    internal class Script_ExloporerContent : RemoteUserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Script_ExloporerContent" /> class.
        /// </summary>
        public Script_ExloporerContent()
            : base(dataContext: new Script_ExloporerData())
        {
        }
    }
}
