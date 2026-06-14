using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Commands;
using Microsoft.VisualStudio.Extensibility.ToolWindows;
using Microsoft.VisualStudio.RpcContracts.RemoteUI;
using System.Threading;
using System.Threading.Tasks;

namespace VirtualVector.Scene_View
{
    /// <summary>
    /// A sample tool window.
    /// </summary>
    [VisualStudioContribution]
    public class VVGuiToolWindow : ToolWindow
    {
        private readonly VVGuiToolWindowContent content = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="VVGuiToolWindow" /> class.
        /// </summary>
        public VVGuiToolWindow()
        {
            this.Title = "My Tool Window";
            var cusomtone = new CustomCommand(new System.Diagnostics.TraceSource("VVGuiToolWindow"));
            var c2 = new CustomCommand(new System.Diagnostics.TraceSource("VVGuiToolWindow"));
        }

        /// <inheritdoc />
        public override ToolWindowConfiguration ToolWindowConfiguration => new()
        {
            // Use this object initializer to set optional parameters for the tool window.
            Placement = ToolWindowPlacement.DocumentWell,
            //Toolbar = new ToolWindowToolbar(Toolbar)
        };



        //[VisualStudioContribution]
        //private static ToolbarConfiguration Toolbar => new("%VirtualVector.Toolbar.DisplayName%")
        //{
        //    // Use this object initializer to set optional parameters for the toolbar. The required parameter,
        //    // displayName, is set above. DisplayName is localized and references an entry in .vsextension\string-resources.json.
        //   Children = [ToolbarChild.Command<VVGuiToolWindowCommand>()]
        //};

        [VisualStudioContribution]
        public static ToolbarConfiguration MyToolbar => new("%VirtualVector.MyToolbar.DisplayName%")
        {
            
            Placements = new[] {
                CommandPlacement.VsctParent(new Guid("{d309f791-903f-11d0-9efc-00a0c911004f}"),0000,100)


            },
            Children = new[]
         {

                ToolbarChild.Command<testcommand>(),
            },
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
}
