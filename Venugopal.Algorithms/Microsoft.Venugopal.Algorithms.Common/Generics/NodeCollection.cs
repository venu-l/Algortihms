using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Venugopal.Algorithms.Common.Generics
{
    /// <summary>
    /// Collection container that holds the set of nodes.
    /// </summary>
    /// <typeparam name="T">
    /// If you want the right Contains operation for your Type, Derive from IEquatable<T>.
    /// More details: http://stackoverflow.com/questions/3637984/what-does-collection-contains-use-to-check-for-existing-objects 
    /// </typeparam>
    public class NodeCollection<T> : Collection<Node<T>>
    {
        public NodeCollection() : base() {}

        public bool ContainsNodeWithValue(T data)
        {
            bool contains = false;

            Parallel.ForEach(base.Items, itemAccessWork =>
            {
                // you dont need lock while you set the value since there is no problem of Write Inconsistency!
                if (itemAccessWork.Value.Equals(data))
                    contains = true;
                
            });

            return contains;
        }
    }
}
