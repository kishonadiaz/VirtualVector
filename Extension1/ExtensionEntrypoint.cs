using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Commands;
using System.Windows.Controls;
using VirtualVector;

namespace Extension1
{
    /// <summary>
    /// Extension entrypoint for the VisualStudio.Extensibility extension.
    /// </summary>
    [VisualStudioContribution]
    public class ExtensionEntrypoint : Extension
    {
        //[VisualStudioContribution]
        //public static MenuConfiguration MyMenu => new("%VirtualVector.MyMenu.DisplayName%")
        //{

           
            
        //    Children = new[]
        //    {
        //        MenuChild.Command<testcommand>(),
        //    },
        //};
      
        /// <inheritdoc />
        public override ExtensionConfiguration ExtensionConfiguration => new()
        {
            RequiresInProcessHosting = true,
            
        };

       

        /// <inheritdoc />
        protected override void InitializeServices(IServiceCollection serviceCollection)
        {
            base.InitializeServices(serviceCollection);
            

            // You can configure dependency injection here by adding services to the serviceCollection.
        }
    }
}
