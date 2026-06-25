using EnvDTE;
using Microsoft.VisualStudio.Extensibility.UI;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Events;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace VirtualVector.Scene_View
{
    /// <summary>
    /// ViewModel for the VVGuiToolWindowContent remote user control.
    /// </summary>
    [DataContract]
    //945646de920a5f85
    internal class VVGuiToolWindowData : NotifyPropertyChangedObject
    {
        public VVGuiToolWindowData()
        {
           

            



            EngineGuiCommand = new AsyncCommand((parameter, clientContext, cancellationToken) =>
            {
                Text = "Engine GUI opened!";
                EngineGui engineGui = new();
                return Task.CompletedTask;
            });
            HelloCommand = new AsyncCommand((parameter, clientContext, cancellationToken) =>
            {
                Text = $"Hello {parameter as string}!";
                return Task.CompletedTask;
            });
        }

        private void _solutionEvents_Opened()
        {
           
        }

        private string _name = string.Empty;
        [DataMember]
        public string Name
        {
            get => _name;
            set => SetProperty(ref this._name, value);
        }

        private string _text = string.Empty;
        [DataMember]
        public string Text
        {
            get => _text;
            set => SetProperty(ref this._text, value);
        }

        [DataMember]
        public AsyncCommand HelloCommand { get; }
        public AsyncCommand EngineGuiCommand { get; }

       

    }
    
}
