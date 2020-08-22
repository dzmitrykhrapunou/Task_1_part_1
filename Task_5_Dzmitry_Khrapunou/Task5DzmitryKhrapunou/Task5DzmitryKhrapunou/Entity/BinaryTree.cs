using System;

namespace Task5Part1DzmitryKhrapunou.Entity
{
    /// <summary>
    /// Binary tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> where T : IComparable
    {
        /// <summary>
        /// Root of binary tree
        /// </summary>
        public BinaryTreeNode<T> RootNode { get; set; }

        /// <summary>
        /// Number of binary tree node
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BinaryTree() { }

        /// <summary>
        /// Add a new node
        /// </summary>
        /// <param name="data"> Node data</param>
        public void Add(T data)
        {
            var node = new BinaryTreeNode<T>(data);

            if (RootNode == null)
            {
                RootNode = node;
                Count = 1;
                return;
            }

            RootNode.Add(data);
            BalanceTree();
        }

        /// <summary>
        /// Delete data from tree
        /// </summary>
        /// <param name="data">Data to delete</param>
        /// <returns></returns>
        public bool Remove(T data)
        {
            if (RootNode != null && RootNode.Delete(data) != null)
            {
                Count--;
                BalanceTree();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Balance binary tree
        /// </summary>
        public void BalanceTree()
        {
            int leftTreeHeight = 0;
            int rightTreeHeight = 0;
            
            if (RootNode.LeftNode == null && RootNode.RightNode == null)
                return;

            if (RootNode.LeftNode != null)
                leftTreeHeight = RootNode.LeftNode.TreeHeight();

            if (RootNode.RightNode != null)
                rightTreeHeight = RootNode.RightNode.TreeHeight();

            if (Math.Abs(rightTreeHeight - leftTreeHeight) <= 1)
                return;

            if (rightTreeHeight > leftTreeHeight)
            {
                BinaryTreeNode<T> newRoot = RootNode.RightNode;
                BinaryTreeNode<T> oldRoot = RootNode;
                oldRoot.RightNode = newRoot.LeftNode;
                newRoot.LeftNode = oldRoot;
                RootNode = newRoot;
            }
            else
            {
                BinaryTreeNode<T> newRoot = RootNode.LeftNode;
                BinaryTreeNode<T> oldRoot = RootNode;
                oldRoot.LeftNode = newRoot.RightNode;
                newRoot.RightNode = oldRoot;
                RootNode = newRoot;
            }
        }

        /// <summary>
        /// Search an element by data
        /// </summary>
        /// <param name="data"> Node data</param>
        /// <returns></returns>
        public BinaryTreeNode<T> Search(T data)
        {
            return Search(data, out BinaryTreeNode<T> parent);
        }

        /// <summary>
        /// Search an element by data
        /// </summary>
        /// <param name="data"> Node data</param>
        /// <param name="parent"> Parent node</param>
        /// <returns></returns>
        private BinaryTreeNode<T> Search(T data, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> current = RootNode;
            parent = null;

            while (current != null)
            {
                int result = data.CompareTo(current.Data);
                if (result == 1)
                {
                    parent = current;
                    current = current.RightNode;
                }
                else if (result == -1)
                {
                    parent = current;
                    current = current.LeftNode;
                }
                else
                    break;
            }

            return current;
        }
    }    
}
