namespace VirtualVector.INspectorWindow;

using Microsoft.VisualStudio.Extensibility.UI;

/// <summary>
/// A remote user control to use as tool window UI content.
/// </summary>
internal class InspectorToolWindowContent : RemoteUserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InspectorToolWindowContent" /> class.
    /// </summary>
    public InspectorToolWindowContent()
        : base(dataContext: new InspectorToolWindowData())
    {
    }
}
