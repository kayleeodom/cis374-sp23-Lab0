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


        public BinarySearchTreeNode<T> GetNode(int key)
        {
            return GetNodeRecursive(Root, key);
        }

        private BinarySearchTreeNode<T> GetNodeRecursive(BinarySearchTreeNode<T> node, int key)
        {
            return null;
        }


        // TODO
        public void Add(int key, T value)
        {
            // if root is equal to null set the root as the new node
            if (Root == null)
            {
                Root = new BinarySearchTreeNode<T>(key, value);
            }
            //else insert the recursive method using the root and the node
            else
            
            {
                Add(key, value);
            }

        }
        // TODO
        private void AddRecursive(int key, T value, BinarySearchTreeNode<T> node)
        {
            // check if the new node is less than the parent node
            if(node.Key <= Root.Key)
            {
                // if it is then check if the left node is null
                if(Root.Left == null)
                {
                    // if null then set that to the new node
                    Root.Left = node;
                }
                else
                {
                    // else add the new node to the left
                    AddRecursive(key, value, Root.Left);
                }
            }
            else
            {
                // if it is then check if the right node is null
                if (Root.Right == null)
                {
                    // if null then set that to the new node
                    Root.Right = node;
                }
                else
                {
                    // else add the new node to the right
                    AddRecursive(key, value, Root.Right);
                }
            }
        }

        // TODO
        public void Clear()
        {
            Root = null;
        }

        // TODO
        public bool Contains(int key)
        {
            throw new NotImplementedException();
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

        // TODO
        public T Search(int key)
        {
            throw new NotImplementedException();
        }

        // TODO
        public void Update(int key, T value)
        {
            throw new NotImplementedException();
        }


        // TODO
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
            
        }

        // TODO
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
            
        }

        // TODO
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
            
        }
    }
}

