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
        public void SkipListAdd1000()
        {
            SkipList<int> list = new SkipList<int>();
            Random rand = new Random();
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(rand.Next(1, 10000));
            }
            stopwatch.Start();
            for (int i = 0; i < 50; i++)
            {
                list.Search(rand.Next(1, 10000), list.head);
            }
            stopwatch.Stop();
            Assert.IsTrue(stopwatch.ElapsedMilliseconds > 450 && stopwatch.ElapsedMilliseconds < 550);
        }
        [TestMethod]
        public void SkipListAddDelete5()
        {
            SkipList<int> list = new SkipList<int>();
            list.Add(5);
            list.Add(17);
            list.Add(2);
            list.Add(24);
            list.Add(67);
            list.Remove(24);
            Assert.IsTrue(list.head.Nexts[0].Value == 2 && list.head.Nexts[0].Nexts[0].Value == 5
                && list.head.Nexts[0].Nexts[0].Nexts[0].Value == 17 && list.head.Nexts[0].Nexts[0].Nexts[0].Nexts[0].Value == 67);
        } //adding is fine, but removing makes inconsistent deletions and makes weird things happen 
        //sometimes only last check fails, sometimes first check fails
    }
}
