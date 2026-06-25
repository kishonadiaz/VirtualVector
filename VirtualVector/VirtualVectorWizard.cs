using EnvDTE;
using EnvDTE80;
using Extension1;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.Shell;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TemplateWizard;
using Microsoft.VisualStudio.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using VirtualVector.Scene_View;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Process = System.Diagnostics.Process;



namespace VirtualVector
{
    public class VirtualVectorWizard : IWizard
    {
        public static Dictionary<string, string> GlobalParameters = new Dictionary<string, string>();
       
        private EnvDTE80.DTE2 _dte;
        private EnvDTE.Events? _events;
        private EnvDTE.SolutionEvents? _solutionEvents;
  

        public void RunStarted(
            object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind,
            object[] customParams)
        {
            runKind = WizardRunKind.AsMultiProject;
            
            // Store DTE from automationObject
            // This is available here unlike RunFinished
            _dte = (EnvDTE80.DTE2)automationObject;

            

            //replacementsDictionary.Add("$projectname$", "VitrualVector");
            //replacementsDictionary.Add("$version$", "1.0.0");
            //replacementsDictionary.Add("$isenabled$", "true");
            //replacementsDictionary.Add("$maxretries$", "100");
            foreach (var param in GlobalParameters)
            {
                replacementsDictionary[param.Key] = param.Value;
            }

            replacementsDictionary["$myCustomClass$"] =
                "public class InjectedClass { public int Id { get; set; } }";
        }

        private void _solutionEvents_Opened()
        {
            
        }

        public void RunFinished()
        {
            //ThreadHelper.ThrowIfNotOnUIThread();
            ////EnvDTE80.DTE2 _dte2 = Package.GetGlobalService(typeof(EnvDTE.DTE)) as EnvDTE80.DTE2;
            ////DTE2 _dte = _dte2 as DTE2;



            ////System.Windows.Forms.MessageBox.Show("Template loaded successfully kkkkk Visual Studio 2026!");


            //Task.Run(async () =>
            //{

            //    //await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            //    await new VSSDKPackage().Start();

            //});

            try
            {


                //    Task.Run(async () =>
                //    {


                //        // Get the DTE service
                //        //var dte = (DTE2)await ServiceProvider.GetGlobalServiceAsync(typeof(SDTE));

                //        //if (dte != null && dte.ActiveSolutionProjects is Array activeProjects && activeProjects.Length > 0)
                //        //{
                //        //    // Retrieve the first active project object
                //        //    Project activeProject = (Project)activeProjects.GetValue(0);

                //        //    // Get the project name
                //        //    string projectName = activeProject.Name;
                //        //    System.Windows.Forms.MessageBox.Show($"VV Wizard: {projectName}");
                //        //}

                //        DTE dte = (DTE)ServiceProvider.GlobalProvider.GetService(typeof(DTE));

                //        if (dte != null && dte.Solution != null)
                //        {
                //            foreach (Project project in dte.Solution.Projects)
                //            {
                //                // Extract the template path/name used for the project
                //                string templateFile = project.Properties.Item("Template").Value.ToString();
                //                // Do something with templateFile
                //                System.Windows.Forms.MessageBox.Show($"VV Wizard kkkkshhsh: {templateFile}");
                //            }
                //        }

                //        await Task.Delay(4000);

                //        //if (_dte != null)
                //        //{
                //        //    _dte.ExecuteCommand("Run Engine");
                //        //    // Your _dte object is now fully ready to use
                //        //    //System.Diagnostics.Debug.WriteLine($"Connected to: {_dte.Name} {_dte}");
                //        //}

                //        //UIHierarchy solutionExplorer = _dte.ToolWindows.SolutionExplorer;

                //        //// Get array of selected items
                //        //object[] selectedItems = solutionExplorer.SelectedItems as object[];

                //        //if (selectedItems != null && selectedItems.Length > 0)
                //        //{
                //        //    var firstItem = selectedItems[0] as UIHierarchyItem;
                //        //    Debug.WriteLine("LIIE " + firstItem);
                //        //    // Your logic to inspect or modify the selected node
                //        //}
                //        //var listener = new HttpListener();
                //        //listener.Prefixes.Add("https://localhost:8081");

                //        //while (true)
                //        //{
                //        //    HttpListenerContext context = await listener.GetContextAsync();

                //        //    if (context.Request.IsWebSocketRequest)
                //        //    {
                //        //        _ = Task.Run(async () => await ProcessWebSocketAsync(context));
                //        //    }
                //        //    else
                //        //    {
                //        //        context.Response.StatusCode = 400;
                //        //        context.Response.Close();
                //        //    }
                //        //}

                //    });


                // Get the tool window GUIDs from your tool window classes
                // Each tool window class has a ToolWindowGuid attribute or property
                // You need to find or add these GUIDs in your tool window classes

                // Option 1: If you have GUID constants in your tool window classes
                // You'd access them like this:
                // var guid = typeof(VVGuiToolWindow).GUID;

                // Option 2: If your tool windows don't have explicit GUIDs yet,
                // you can create them in your .vsct file or use the class names directly

                // For now, let's use a simpler approach - find the tool windows by name
                // and show them using DTE's Window property
                System.Diagnostics.Debug.WriteLine($"VV Wizard: In here");
                foreach (EnvDTE.Window window in _dte.Windows)
                {

                    string caption = window.Caption;

                    System.Diagnostics.Debug.WriteLine($"VV Wizard: Found and showed window: {caption}");
                    if (caption.Contains("Scene View") ||
                        caption.Contains("Game View") ||
                        caption.Contains("Project View") ||
                        caption.Contains("Hierarchy") ||
                        caption.Contains("Inspector"))
                    {
                        window.Visible = true;
                        System.Diagnostics.Debug.WriteLine($"VV Wizard: Found and showed window: {caption}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"VV Wizard Error: {ex.Message}");
            }
            //System.Windows.Forms.MessageBox.Show("Template loaded successfully in Visual Studio 2026!");
            //Task.Run(async () =>
            //{
            //    await Task.Delay(1000);
            //    await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            //    try
            //    {
            //        _dte.ExecuteCommand(
            //            "VirtualVector.VVGuiToolWindowCommand"
            //        );
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Diagnostics.Debug.WriteLine(
            //            "VV Wizard: " + ex.Message
            //        );
            //    }
            //});
        }
        //private static async Task ProcessWebSocketAsync(HttpListenerContext context)
        //{
        //    HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(subProtocol: null);
        //    WebSocket webSocket = webSocketContext.WebSocket;
        //    Console.WriteLine("Client connected.");

        //    byte[] buffer = new byte[1024];

        //    try
        //    {
        //        // Keep the connection alive in a loop
        //        while (webSocket.State == WebSocketState.Open)
        //        {
        //            WebSocketReceiveResult result = await webSocket.ReceiveAsync(
        //                new ArraySegment<byte>(buffer), CancellationToken.None);

        //            if (result.MessageType == WebSocketMessageType.Close)
        //            {
        //                await webSocket.CloseAsync(
        //                    WebSocketCloseStatus.NormalClosure,
        //                    "Closing",
        //                    CancellationToken.None);
        //                break;
        //            }

        //            // Handle incoming text
        //            if (result.MessageType == WebSocketMessageType.Text)
        //            {
        //                string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
        //                Console.WriteLine($"Received: {message}");

        //                // Echo the message back (or handle your business logic here)
        //                byte[] responseBytes = Encoding.UTF8.GetBytes($"Server received: {message}");
        //                await webSocket.SendAsync(
        //                    new ArraySegment<byte>(responseBytes),
        //                    WebSocketMessageType.Text,
        //                    true,
        //                    CancellationToken.None);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Exception: {ex.Message}");
        //    }
        //    finally
        //    {
        //        webSocket.Dispose();
        //        Console.WriteLine("Client disconnected.");
        //    }
        //}

        public void ProjectFinishedGenerating(Project project) {
     


        }
        public void ProjectItemFinishedGenerating(ProjectItem projectItem) { }
        public bool ShouldAddProjectItem(string filePath) => true;
        public void BeforeOpeningFile(ProjectItem projectItem) { }
        //public void RunFinished() { 
           
        //    // Tool windows open via DTE command
        //    ThreadHelper.JoinableTaskFactory.Run(async () =>
        //    {
        //        await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
        //        var dte = (EnvDTE80.DTE2)Microsoft.VisualStudio.Shell.ServiceProvider
        //            .GlobalProvider
        //            .GetService(typeof(DTE));

        //        // Execute your existing command that opens all windows
        //        dte.ExecuteCommand("VirtualVector.VVGuiToolWindowCommand");
        //    });

        //}
    }

}
