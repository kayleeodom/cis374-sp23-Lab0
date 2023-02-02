using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace Lab0
{
    public class BinarySearchTree<T> : IBinarySearchTree<T>
    {

        private BinarySearchTreeNode<T> Root { get; set; }

        public BinarySearchTree()
        {
            Root = null;
            Count = 0;

        }
        public bool IsEmpty => Root == null;

        public int Count { get; private set; }

        // Done
        public int Height => HeightRecursive(Root);

        private int HeightRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return -1;
            }

            if (node.Left == null && node.Right == null)
            {
                return 0;
            }

            int leftHeight = HeightRecursive(node.Left);
            int rightHeight = HeightRecursive(node.Right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        // Done
        public int? MinKey => MinKeyRecursive(Root);

        private int? MinKeyRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Left == null)
            {
                return node.Key;
            }
            else
            {
                return MinKeyRecursive(node.Left);
            }
        }

        // Done
        public int? MaxKey => MaxKeyRecursive(Root);

        private int? MaxKeyRecursive(BinarySearchTreeNode<T> node)
        {
            // keep going to the right until you reach a null
            if (node == null)
            {
                return null;
            }
            else if (node.Right == null)
            {
                return node.Key;
            }
            else
            {
                return MaxKeyRecursive(node.Right);
            }
        }

        // Done
        Tuple<int, T> IBinarySearchTree<T>.Min
        {
            get
            {
                if (IsEmpty)
                {
                    return null;
                }

                var minNode = MinNode(Root);
                return Tuple.Create(minNode.Key, minNode.Value);
            }
        }

        // Done
        Tuple<int, T> IBinarySearchTree<T>.Max
        {
            get
            {
                if (IsEmpty)
                {
                    return null;
                }

                var maxNode = MaxNode(Root);
                return Tuple.Create(maxNode.Key, maxNode.Value);
            }
        }

        // TODO
        public double MedianKey
        {
            get
            {
                // get inorder keys
                var keys = InOrderKeys;


                // Odd case
                // if the nodes can be divided by 2 and not equal 0 and 
                if (keys.Count % 2 == 1)
                {
                    int middleIndex = keys.Count / 2;
                    return keys[middleIndex];
                }
                // Even case
                else
                {
                    int middleIndex1 = keys.Count / 2 - 1;
                    int middleIndex2 = keys.Count / 2;

                    int sum = keys[middleIndex1] + keys[middleIndex2];

                    return sum / 2.0;
                }
            }
        }

        // Done
        public BinarySearchTreeNode<T>? GetNode(int key)
        {
            return GetNodeRecursive(Root, key);
        }

        private BinarySearchTreeNode<T>? GetNodeRecursive(BinarySearchTreeNode<T> node, int key)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Key == key)
            {
                return node;
            }

            else if (key < node.Key)
            {
                return GetNodeRecursive(node.Left, key);
            }

            else
            {
                return GetNodeRecursive(node.Right, key);
            }
        }

        // Done
        public void Add(int key, T value)
        {
            // if root is equal to null set the root as the new node
            if (Root == null)
            {
                Root = new BinarySearchTreeNode<T>(key, value);
                Count++;
            }
            // else insert the recursive method using the root and the node
            else
            {
                AddRecursive(key, value, Root);
            }
        }

        // Done
        private void AddRecursive(int key, T? value, BinarySearchTreeNode<T> parent)
        {
            // duplicate found
            // do not add to BST
            if (key == parent.Key)
            {
                return;
            }

            // check if the new node is less than the parent node
            if (key < parent.Key)
            {
                // if it is then check if the left node is null
                if (parent.Left == null)
                {
                    // if null then set that to the new node
                    var newNode = new BinarySearchTreeNode<T>(key, value);
                    parent.Left = newNode;
                    newNode.Parent = parent;
                    Count++;

                }
                else
                {
                    // else add the new node to the left
                    AddRecursive(key, value, parent.Left);
                }
            }

            else
            {
                // if it is then check if the right node is null
                if (parent.Right == null)
                {
                    // if null then set that to the new node
                    var newNode = new BinarySearchTreeNode<T>(key, value);
                    parent.Right = newNode;
                    newNode.Parent = parent;
                    Count++;
                }
                else
                {
                    // else add the new node to the right
                    AddRecursive(key, value, parent.Right);
                }
            }
        }

        // Done
        public void Clear()
        {
            Root = null;
        }

        // Done
        public bool Contains(int key)
        {
            var node = GetNode(key);

            if (node == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // TODO
        public BinarySearchTreeNode<T> Next(BinarySearchTreeNode<T> node)
        {
            // Successor
            if (node.Right != null)
            {
                return MinNode(node.Right);
            }
            var p = node.Parent;
            while (p != null && node == p.Right)
            {
                node = p;
                p = p.Right;
            }
            return p;
        }

        public BinarySearchTreeNode<T> Prev(BinarySearchTreeNode<T> node)
        {
            // Predessor
            // 1 left and then the farthest to the right; until you hit a null
            // Find the min node in the left child's sub tree
            if (node.Left != null)
            {
                return MaxNode(node.Left);
            }
            var p = node.Parent;
            while (p != null && node == p.Left)
            {
                node = p;
                p = p.Left;
            }
            return p;
        }


        public List<BinarySearchTreeNode<T>> RangeSearch(int min, int max)
        {
            // other
            // make a list
            // List<BinarySearchTreeNode<T>> result = new List<BinarySearchTreeNode<T>>();

            // for loop from min to max
            //for (int i = min; i <= max; i++)
            //{
            //    if (Contains(i) == true)
            //    {
            //        result.Add(GetNode(i));
            //    }

            //    else
            //    {
            //        continue;
            //    }
            //}

            //return result;

            // Method 1 => Use Next()

            // Method 2 => Use InOrderKey
            List<BinarySearchTreeNode<T>> nodeList = new List<BinarySearchTreeNode<T>>();

            if(min > max)
            {
                return nodeList;
            }


            // will return a list of the keys in ordered
            var orderedKeys = this.InOrderKeys;

            foreach(int key in orderedKeys)
            {
                if(key >= min && key <= max)
                {
                    nodeList.Add(GetNode(key));
                }

                if(key > max)
                {
                    break;
                }
            }

            return nodeList;
        }

        public void Remove(int key)
        {
            var node = GetNode(key);
            var parent = node.Parent;

            if (node == null)
            {
                return;
            }

            Count--;

            // 1) leaf node
            if (node.Left == null && node.Right == null)
            {
                if (parent.Left == node)
                {
                    parent.Left = null;
                    node.Parent = null;
                }
                else if (parent.Right == node)
                {
                    parent.Right = null;
                    node.Parent = null;
                }

                return;
            }

            // 2) parent with 1 child
            if (node.Left == null && node.Right != null)
            {
                // only has a right child
                var child = node.Right;
                if (parent.Left == node)
                {
                    parent.Left = child;
                    child.Parent = parent;

                    node.Parent = null;
                    node.Left = null;
                }
                else if (parent.Right == node)
                {
                    parent.Right = child;
                    child.Parent = parent;

                    node.Parent = null;
                    node.Right = null;
                }

                return;
            }

            if (node.Left != null && node.Right == null)
            {
                // only has a left child
                var child = node.Left;
                if (parent.Left == node)
                {
                    parent.Left = child;
                    child.Parent = parent;

                    node.Parent = null;
                    node.Left = null;
                }
                else if (parent.Right == node)
                {
                    parent.Right = child;
                    child.Parent = parent;

                    node.Parent = null;
                    node.Right = null;
                }

                return;
            }

            //var node = GetNode(key);
            //var parent = node.Parent;

            // 3) parent with 2 children

            // Find the node to remove
            if(node.Left != null && node.Right != null)
            {
                // Find the next node (successor)

            }
            // Swap Key and Data from successor to node
            // Remove the successor (a leaf node) (like case 1)

            //implement the next method

        }

        // Done
        public T Search(int key)
        {
            if(Contains(key))
            {
                var node = GetNode(key);
                return node.Value;
            }
            else
            {
                return default(T);
            }
        }

        // TOOO
        public void Update(int key, T value)
        {
            throw new NotImplementedException();
        }

        // Done
        public List<int> InOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                InOrderKeysRecursive(Root, keys);

                return keys;
            }
        }

        private void InOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            // left
            // root
            // right

            if(node == null)
            {
                return;
            }

            InOrderKeysRecursive(node.Left, keys);
            keys.Add(node.Key);
            InOrderKeysRecursive(node.Right, keys);
        }

        // Done
        public List<int> PreOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                PreOrderKeysRecursive(Root, keys);

                return keys;
            }
        }

        private void PreOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            // root
            // left
            // right

            if (node == null)
            {
                return;
            }

            keys.Add(node.Key);
            PreOrderKeysRecursive(node.Left, keys);
            PreOrderKeysRecursive(node.Right, keys);

        }

        // Done
        public List<int> PostOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                PostOrderKeysRecursive(Root, keys);
                return keys;
            }
        }

        private void PostOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            // left
            // right
            // root

            if (node == null)
            {
                return;
            }

            PostOrderKeysRecursive(node.Left, keys);
            PostOrderKeysRecursive(node.Right, keys);
            keys.Add(node.Key);
        }

        // TODO
        public BinarySearchTreeNode<T> MinNode(BinarySearchTreeNode<T> node)
        {
            return MinNodeRecursive(node);
        }

        private BinarySearchTreeNode<T> MinNodeRecursive(BinarySearchTreeNode<T> node)
        {
            if (node.Left == null)
            {
                return node;
            }

            return MinNodeRecursive(node.Left);
        }

        // TODO
        public BinarySearchTreeNode<T> MaxNode(BinarySearchTreeNode<T> node)
        {
            return MaxNodeRecursive(node);
        }

        private BinarySearchTreeNode<T> MaxNodeRecursive(BinarySearchTreeNode<T> node)
        {
            if (node.Right == null)
            {
                return node;
            }

            return MaxNodeRecursive(node.Right);
        }

    }
}