namespace VirtualVector.ProjectWindow;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Commands;

/// <summary>
/// A command for showing a tool window.
/// </summary>
[VisualStudioContribution]
public class ProjectToolWindowCommand : Command
{
    /// <inheritdoc />
    public override CommandConfiguration CommandConfiguration => new(displayName: "Show Tool Window")
    {
        // Use this object initializer to set optional parameters for the command. The required parameter,
        // displayName, is set above. To localize the displayName, add an entry in .vsextension\string-resources.json
        // and reference it here by passing "%VirtualVector.ProjectWindow.ProjectToolWindowCommand.DisplayName%" as a constructor parameter.
        //Placements = [CommandPlacement.KnownPlacements.ExtensionsMenu],
        //Icon = new(ImageMoniker.KnownValues.Extension, IconSettings.IconAndText),
    };

    /// <inheritdoc />
    public override async Task ExecuteCommandAsync(IClientContext context, CancellationToken cancellationToken)
    {
        await this.Extensibility.Shell().ShowToolWindowAsync<ProjectToolWindow>(activate: true, cancellationToken);
    }
}
