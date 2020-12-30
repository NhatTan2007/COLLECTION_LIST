using System;
using System.Collections.Generic;
using System.Text;

namespace TRIEN_KHAI_LOP_LINKEDLIST_DON_GIAN
{
    class MyLinkedList
    {
        private Node _head;
        private int _nodeCnt;
        private Node _tail;

        public int NodeCnt { get => _nodeCnt; set => _nodeCnt = value; }
        internal Node Head { get => _head; set => _head = value; }
        internal Node Tail { get => _tail; set => _tail = value; }

        public MyLinkedList(Object data)
        {
            _head = new Node(data);
        }

        public void Add(Object data, int index)
        {
            Node temp = _head;
            Node holder;
            for (int i = 0; i < index - 1 && temp.Next != null; i++)
            {
                temp = temp.Next;
            }

            holder = temp.Next;
            temp.Next = new Node(data);
            temp.Next.Next = holder;
            if (holder == null)
            {
                _tail = temp.Next;
            }
            _nodeCnt++;
        }

        public void AddFirst(Object data)
        {
            Node temp = _head;
            _head = new Node(data);
            _head.Next = temp;
            _nodeCnt++;
        }

        public void AddLast(Object data)
        {
            if (_tail == null)
            {
                Node temp = _head;
                for (int i = 0; temp.Next != null; i++)
                {
                    temp = temp.Next;
                }
                _tail = temp;
            }
            
            _tail.Next = new Node(data);
            _tail = _tail.Next;
            _nodeCnt++;
        }

        public Node GetData(int index)
        {
            if (index < _nodeCnt)
            {
                Node temp = _head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.Next;
                }
                return temp;
            }
            else return null;
        }

        public void PrintList()
        {
            Node temp = _head;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }
    }
}
