namespace Microsoft.Venugopal.Algorithms.Common.Generics
{
    public class Node<T>
    {
        #region Private 

        T nodeValue;

        NodeCollection<T> nodeNeighbors;

        #endregion

        public Node() {}

        public Node(T data):this(data, new NodeCollection<T>()){}

        public Node(T data, NodeCollection<T> neighbors)
        {
            this.nodeValue = data;
            this.nodeNeighbors = neighbors;
        }

        #region Properties
        
        public T Value
        {
            get { return nodeValue; }
        }

        #endregion
    }
}
