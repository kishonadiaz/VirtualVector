namespace VirtualVector.HierarchyWindow;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.ToolWindows;
using Microsoft.VisualStudio.RpcContracts.RemoteUI;

/// <summary>
/// A sample tool window.
/// </summary>
[VisualStudioContribution]
public class HierarchyToolWindow : ToolWindow
{
    private readonly HierarchyToolWindowContent content = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="HierarchyToolWindow" /> class.
    /// </summary>
    public HierarchyToolWindow()
    {
        this.Title = "Hierarchy";
    }

    /// <inheritdoc />
    public override ToolWindowConfiguration ToolWindowConfiguration => new()
    {
        // Use this object initializer to set optional parameters for the tool window.
        Placement = ToolWindowPlacement.DockedTo(new Guid("{b1e99781-ab81-11d0-b683-00aa00a3ee26}")),
        AllowAutoCreation = true,
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
