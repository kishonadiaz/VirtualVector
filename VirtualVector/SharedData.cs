using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVector
{
    public interface IUpdatable
    {
        event EventHandler<DataUpdatedEventArgs> OnDataUpdated;
        void UpdateData(object newData);
    }

    public class DataUpdatedEventArgs : EventArgs
    {
        public object NewText { get; set; }

        public DataUpdatedEventArgs(object text)
        {
            NewText = text;
        }
    }
    public class DataViewer : IUpdatable
    {
        public event EventHandler<DataUpdatedEventArgs> OnDataUpdated;

        event EventHandler<DataUpdatedEventArgs> IUpdatable.OnDataUpdated
        {
            add
            {
                Debug.WriteLine($"New data received: jdj");
            }

            remove
            {
                Debug.WriteLine($"New data received: df");
            }
        }

        public void Subscribe(IUpdatable source)
        {
            // Subscribe to the source's update event
            source.OnDataUpdated += HandleDataUpdate;
        }

        private void HandleDataUpdate(object sender, DataUpdatedEventArgs e)
        {
            // Update your UI or processing logic with e.NewText
            Debug.WriteLine($"New data received: {e.NewText}");
        }

        public void UpdateData(string newData)
        {
            // Implement interface requirements
        }

        void IUpdatable.UpdateData(object newData)
        {
            Debug.WriteLine($"New data received: ${newData}");
        }
    }

    public  class Residual 
    {

        private static readonly Residual instance = new Residual();

        private Residual() { }

        public static Residual Instance => instance;
        public ArrayList scene_transfer = new ArrayList();

    }

    [ClassInterface(ClassInterfaceType.AutoDual)]

    [System.Runtime.InteropServices.ComVisible(true)]
    public class SharedData :IUpdatable
    {
        //public static ArrayList scene_transfer = new ArrayList();

        public SharedData()
        {
            //Residual.Instance.scene_transfer = new ArrayList();
        }

        public event EventHandler<DataUpdatedEventArgs> OnDataUpdated;

        public void Add(object data)
        {
            Residual.Instance.scene_transfer.Add(data);
        }

        public object[] GetAll()
        {
            return Residual.Instance.scene_transfer.ToArray();
        }

        public object Update(int index,object data)
        {
            return Residual.Instance.scene_transfer[index-1] = data;


        }

        public void UpdateData(object newData)
        {
            OnDataUpdated?.Invoke(this, new DataUpdatedEventArgs(newData));
        }
    }

   
}
