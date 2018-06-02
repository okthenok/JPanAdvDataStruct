using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JPanAdvDataStructure;
using System.Diagnostics;

namespace AdvUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SkipListAdd5()
        {
            SkipList<int> list = new SkipList<int>();
            Random rand = new Random();
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(rand.Next(1, 10000));
            }
            stopwatch.Start();
            for (int i = 0; i < 50; i++)
            {
                list.Search(rand.Next(1, 10000), list.head);
            }
            stopwatch.Stop();
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 700 && stopwatch.ElapsedMilliseconds > 650);
        }
    }
}
