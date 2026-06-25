using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Shell;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVector
{
    internal class VVSPackage
    {
    }

    [VisualStudioContribution]
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [ProvideAutoLoad(VSConstants.UICONTEXT.NoSolution_string, PackageAutoLoadFlags.BackgroundLoad)]
    [Guid("270de947-7b51-4980-a534-daa88b57a24d")]
    public class VSSDKPackage : AsyncPackage


    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);

            // Switch to the main thread only if UI work is required
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            VisualStudioExtensibility extensibility = await this.GetServiceAsync<VisualStudioExtensibility, VisualStudioExtensibility>();
            await extensibility.Shell().ShowPromptAsync("Hello from in-proc", PromptOptions.OK, cancellationToken);

        }

        public async Task Start()
        {
            //await JoinableTaskFactory.SwitchToMainThreadAsync(CancellationToken.None);
            VisualStudioExtensibility extensibility = await this.GetServiceAsync<VisualStudioExtensibility, VisualStudioExtensibility>();
            await extensibility.Shell().ShowPromptAsync("Hello from in-proc", PromptOptions.OK, CancellationToken.None);

        }
    }
}
