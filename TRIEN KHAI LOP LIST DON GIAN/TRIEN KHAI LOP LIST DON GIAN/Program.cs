using System;

namespace TRIEN_KHAI_LOP_LIST_DON_GIAN
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> listInteger = new MyList<int>();
            listInteger.Add(10);
            listInteger.Add(15);
            listInteger.Add(20);
            listInteger.Add(30);
            listInteger.Add(50);
        }
    }
}
