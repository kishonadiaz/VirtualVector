using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Extensibility;

namespace VirtualVector4
{
    /// <summary>
    /// Extension entrypoint for the VisualStudio.Extensibility extension.
    /// </summary>
    [VisualStudioContribution]
    internal class ExtensionEntrypoint : Extension
    {
        /// <inheritdoc/>
        public override ExtensionConfiguration ExtensionConfiguration => new()
        {
            Metadata = new(
                    id: "VirtualVector4.6108ecfb-7a0a-4fe1-9402-ec416d334fbb",
                    version: this.ExtensionAssemblyVersion,
                    publisherName: "Publisher name",
                    displayName: "VirtualVector4",
                    description: "Extension description"),
        };

        /// <inheritdoc />
        //protected override void InitializeServices(IServiceCollection serviceCollection)
        //{
        //    base.InitializeServices(serviceCollection);

        //    // You can configure dependency injection here by adding services to the serviceCollection.
        //}
    }
}
