namespace VirtualVector.Game_View;

using Microsoft.VisualStudio.Extensibility.UI;

/// <summary>
/// A remote user control to use as tool window UI content.
/// </summary>
internal class GameViewToolWindowContent : RemoteUserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GameViewToolWindowContent" /> class.
    /// </summary>
    public GameViewToolWindowContent()
        : base(dataContext: new GameViewToolWindowData())
    {
    }
}
