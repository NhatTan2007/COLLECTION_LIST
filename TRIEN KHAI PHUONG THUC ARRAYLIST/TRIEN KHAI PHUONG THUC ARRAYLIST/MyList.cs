using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TRIEN_KHAI_PHUONG_THUC_ARRAYLIST
{
    class MyList<T>
    {
        private T[] _item;
        private int _capacity = 0;
        private bool _isFixedSize;
        private bool _isReadOnly;
        private int _count = 0;

        public int Capacity { get => _capacity; set => _capacity = value; }
        public int Count { get => _count; }

        public MyList()
        {
            _item = new T[0];
        }
        public MyList(int capacity)
        {
            _capacity = capacity;
            _item = new T[_capacity];
        }
        public MyList(ICollection collectionInput)
        {

        }
        /// <summary>
        /// indexer
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get 
            {
                if (index >= 0 && index < _count) return _item[index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < _count) _item[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }

        private void ResizeArray()
        {
            if ((_capacity != 0 && _count >= _capacity) || _capacity == 0)
            {
                if (_capacity == 0)
                {
                    _capacity = 4;
                }
                else _capacity *= 2;
                Array.Resize(ref _item, _capacity);
            }
        }

        public int Add(T data)
        {
            ResizeArray();
            _item[_count++] = data;
            return _count - 1;
        }
        public void AddRange(T[] item)
        {
            for (int i = 0; i < item.Length; i++)
            {
                Add(item[i]);
            }
        }
        public void Clear()
        {
            _item = new T[0];
        }

        public T[] Clone()
        {
            T[] newItem = new T[_count];
            Array.Copy(_item, newItem, _count);
            return newItem;
        }

        public bool Contains(T itemToSearch)
        {
            foreach (T item in _item)
            {
                if (item.Equals(itemToSearch)) return true;
            }
            return false;
        }

        public void CopyTo(T[] array)
        {
            Array.Copy(_item, array, _count);
        }

        public void CopyTo(T[] array, int startTargetIndex)
        {
            Array.Copy(_item, 0, array, startTargetIndex, _count);
        }

        public void CopyTo(int startSourceIndex, T[] targetArray, int startTargetIndex, int lengthToCopy)
        {
            Array.Copy(_item, startSourceIndex, targetArray, startTargetIndex, lengthToCopy);
        }

        public override bool Equals(object inputObject)
        {
            return this.Equals(inputObject);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int IndexOf(T inputData)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_item[i].Equals(inputData))
                {
                    return i;
                }
            }
            return -1;
        }

        public int IndexOf(T inputData, int startIndex)
        {
            if (startIndex < 0 || startIndex >= _count)
            {
                throw new ArgumentOutOfRangeException();
            } else
            {
                for (int i = startIndex; i < _count; i++)
                {
                    if (_item[i].Equals(inputData))
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        public void Insert(int indexToAdd, T inputData)
        {
            if (indexToAdd < 0 || indexToAdd > _count)
            {
                throw new ArgumentOutOfRangeException();
            } else
            {
                ResizeArray();
                for (int i = _count - 1; i >= indexToAdd; i--)
                {
                    _item[i + 1] = _item[i];
                }
                _item[indexToAdd] = inputData;
                _count++;
            }
        }

        public void InsertRange(int indexToAdd, MyList<T> inputData)
        {
            if (indexToAdd < 0 || indexToAdd > _count)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                for (int i = inputData.Count - 1; i >= 0; i--)
                {
                    Insert(indexToAdd, inputData[i]);
                }
            }
        }

        public void RemoveAt(int indexToRemove)
        {
            if (indexToRemove < 0 || indexToRemove >= _count)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                for (int i = indexToRemove; i < _count - 1; i++)
                {
                    _item[i] = _item[i + 1];
                }
                _item[_count - 1] = default(T);
                _count--;
            }
        }

        public void Remove(T dataToRemove)
        {
            if (IndexOf(dataToRemove) != -1)
            {
                for (int i = IndexOf(dataToRemove); i < _count - 1; i++)
                {
                    _item[i] = _item[i + 1];
                }
                _item[_count - 1] = default(T);
                _count--;
            } else
            {
                throw new ArgumentException($"Cannot find {dataToRemove} to remove");
            }
        }

        public void RemoveRange(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex >= _count)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(startIndex + count - 1 >= _count)
            {
                throw new ArgumentException();
            } 
            else
            {
                for (int i = count; i > 0; i--)
                {
                    Remove(_item[startIndex]);
                }
            }
        }

        public void Reverse()
        {
            for (int i = 0, j = _count - 1; i < _count / 2; i++, j--)
            {
                T temp = _item[i];
                _item[i] = _item[j];
                _item[j] = temp;
            }
        }

        public void Sort()
        {
            Array.Sort(_item, 0, _count);
        }

        public void TrimToSize()
        {
            _capacity = _count;
            Array.Resize(ref _item, _capacity);
        }
    }
}
