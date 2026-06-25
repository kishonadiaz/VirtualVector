using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.IO;
using System.Threading.Tasks;

namespace VirtualVector.Until
{
    public class TransferData
    {
        private async void AddDir(String dirname)
        {
            // Get the DTE2 service
            DTE2 dte2 = (DTE2)await ServiceProvider.GetGlobalServiceAsync(typeof(DTE));
            if (dte2 == null || dte2.Solution == null) return;

            foreach (EnvDTE.Window window in dte2.Windows)
            {

                string caption = window.Caption;

                if (caption.Contains("Solution"))
                {

                    Solution2 soln = (Solution2)dte2.Solution;
                    if (soln.Projects.Count <= 0) return;
                    System.Windows.Forms.MessageBox.Show($"VV Wizard : {soln.Projects.Item(1).FullName}");
                   


                    string projectDirectory = System.IO.Path.GetDirectoryName(soln.Projects.Item(1).FullName);
                    string targetPath = System.IO.Path.Combine(projectDirectory, dirname);


                    if (!System.IO.Directory.Exists(targetPath))
                    {
                        soln.Projects.Item(1).ProjectItems.AddFolder(dirname, EnvDTE.Constants.vsProjectItemKindPhysicalFolder);

                        soln.Projects.Item(1).Save();

                    }

                   
                }
               
            }

        }
        public async Task TransferFoldersLiveAsync()
        {
            // Switch to the UI thread to safely interact with DTE
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            AddDir("Project_View");
            AddDir("Scripts");



            //// 1. Find the actual compiled project (skipping any virtual solution folders)
            //Project targetProject = null;
            //foreach (Project proj in dte2.Solution.Projects)
            //{
            //    // Ensure it is a valid project with items and a physical location
            //    if (proj.ProjectItems != null && !string.IsNullOrEmpty(proj.FullName))
            //    {
            //        targetProject = proj;
            //        break;
            //    }
            //}

            //// Fallback safety if the loop missed it
            //if (targetProject == null && dte2.Solution.Projects.Count > 0)
            //{
            //    targetProject = dte2.Solution.Projects.Item(1);
            //}

            //if (targetProject == null) return;

            //// 2. Get your extension's source folder path
            //string extensionPath = Path.GetDirectoryName(typeof(TransferData).Assembly.Location);
            //string sourceFolder = Path.Combine(extensionPath, "CustomTemplateFolders");

            //if (Directory.Exists(sourceFolder))
            //{
            //    // 3. Create a real physical folder inside your project
            //    ProjectItem projectFolder = targetProject.ProjectItems.AddFolder("ImportedExtensionFolders");

            //    // 4. Extract the physical directory path on disk
            //    string destinationPath = projectFolder.Properties.Item("FullPath").Value.ToString();

            //    // 5. Copy all files across and link them
            //    foreach (string file in Directory.GetFiles(sourceFolder))
            //    {
            //        string fileName = Path.GetFileName(file);
            //        string destFilePath = Path.Combine(destinationPath, fileName);

            //        // Physical copy to drive
            //        File.Copy(file, destFilePath, overwrite: true);

            //        // Add file into the Project Item hierarchy
            //        projectFolder.ProjectItems.AddFromFile(destFilePath);
            //    }

            //    // 6. Force Visual Studio to redraw the UI so the files pop up right away
            //    dte2.ExecuteCommand("View.Refresh");
            //}
        }
    }
}
