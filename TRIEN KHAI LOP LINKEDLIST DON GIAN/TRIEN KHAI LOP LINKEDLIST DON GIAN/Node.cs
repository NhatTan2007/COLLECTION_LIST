using System;
using System.Collections.Generic;
using System.Text;

namespace TRIEN_KHAI_LOP_LINKEDLIST_DON_GIAN
{
    class Node
    {
        private Object _data;
        private Node _next;

        public object Data { get => _data; set => _data = value; }
        public Node Next { get => _next; set => _next = value; }

        public Node(Object data)
        {
            _data = data;
            _next = null;
        }
    }
}
