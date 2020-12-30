using NUnit.Framework;
using TRIEN_KHAI_LOP_LIST_DON_GIAN;

namespace MyListTest
{
    public class Tests
    {
        MyList<int> listInteger = new MyList<int>();
        [SetUp]
        public void Setup()
        {
            listInteger.Add(10);
            listInteger.Add(15);
            listInteger.Add(20);
            listInteger.Add(30);
            listInteger.Add(50);
        }

        [Test]
        public void GetDataTest_01()
        {
            Assert.AreEqual(15, listInteger.GetData(1));
        }
        [Test]
        public void GetDataTest_02()
        {
            Assert.AreEqual(50, listInteger.GetData(4));
        }
        [Test]
        public void GetDataTest_03()
        {
            Assert.AreEqual(20, listInteger.GetData(2));
        }
        [Test]
        public void GetDataTest_04()
        {
            Assert.AreEqual(20, listInteger.GetData(-1));
        }
    }
}