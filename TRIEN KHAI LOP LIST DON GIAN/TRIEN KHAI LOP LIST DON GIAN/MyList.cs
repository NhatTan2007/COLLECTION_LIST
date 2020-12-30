using System;
using System.Collections.Generic;
using System.Text;

namespace TRIEN_KHAI_LOP_LIST_DON_GIAN
{
    public class MyList<T>
    {
        private int _capacity = 0;
        private Object[] _items = new Object[1];

        public int Capacity { get => _capacity;}
        public object[] Items { get => _items; set => _items = value; }

        public MyList()
        {

        }

        public void Add(T data)
        {
            if(_items.Length == _capacity)
            {
                EnsureCapacity(_items.Length * 2);
            }
            _items[_capacity++] = data;
        }

        private void EnsureCapacity(int newCapacity)
        {
            Array.Resize(ref _items, newCapacity);
        }

        public T GetData(int index)
        {
            if (index < 0 || index >= _capacity)
            {
                throw new IndexOutOfRangeException($"Index: {index} is over Capacity {_capacity} ");
            }
            else return (T)_items[index];
        }
    }
}
