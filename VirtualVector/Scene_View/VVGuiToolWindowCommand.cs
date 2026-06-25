using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Commands;
using Microsoft.VisualStudio.Shell;
using System.Threading;
using System.Threading.Tasks;

namespace VirtualVector.Scene_View
{
    /// <summary>
    /// A command for showing a tool window.
    /// </summary>
    [VisualStudioContribution]
    public class VVGuiToolWindowCommand : Command
    {
        
       
        
        /// <inheritdoc />
        public override CommandConfiguration CommandConfiguration => new(displayName: "Run Engine")
        {
            // Use this object initializer to set optional parameters for the command. The required parameter,
            // displayName, is set above. To localize the displayName, add an entry in .vsextension\string-resources.json
            // and reference it here by passing "%VirtualVector.VVGuiToolWindowCommand.DisplayName%" as a constructor parameter.
            //Placements = [CommandPlacement.KnownPlacements.ExtensionsMenu],
            //Icon = new(ImageMoniker.KnownValues.Extension, IconSettings.IconAndText),
            
            
        };

        public override Task InitializeAsync(CancellationToken cancellationToken)
        {
           
            
            return base.InitializeAsync(cancellationToken);
        }

       
        

        /// <inheritdoc />
        public override async Task ExecuteCommandAsync(IClientContext context, CancellationToken cancellationToken)
        {
            await this.Extensibility.Shell().ShowToolWindowAsync<VVGuiToolWindow>(activate: true, cancellationToken);
           
            //await this.Extensibility.Shell().ShowToolWindowAsync<ProjectWindow.ProjectToolWindow>(activate: true, cancellationToken);
            //await this.Extensibility.Shell().ShowToolWindowAsync<HierarchyWindow.HierarchyToolWindow>(activa //await this.Extensibility.Shell().ShowToolWindowAsync<Game_View.GameViewToolWindow>(activate: true, cancellationToken);te: true, cancellationToken);
            //await this.Extensibility.Shell().ShowToolWindowAsync<INspectorWindow.InspectorToolWindow>(activate: true, cancellationToken);




        }
    }
}
