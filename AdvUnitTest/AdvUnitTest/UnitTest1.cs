using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JPanAdvDataStructure;
using System.Diagnostics;
using System.Collections.Generic;

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
        } 
        [TestMethod]
        public void HashMapAllFunctions()
        {
            HashMap<int, int> hashMap = new HashMap<int, int>();
            hashMap.Add(1, 5);
            hashMap.Add(19, 17);
            hashMap.Add(7, 14);
            hashMap.Add(46, 18);
            hashMap.Add(6, 13);
            hashMap.Add(13, 49);
            hashMap.Add(84, 82);
            hashMap.Add(92, 98);
            hashMap.Add(31, 92);
            hashMap.Add(57, 13);
            hashMap.Add(78, 78);
            hashMap.Remove(7);

            hashMap[3] = 2; //if key doesn't exist, add a k/v pair

            int value;
            Assert.IsTrue(hashMap.TryGetValue(19, out value));
            Assert.IsFalse(hashMap.ContainsKey(7));
            Assert.IsFalse(hashMap.pairs[13] == null);
            for (int i = 0; i < hashMap.pairs.Length; i++)
            {
                if (hashMap.pairs[i] == null) continue;
                foreach(var pair in hashMap)
                {
                    
                }
            }
        }
    }
}
