using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceHub.Framework;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Shell;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using VirtualVector;
using VirtualVector.Scene_View;



namespace VirtualVector
{
    [VisualStudioContribution]

    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid("270de947-7b51-4980-a534-daa88b57a24d")]

    // Autoloads when a solution exists and loads in the background
    [ProvideAutoLoad(VSConstants.UICONTEXT.SolutionExists_string, PackageAutoLoadFlags.BackgroundLoad)]

    // Optional: Autoloads immediately when Visual Studio starts
    [ProvideAutoLoad(VSConstants.UICONTEXT.NoSolution_string, PackageAutoLoadFlags.BackgroundLoad)]
    public class ExtensionEntrypoint : Extension
    {
        private EnvDTE.Events? _events;
        private EnvDTE.SolutionEvents? _solutionEvents;
        public static IServiceCollection _service;
        ServiceCollection services = new ServiceCollection();
        public Startup startup = new Startup();

        public static  VisualStudioExtensibility _vsExtensibility;

       

        // The SDK automatically injects the extensibility service
        public override ServiceRpcDescriptor GetServiceDescriptor(ServiceMoniker serviceMoniker)
        {
            
            return base.GetServiceDescriptor(serviceMoniker);

        }

     
        public ExtensionEntrypoint():base()
        {
           
        }
        private static void _solutionEvents_Opened()
        {
            throw new NotImplementedException();
        }

        public override ExtensionConfiguration ExtensionConfiguration => new()
        {


            RequiresInProcessHosting = true

            
           
        };

        public async void Start()
        {
            
            //VirtualVector.Scene_View.VVGuiToolWindowCommand.LaunchAllEngineWindowsAsync()
        }

        protected override void InitializeServices(IServiceCollection serviceCollection)

        {
            _service = serviceCollection;
            services.AddActivatedSingleton<IServiceCollection>();
            base.InitializeServices(serviceCollection);
            
        }

        public override IServiceFactory GetFactory(ServiceMoniker serviceMoniker)
        {
           
            return base.GetFactory(serviceMoniker);
        }
        protected override async Task OnInitializedAsync(VisualStudioExtensibility extensibility, CancellationToken cancellationToken)
        {
            await base.OnInitializedAsync(extensibility, cancellationToken);
            //await Task.Delay(3000, cancellationToken);

            //await VirtualVector.Scene_View.VVGuiToolWindowCommand
            //    .LaunchAllEngineWindowsAsync(extensibility, cancellationToken);

           

            // Your existing code...
            //_solutionEvents = new VVSolutionEvents(extensibility);
            //await _solutionEvents.InitializeAsync(cancellationToken);

            //System.Diagnostics.Debug.WriteLine("VV: Extension initialized");
            //await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();



            //var dte = await Microsoft.VisualStudio.Shell.AsyncServiceProvider.GlobalProvider.GetServiceAsync(typeof(EnvDTE.DTE)) as EnvDTE.DTE;
            //if (dte != null)
            //{
            //    _events = dte.Events;
            //    _solutionEvents = _events.SolutionEvents;

            //    // Unified launcher logic using our newly extracted command class method
            //    Action triggerEngineLayout = () =>
            //    {
            //        _ = Task.Run(async () =>
            //        {
            //            try
            //            {
            //                // Let the template project build and load files into memory first
            //                await Task.Delay(1500);

            //                // 3. PROGRAMMATIC INVOCATION: Runs the extracted method directly
            //                await VirtualVector.Scene_View.VVGuiToolWindowCommand.LaunchAllEngineWindowsAsync(extensibility, CancellationToken.None);
            //            }
            //            catch (Exception ex)
            //            {
            //                System.Diagnostics.Debug.WriteLine($"Engine auto-start failed: {ex.Message}");
            //            }
            //        });
            //    };

            //    // Triggers when a template project is initialized
            //    _solutionEvents.ProjectAdded += (EnvDTE.Project project) =>
            //    {
            //        _ = ThreadHelper.JoinableTaskFactory.StartOnIdle(async () =>
            //        {
            //            await Task.Delay(2000);
            //            await VirtualVector.Scene_View.VVGuiToolWindowCommand
            //                .LaunchAllEngineWindowsAsync(extensibility, CancellationToken.None);

            //        });
            //    };
            //    _solutionEvents.Opened += () =>
            //    {
            //        _ = ThreadHelper.JoinableTaskFactory.StartOnIdle(async () =>
            //        {
            //            await Task.Delay(2000);
            //            await VirtualVector.Scene_View.VVGuiToolWindowCommand
            //                .LaunchAllEngineWindowsAsync(extensibility, CancellationToken.None);

            //        });
            //    };
            //}
        }
    }

    

}

