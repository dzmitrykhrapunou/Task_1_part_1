using System;
using System.Collections.Generic;

namespace Task5Part1DzmitryKhrapunou.Entity
{
    /// <summary>
    /// Node of binary tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTreeNode<T> where T : IComparable
    {
        /// <summary>
        /// Node data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Left node
        /// </summary>
        public BinaryTreeNode<T> LeftNode { get; set; }

        /// <summary>
        /// Right node
        /// </summary>
        public BinaryTreeNode<T> RightNode { get; set; }

        /// <summary>
        /// Parent
        /// </summary>
        public BinaryTreeNode<T> ParentNode { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BinaryTreeNode() { }

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="data"></param>
        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Add a new element to node
        /// </summary>
        /// <param name="data"> Node data</param>
        public bool Add(T data)
        {
            var node = new BinaryTreeNode<T>(data);

            if (node.Data.CompareTo(Data) < 0)
            {
                if (LeftNode == null)
                {
                    LeftNode = node;
                }
                else
                {
                    return LeftNode.Add(data);
                }
            }
            else 
            {
                if (node.Data.CompareTo(Data) > 0)
                {
                    if (RightNode == null)
                    {
                        RightNode = node;
                    }
                    else
                    {
                        return RightNode.Add(data);
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Find element with minimum data
        /// </summary>
        /// <returns>Node with minimum data</returns>
        private BinaryTreeNode<T> Minimum()
        {
            if (LeftNode == null)
            {
                return this;
            }
            else
            {
                return LeftNode.Minimum();
            }
        }

        /// <summary>
        /// Delete data from tree
        /// </summary>
        /// <param name="data">Data to delete</param>
        /// <returns>Deleted node</returns>
        public BinaryTreeNode<T> Delete(T data)
        {
            if (data.CompareTo(Data) < 0)
            {
                LeftNode = LeftNode.Delete(data);
            }
            else 
            {
                if (data.CompareTo(Data) > 0)
                {
                    RightNode = RightNode.Delete(data);
                }
                else
                {
                    if (LeftNode != null && RightNode != null)
                    {
                        Data = RightNode.Minimum().Data;
                        RightNode = RightNode.Delete(RightNode.Data);
                    }
                    else
                    {
                        if (LeftNode != null)
                        {
                            return LeftNode;
                        }
                        else
                        {
                            if (RightNode != null)
                            {
                                return RightNode;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }

            return this;
        }

        /// <summary>
        /// Maximum height of current node
        /// </summary>
        /// <returns>Maximum height</returns>
        public int TreeHeight()
        {
            int rightCount = 0;
            int leftCount = 0;

            if (LeftNode == null && RightNode == null)
                return 1;

            if (LeftNode != null)
                leftCount += 1 + LeftNode.TreeHeight();

            if (RightNode != null)
                rightCount += 1 + RightNode.TreeHeight();
         
            if (leftCount <= rightCount)
                return rightCount;
            else
                return leftCount;
        }
                
        /// <summary>
        /// Part of recursion of Inorder output.
        /// </summary>
        /// <param name="node"></param>
        /// <returns>Sorted List of elements Binary Tree</returns>
        public List<T> InOrder(BinaryTreeNode<T> node)
        {
            var output = new List<T>();

            if (node != null)
            {
                if (node.LeftNode != null)
                {
                    output.AddRange(InOrder(node.LeftNode));
                }
                output.Add(node.Data);
                if (node.LeftNode != null)
                {
                    output.AddRange(InOrder(node.RightNode));
                }
            }
            return output;
        }
                
        /// <summary>
        /// Compare two objects.
        /// </summary>
        /// <param name="obj">Other object</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj is BinaryTreeNode<T> item)
            {
                return Data.CompareTo(item.Data);
            }
            else
            {
                throw new Exception("Specified type was invalid");
            }
        }

        /// <summary>
        /// Converting an instance of a class to a string
        /// </summary>
        /// <returns>The data for the node tree</returns>
        public override string ToString() => Data.ToString();       
    }
}
