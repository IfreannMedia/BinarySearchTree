using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Node
    {
        public int value = 0;
        public Node leftNode = null;
        public Node rightNode = null;
        public bool isDeleted = false; // for whether this node is deleted or not

        // Constructor for the node: assigns data
        public Node(int data)
        {
            value = data;
        }


        // Method to find a value in the tree
        public Node Find(int value)
        {
            Node currentNode = this; // mark this as the currently selected Node
            
            // Check each child node for the value:
            while (currentNode != null)
            {
                if (currentNode.value == value && !isDeleted)
                {
                    return currentNode; // we have found the value
                }
                else if (value > currentNode.value)
                {
                    // move to the right child and continue:
                    currentNode = currentNode.rightNode;
                }
                else 
                {
                    // The value is smaller so move to the left node
                    currentNode = currentNode.leftNode;
                }
            }
            // No nodes contained the value so return null
            return null;
        }

        // recursively finds a node
        public Node FindRecursive(int value)
        {
            if (value == this.value && !isDeleted)
            {
                return this;
            }
            else if (value < this.value && leftNode != null)
            {
                return leftNode.FindRecursive(value); // the value is smaller than this nodes value, 
                                               // so call the method on the left child node
            }
            else if (value > this.value && rightNode != null)
            {
                return rightNode.FindRecursive(value);
            }
            else
                return null; // we have recursively searched to the leaf node and did not find the value
        }

        // Inserts a value into the binary tree using recursion
        public void Insert(int value)
        {
            // We want the right child node:
            if (value >= this.value)
            {
                if (rightNode == null)
                {
                    // there is no right node, so make one:
                    rightNode = new Node(value);
                }
                else
                {
                    // There is a right node, so call it's Insert method
                    rightNode.Insert(value);
                }
            }
            else if (value < this.value)
            {
                if (leftNode == null)
                {
                    leftNode = new Node(value);
                }
                else
                {
                    leftNode.Insert(value);
                }
            }
        }

        // Gets the smalles value of the tree
        // which will always be the leftmost node:
        public Nullable<int> SmallestValue()
        {
            if (leftNode == null)
            {
                return this.value;
            }
            else
            {
                return leftNode.SmallestValue();
            }
        }

        public Nullable<int> LargestValue()
        {
            if (rightNode == null)
            {
                return this.value;
            }
            else
            {
                return rightNode.LargestValue();
            }
        }

        // prints numbers in ascending order
        public void InOrderTraversal()
        {
            if (leftNode != null)
            {
                // we have a leftNode, so call it's InOrderTraversal
                leftNode.InOrderTraversal();
            }
            // InOrderTraversal prints the smallest value
            Console.Write(value + " ");

            if (rightNode != null)
            {
                rightNode.InOrderTraversal();
            }
        }

        public void PreOrderTraversal()
        {
            Console.Write(value + " ");

            if (leftNode != null)
            {
                leftNode.PreOrderTraversal();
            }

            if (rightNode != null)
            {
                rightNode.PreOrderTraversal();
            }
        }

        // 
        public void PostOrderTraversal()
        {
            if (leftNode != null)
            {
                leftNode.PostOrderTraversal();
            }

            if (rightNode != null)
            {
                rightNode.PostOrderTraversal();
            }

            Console.Write(value + " ");
            
        }

        public int Height()
        {
            if (this.leftNode == null && this.rightNode == null)
            {
                return 1;
            }

            int left = 0;
            int right = 0;

            if (this.leftNode != null)
                left = this.leftNode.Height();
            if (this.rightNode != null)
                right = this.rightNode.Height();

            if (left > right)
            {
                return (left + 1);
            }
            else
            {
                return (right + 1);
            }
        }

        public int NumberOfLeafNodes()
        {
            //return 1 when leaf node is found
            if (this.leftNode == null && this.rightNode == null)
            {
                return 1; //found a leaf node
            }

            int leftLeaves = 0;
            int rightLeaves = 0;

            //recursively call NumOfLeafNodes returning 1 for each leaf found
            if (this.leftNode != null)
            {
                leftLeaves = leftNode.NumberOfLeafNodes();
            }
            if (this.rightNode != null)
            {
                rightLeaves = rightNode.NumberOfLeafNodes();
            }

            //add values together 
            return leftLeaves + rightLeaves;
        }

        public bool IsBalanced()
        {
            int LeftHeight = leftNode != null ? leftNode.Height() : 0;
            int RightHeight = rightNode != null ? rightNode.Height() : 0;

            int heightDifference = LeftHeight - RightHeight;

            if (Math.Abs(heightDifference) > 1)
            {
                return false;
            }
            else
            {
                return ((leftNode != null ? leftNode.IsBalanced() : true) && (rightNode != null ? rightNode.IsBalanced() : true));
            }
        }
    }
}
