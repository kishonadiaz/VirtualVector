namespace VirtualVector.HierarchyWindow;

using Microsoft.VisualStudio.Extensibility.UI;

/// <summary>
/// A remote user control to use as tool window UI content.
/// </summary>
internal class HierarchyToolWindowContent : RemoteUserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HierarchyToolWindowContent" /> class.
    /// </summary>
    public HierarchyToolWindowContent()
        : base(dataContext: new HierarchyToolWindowData())
    {
    }
}
