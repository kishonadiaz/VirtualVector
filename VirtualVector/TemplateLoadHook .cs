using EnvDTE;
using Microsoft.Build.Framework;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVector
{
    public class TemplateLoadHook : IVsSolutionEvents
    {
        
        // This triggers exactly when the template begins loading
        public void RunStarted(object automationObject,
                               Dictionary<string, string> replacementsDictionary,
                               WizardRunKind runKind,
                               object[] customParams)
        {
            // Code here runs right when the template is requested/loaded
            System.Windows.Forms.MessageBox.Show("Template loading initiated!");

            // Example: Inject dynamic variables into your template files
            replacementsDictionary.Add("$currentyear$", DateTime.Now.Year.ToString());
        }

        // Keep other required interface methods blank if unneeded
        public void ProjectFinishedGenerating(Project project) { }
        public void ProjectItemFinishedGenerating(ProjectItem projectItem) { }
        public bool ShouldAddProjectItem(string filePath) => true;
        public void BeforeOpeningFile(ProjectItem projectItem) { }
        public void RunFinished() { }

        public int OnAfterOpenProject(IVsHierarchy pHierarchy, int fAdded)
        {
            System.Windows.Forms.MessageBox.Show("Template loading initiated!");
            return 0;
        }

        public int OnQueryCloseProject(IVsHierarchy pHierarchy, int fRemoving, ref int pfCancel)
        {
            System.Windows.Forms.MessageBox.Show("Template loading initiated!");
            return -1;
        }

        public int OnBeforeCloseProject(IVsHierarchy pHierarchy, int fRemoved)
        {
            System.Windows.Forms.MessageBox.Show("Template loading initiated!");
            return 0;
        }

        public int OnAfterLoadProject(IVsHierarchy pStubHierarchy, IVsHierarchy pRealHierarchy)
        {
            System.Windows.Forms.MessageBox.Show("Template loading initiated!");
            return 0;
        }

        public int OnQueryUnloadProject(IVsHierarchy pRealHierarchy, ref int pfCancel)
        {
            System.Windows.Forms.MessageBox.Show("Template loading initiated!");
            return 0;
        }

        public int OnBeforeUnloadProject(IVsHierarchy pRealHierarchy, IVsHierarchy pStubHierarchy)
        {
            System.Windows.Forms.MessageBox.Show("Template loading initiated!");
            return 0;
        }

        public int OnAfterOpenSolution(object pUnkReserved, int fNewSolution)
        {
            System.Windows.Forms.MessageBox.Show("Template loading initiated!");
            return (int)fNewSolution;
        }

        public int OnQueryCloseSolution(object pUnkReserved, ref int pfCancel)
        {
            System.Windows.Forms.MessageBox.Show("Template loading initiated!");
            return (int)pfCancel;
        }

        public int OnBeforeCloseSolution(object pUnkReserved)
        {
            System.Windows.Forms.MessageBox.Show("Template loading initiated!");
            return 0;
        }

        public int OnAfterCloseSolution(object pUnkReserved)
        {
            System.Windows.Forms.MessageBox.Show("Template loading initiated!");
            return 0;
        }
    }
}
