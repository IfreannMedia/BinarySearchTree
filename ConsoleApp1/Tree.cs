using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Tree
    {
        // The tree contains
        //public List<Node> nodes = new List<Node>();
        public Node rootNode = null;

        /// <summary>
        /// Inserts a random amount of numbers into a tree between 1 and 100
        /// </summary>
        public void PopulateRandom()
        {
            Random numberGen = new Random();
            int iterations = numberGen.Next(4, 35);

            for (int i = 0; i < iterations; i++)
            {
                Insert(numberGen.Next(1,100));
            }
        }

        // Find a value in the tree
        // return null if there is no root
        // otherwise call Find(value) on the root node
        public Node Find(int value)
        {
            if (rootNode == null)
            {
                return null;
            }
            else
            {
                return rootNode.Find(value);
            }
        }

        public Node FindRecursive(int value)
        {
            if (rootNode == null)
            {
                return null;
            }
            else
            {
                return rootNode.FindRecursive(value);

            }
        }

        // Insert a value into the tree
        public void Insert(int value)
        {
            if (rootNode == null)
            {
                rootNode = new Node(value);
            }
            else
            {
                rootNode.Insert(value);
            }
        }

       
        // Remove a value from the tree, ie a specific node
        public void Remove(int value)
        {
            // Begin with the root node as current and parent node
            Node current = rootNode;
            Node parent = rootNode;
            bool isLeftChild = false;

            if (current == null)
            {
                return;
            }

            // We exit the while loop when we have a node which equels the value we wish to delete,
            // then delete that node:
            while (current != null && current.value != value)
            {
                parent = current;

                if (value < current.value)
                {
                    // move to left child:
                    current = current.leftNode;
                    isLeftChild = true;
                }
                else
                {
                    current = current.rightNode;
                    isLeftChild = false;
                }
            }

            if (current == null)
            {
                return;
            }

            if (current.leftNode == null && current.rightNode == null)
            {
                if (current == rootNode)
                {
                    rootNode = null;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.leftNode = null;
                    }
                    else
                    {
                        parent.rightNode = null;
                    }

                }
            }
            else if (current.rightNode == null)
            {
                if (current == rootNode)
                    rootNode = current.leftNode;
                else
                {
                    if (isLeftChild)
                    {
                        parent.leftNode = current.leftNode;
                    }
                    else
                    {
                        parent.rightNode = current.rightNode;
                    }
                }
            }
            // otherwise this node has both left and right children
            else
            {
                Node successor = GetSuccessor(current);

                if (current == rootNode)
                {
                    rootNode = successor;
                }
                else if (isLeftChild)
                {
                    parent.leftNode = successor;
                }
                else
                {
                    parent.rightNode = successor;
                }
            }

        }

        private Node GetSuccessor(Node node)
        {
            Node parentOfSuccessor = node;
            Node successor = node;
            Node current = node.rightNode;

            // While we have a right node:
            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.leftNode;
            }

            if (successor != node.rightNode)
            {
                parentOfSuccessor.leftNode = successor.rightNode;

                successor.rightNode = node.rightNode;
            }

            successor.leftNode = node.leftNode;

            return successor;
        }

        public Nullable<int> Smallest()
        {
            if (rootNode != null)
            {
                return rootNode.SmallestValue();
            }
            else
            {
                return null;
            }
        }

        public Nullable<int> Largest()
        {
            if (rootNode != null)
            {
                return rootNode.LargestValue();
            }
            else
                return null;
        }

        public void InOrderTraversal()
        {
            if (rootNode != null)
            {
                rootNode.InOrderTraversal();
            }
        }

        public void PreOrderTraversal()
        {
            if (rootNode != null)
            {
                rootNode.PreOrderTraversal();
            }
        }

        public void PostOrderTraversal()
        {
            if (rootNode != null)
            {
                rootNode.PostOrderTraversal();
            }
        }

        public int NumberOfLeafNodes()
        {
            if (rootNode == null)
            {
                return 0;
            }
            else
            {
                return rootNode.NumberOfLeafNodes();
            }
        }

        public int Height()
        {
            if (rootNode == null)
            {
                return 0;
            }
            return rootNode.Height();
        }

        public bool isBalanced()
        {
            if (rootNode == null)
            {
                return true;
            }
            return rootNode.IsBalanced();
        }
    }
}
