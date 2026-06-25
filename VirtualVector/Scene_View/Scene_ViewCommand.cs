using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Commands;
using System.Threading;
using System.Threading.Tasks;
using VirtualVector.ScriptExloper;
using VirtualVector.Until;

namespace VirtualVector.Scene_View
{
    /// <summary>
    /// A command for showing a tool window.
    /// </summary>
    [VisualStudioContribution]
    public class Scene_ViewCommand : Command
    {
        /// <inheritdoc />
        public override CommandConfiguration CommandConfiguration => new(displayName: "VirtualVector")
        {
            // Use this object initializer to set optional parameters for the command. The required parameter,
            // displayName, is set above. To localize the displayName, add an entry in .vsextension\string-resources.json
            // and reference it here by passing "%VirtualVector.Scene_View.Scene_ViewCommand.DisplayName%" as a constructor parameter.
            Placements = [CommandPlacement.KnownPlacements.ExtensionsMenu],
            Icon = new(ImageMoniker.KnownValues.Extension, IconSettings.IconAndText),
        };

        /// <inheritdoc />
        public override async Task ExecuteCommandAsync(IClientContext context, CancellationToken cancellationToken)
        {
            
            await this.Extensibility.Shell().ShowToolWindowAsync<Scene_View>(activate: true, cancellationToken); //await this.Extensibility.Shell().ShowToolWindowAsync<Game_View.GameViewToolWindow>(activate: true, cancellationToken);
            await this.Extensibility.Shell().ShowToolWindowAsync<Game_View.GameViewToolWindow>(activate: true, cancellationToken);
            await this.Extensibility.Shell().ShowToolWindowAsync<ProjectWindow.ProjectToolWindow>(activate: true, cancellationToken);
            await this.Extensibility.Shell().ShowToolWindowAsync<HierarchyWindow.HierarchyToolWindow>(activate: true, cancellationToken);
            await this.Extensibility.Shell().ShowToolWindowAsync<INspectorWindow.InspectorToolWindow>(activate: true, cancellationToken);
            await this.Extensibility.Shell().ShowToolWindowAsync<Script_Explorer>(activate: true, cancellationToken);
            


        }
    }
}
