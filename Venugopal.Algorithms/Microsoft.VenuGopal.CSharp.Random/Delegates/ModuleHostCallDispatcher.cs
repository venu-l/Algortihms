using Microsoft.VenuGopal.CSharp.Random.Delegates;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Microsoft.VenuGopal.CSharp.Random
{
    public class ModuleHostCallDispatcher
    {
        private object resourceLock = new object();
        private IModuleHost _moduleHost;
        private ObservableCollection<DataItemCall> postOperations;

        public ModuleHostCallDispatcher(IModuleHost moduleHost)
        {
            this._moduleHost = moduleHost;

            postOperations = new ObservableCollection<DataItemCall>();
            postOperations.CollectionChanged += HandleChange;
        }

        public void AddNewDataItem(DataItemCall item)
        {
            postOperations.Add(item);
        }

        private void HandleDataItemAcknowledgement(object state)
        {
            // Figure out what to do!
            System.Console.WriteLine("Got the Call back from the ModuleHost API");
        }

        private void HandleChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (var x in e.NewItems)
            {
                // do something
                System.Console.WriteLine("Invoking the Call to the Module Host API");

                DataItemCall call = x as DataItemCall;

                this._moduleHost.PostOutputDataItems(call.Item, HandleDataItemAcknowledgement, new object()); 

            }

            foreach (var y in e.OldItems)
            {
                //do something
            }

            if (e.Action == NotifyCollectionChangedAction.Move)
            {
                //do something
            }
        }
    }
}
