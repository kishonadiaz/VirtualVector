using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.ToolWindows;
using Microsoft.VisualStudio.RpcContracts.RemoteUI;
using System.Threading;
using System.Threading.Tasks;

namespace VirtualVector.ScriptExloper
{
    /// <summary>
    /// A sample tool window.
    /// </summary>
    [VisualStudioContribution]
    public class Script_Explorer : ToolWindow
    {
        private readonly Script_ExloporerContent content = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="Script_Explorer" /> class.
        /// </summary>
        public Script_Explorer()
        {
            this.Title = "Script Explorer";
        }

        /// <inheritdoc />
        public override ToolWindowConfiguration ToolWindowConfiguration => new()
        {
            // Use this object initializer to set optional parameters for the tool window.
            Placement = ToolWindowPlacement.DockedTo(new Guid("{3ae79031-e1bc-11d0-8f78-00a0c9110057}"))
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
