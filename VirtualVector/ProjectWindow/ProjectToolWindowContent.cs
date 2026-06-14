namespace VirtualVector.ProjectWindow;

using Microsoft.VisualStudio.Extensibility.UI;

/// <summary>
/// A remote user control to use as tool window UI content.
/// </summary>
internal class ProjectToolWindowContent : RemoteUserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectToolWindowContent" /> class.
    /// </summary>
    public ProjectToolWindowContent()
        : base(dataContext: new ProjectToolWindowData())
    {
    }
}
