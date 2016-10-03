using System;
using System.Runtime.Remoting.Messaging;
using Microsoft.Venugopal.Algorithms.Common;

namespace Microsoft.VenuGopal.Algorithms.Trees
{
    public class TreeTraversals : IAlgoDriver
    {
        private TreeNode<int> rootNode;

        public TreeTraversals()
        {
            rootNode = new TreeNode<int>();
        }

        public void Execute()
        {
            rootNode.Data = 50;
            rootNode.LeftTreeNode = new TreeNode<int>() {Data = 40};
            rootNode.RightTreeNode = new TreeNode<int>() {Data = 30};

            rootNode.LeftTreeNode.LeftTreeNode = new TreeNode<int>() { Data = 70 };
            rootNode.LeftTreeNode.RightTreeNode = new TreeNode<int>() { Data = 80 };
            rootNode.LeftTreeNode.RightTreeNode.RightTreeNode = new TreeNode<int>() { Data = 90 };

            rootNode.RightTreeNode.LeftTreeNode = new TreeNode<int>() { Data = 60 };
            rootNode.RightTreeNode.RightTreeNode = new TreeNode<int>() { Data = 20 };

            Console.WriteLine("Inorder");
            this.InOrderTraversal(rootNode);

            Console.WriteLine("Preorder");
            this.PreOrderTraversal(rootNode);

            Console.WriteLine("Postorder");
            this.PostOrderTraversal(rootNode);
        }

        /// <summary>
        /// Left - Data - Right
        /// </summary>
        /// <param name="currentNode"></param>
        private void InOrderTraversal(TreeNode<int> currentNode)
        {
            if (currentNode.LeftTreeNode != null)
                this.InOrderTraversal(currentNode.LeftTreeNode);

            this.VisitNode(currentNode);

            if (currentNode.RightTreeNode != null)
                this.InOrderTraversal(currentNode.RightTreeNode);
        }

        private void PreOrderTraversal(TreeNode<int> currentNode)
        {
            this.VisitNode(currentNode);

            if (currentNode.LeftTreeNode != null)
                this.PreOrderTraversal(currentNode.LeftTreeNode);

            if (currentNode.RightTreeNode != null)
                this.PreOrderTraversal(currentNode.RightTreeNode);
        }

        private void PostOrderTraversal(TreeNode<int> currentNode)
        {
            if (currentNode.LeftTreeNode != null)
                this.PostOrderTraversal(currentNode.LeftTreeNode);

            if (currentNode.RightTreeNode != null)
                this.PostOrderTraversal(currentNode.RightTreeNode);

            this.VisitNode(currentNode);
        }

        private void VisitNode(TreeNode<int> node)
        {
            Console.Write(String.Format("-{0}-",node.Data));
        }

    }
}
