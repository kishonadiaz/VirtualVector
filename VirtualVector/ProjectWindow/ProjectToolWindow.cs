namespace VirtualVector.ProjectWindow;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.ToolWindows;
using Microsoft.VisualStudio.RpcContracts.RemoteUI;

/// <summary>
/// A sample tool window.
/// </summary>
[VisualStudioContribution]
public class ProjectToolWindow : ToolWindow
{
    private readonly ProjectToolWindowContent content = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectToolWindow" /> class.
    /// </summary>
    public ProjectToolWindow()
    {
        this.Title = "Project Window";
    }

    /// <inheritdoc />
    public override ToolWindowConfiguration ToolWindowConfiguration => new()
    {
        
        
        // Use this object initializer to set optional parameters for the tool window.
        Placement = ToolWindowPlacement.DockedTo(new Guid("{34e76e81-ee4a-11d0-ae2e-00a0c90fffc3}")),
        AllowAutoCreation = true,
        DockDirection = Dock.Bottom,
    };

    /// <inheritdoc />
    public override Task InitializeAsync(CancellationToken cancellationToken)
    {
        // Use InitializeAsync for any one-time setup or initialization.
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public override Task<IRemoteUserControl> GetContentAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult<IRemoteUserControl>(content);
    }

    /// <inheritdoc />
    protected override void Dispose(bool disposing)
    {
        if (disposing)
            content.Dispose();

        base.Dispose(disposing);
    }
}
