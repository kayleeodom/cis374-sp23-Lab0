using System;

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

        // TODO
        public int Height => throw new NotImplementedException();

        // TODO
        public int MinKey => throw new NotImplementedException();

        // TODO
        public int MaxKey => throw new NotImplementedException();

        // TODO
        public Tuple<int, T> Min => throw new NotImplementedException();

        // TODO
        public Tuple<int, T> Max => throw new NotImplementedException();

        // TODO
        public double MedianKey => throw new NotImplementedException();

        // Done
        public BinarySearchTreeNode<T>? GetNode(int key)
        {
            return GetNodeRecursive(Root, key);
        }

        // Done
        private BinarySearchTreeNode<T>? GetNodeRecursive(BinarySearchTreeNode<T> node, int key)
        {
            if(node == null)
            {
                return null;
            }

            if(node.Key == key)
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
            //else insert the recursive method using the root and the node
            else
            {
                AddRecursive(key, value, Root);
            }

        }
        // Done
        private void AddRecursive(int key, T value, BinarySearchTreeNode<T> parent)
        {
            // duplicate found
            // do not add to BST
            if (key == parent.Key)
            {
                return;
            }

            // check if the new node is less than the parent node
            if(key < parent.Key)
            {
                // if it is then check if the left node is null
                if(parent.Left == null)
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

        // TODO
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
            throw new NotImplementedException();
        }

        // TODO
        public BinarySearchTreeNode<T> Prev(BinarySearchTreeNode<T> node)
        {
            throw new NotImplementedException();
        }

        // TODO
        public List<BinarySearchTreeNode<T>> RangeSearch(int min, int max)
        {
            throw new NotImplementedException();
        }

        public void Remove(int key)
        {
            throw new NotImplementedException();
        }

        // Done
        public T Search(int key)
        {
            if (Contains(key))
            {
                var node = GetNode(key);
                return node.Value;
            }
            else
            {
                return default(T);
            }
        }

        // TODO
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

            if(node == null)
            {
                return;
            }

            keys.Add(node.Key);
            InOrderKeysRecursive(node.Left, keys);
            InOrderKeysRecursive(node.Right, keys);

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

            if(node == null)
            {
                return;
            }

            InOrderKeysRecursive(node.Left, keys);
            InOrderKeysRecursive(node.Right, keys);
            keys.Add(node.Key);
        }
    }
}

