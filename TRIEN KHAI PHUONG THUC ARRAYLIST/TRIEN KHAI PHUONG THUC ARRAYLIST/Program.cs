using System;
using System.Collections.Generic;
using System.Collections;

namespace TRIEN_KHAI_PHUONG_THUC_ARRAYLIST
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> newList = new MyList<int>();
            Console.WriteLine(newList.Capacity);
            newList.AddRange(new int[] { 5, 2, 4, 9, 2, 4, 9, 5, 8 });
            newList.Reverse();
            Console.WriteLine(newList.Capacity);
            newList.Sort();
            newList.TrimToSize();
            Console.WriteLine($"Count {newList.Count}");
            newList.Add(5);
            Console.WriteLine(newList.Capacity);
            Console.WriteLine($"Count {newList.Count}");
            newList.AddRange(new int[]{5,5,5,5,5,5,5,5});
            Console.WriteLine(newList.Capacity);
            int[] clear = new int[25];
            newList.CopyTo(clear, 3);
        }
    }
}
