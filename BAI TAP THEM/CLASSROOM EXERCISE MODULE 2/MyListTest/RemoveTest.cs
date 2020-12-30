using NUnit.Framework;
using CLASSROOM_EXERCISE_MODULE_2;

namespace MyListTest
{
    public class Tests
    {
        MyList<int> newList = new MyList<int>();
        
        [SetUp]
        public void Setup()
        {
            newList.AddRange(new int[] { 4, 3, 5, 2 });
        }

        [Test]
        public void RemoveTest_01()
        {
            Assert.IsTrue(newList.Remove(3));
        }
        [Test]
        public void RemoveTest_02()
        {
            Assert.IsTrue(newList.Remove(2));
        }
        [Test]
        public void RemoveTest_03()
        {
            Assert.IsTrue(!newList.Remove(6));
        }
    }
}