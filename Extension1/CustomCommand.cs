using Extension1;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVector
{
    [VisualStudioContribution]
    public class CustomCommand : testcommand
    {
        public CustomCommand(TraceSource traceSource) : base(traceSource)
        {
        }

        public override CommandConfiguration CommandConfiguration => base.CommandConfiguration;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override Task ExecuteCommandAsync(IClientContext context, CancellationToken cancellationToken)
        {
            return base.ExecuteCommandAsync(context, cancellationToken);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override Task InitializeAsync(CancellationToken cancellationToken)
        {
            return base.InitializeAsync(cancellationToken);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
