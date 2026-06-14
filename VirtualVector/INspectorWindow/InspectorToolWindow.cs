namespace VirtualVector.INspectorWindow;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.ToolWindows;
using Microsoft.VisualStudio.RpcContracts.RemoteUI;

/// <summary>
/// A sample tool window.
/// </summary>
[VisualStudioContribution]
public class InspectorToolWindow : ToolWindow
{
    private readonly InspectorToolWindowContent content = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="InspectorToolWindow" /> class.
    /// </summary>
    public InspectorToolWindow()
    {
        this.Title = "My Tool Window";
    }

    /// <inheritdoc />
    public override ToolWindowConfiguration ToolWindowConfiguration => new()
    {
        // Use this object initializer to set optional parameters for the tool window.
        Placement = ToolWindowPlacement.DockedTo(new Guid("{3ae79031-e1bc-11d0-8f78-00a0c9110057}")),
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
