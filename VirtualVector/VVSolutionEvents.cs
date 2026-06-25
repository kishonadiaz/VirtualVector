using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Shell;
using System.Threading;
using System.Threading.Tasks;


namespace VirtualVector
{
    [VisualStudioContribution]
    public class VVSolutionEvents: ExtensionPart
    {
        private DTE2 _dte;
        private EnvDTE.SolutionEvents _solutionEvents;
        private VisualStudioExtensibility _extensibility;

        public VVSolutionEvents(Extension container,VisualStudioExtensibility extensibility):base(container,extensibility)
        {
            System.Windows.Forms.MessageBox.Show("Template aasafdsf");

        }

        public async Task InitializeAsync(CancellationToken cancellationToken)
        {
            _ = Task.Run(() => OnSolutionOpened(cancellationToken), cancellationToken);
            //return Task.CompletedTask;

        }

        private void OnSolutionOpened(CancellationToken cancellationToken)
        {
            ThreadHelper.JoinableTaskFactory.Run(async () =>
            {
                await _extensibility.Shell()
                    .ShowToolWindowAsync<Scene_View.VVGuiToolWindow>(
                        activate: true, cancellationToken);

                await _extensibility.Shell()
                    .ShowToolWindowAsync<Game_View.GameViewToolWindow>(
                        activate: true, cancellationToken);

                await _extensibility.Shell()
                    .ShowToolWindowAsync<ProjectWindow.ProjectToolWindow>(
                        activate: true, cancellationToken);

                await _extensibility.Shell()
                    .ShowToolWindowAsync<HierarchyWindow.HierarchyToolWindow>(
                        activate: true, cancellationToken);

                await _extensibility.Shell()
                    .ShowToolWindowAsync<INspectorWindow.InspectorToolWindow>(
                        activate: true, cancellationToken);
            });
        }
    }
}