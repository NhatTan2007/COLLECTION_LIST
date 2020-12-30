using System;
using System.Collections;
using System.Collections.Generic;

namespace TRIEN_KHAI_LOP_LINKEDLIST_DON_GIAN
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList newLinkList = new MyLinkedList(10);
            newLinkList.Add(9, 4);
            newLinkList.AddLast(13);
            newLinkList.Add(15, 5);
            newLinkList.AddFirst(23);
            newLinkList.PrintList();
        }
    }
}
