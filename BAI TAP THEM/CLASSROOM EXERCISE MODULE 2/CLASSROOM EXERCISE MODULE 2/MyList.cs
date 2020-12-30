using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace CLASSROOM_EXERCISE_MODULE_2
{
    public class MyList<T>
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

        public int Add(T data)
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

        public int IndexOf(T itemToSearch)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_item[i].Equals(itemToSearch))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(T item)
        {
            if (IndexOf(item) != -1)
            {
                for (int i = IndexOf(item); i < _count - 1; i++)
                {
                    _item[i] = _item[i + 1];
                }
                _item[_count - 1] = default(T);
                _count--;
                return true;
            }
            else return false;
        }

    }
}
