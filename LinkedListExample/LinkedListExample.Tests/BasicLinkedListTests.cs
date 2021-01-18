using System;
using System.Linq;
using LinkedListExample.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListExample.Tests
{
    [TestClass]
    public class BasicLinkedListTests
    {
        [TestMethod]
        public void TestEmpty()
        {
            IntegerLinkedList ill = new IntegerLinkedList();
            Assert.AreEqual(0, ill.Count);
        }

        [TestMethod]
        public void TestCount()
        {
            var ill = new IntegerLinkedList(5);
            ill.Append(7);
            ill.Append(9);
            Assert.AreEqual(3, ill.Count);
        }

        [TestMethod]
        public void TestSum()
        {
            var ill = new IntegerLinkedList(5);
            ill.Append(7);
            ill.Append(9);
            Assert.AreEqual(21, ill.Sum);
        }

        [TestMethod]
        public void TestToStringExplicit()
        {
            var ill = new IntegerLinkedList(5);
            ill.Append(7);
            ill.Append(9);
            Assert.AreEqual("{5, 7, 9}", ill.ToString());
        }

        [TestMethod]
        public void TestDelete()
        {
            var ill = new IntegerLinkedList(3);
            ill.Append(5);
            ill.Append(7);
            ill.Append(9);
            ill.Append(11);
            Assert.AreEqual(5, ill.Count);
            Assert.AreEqual(35, ill.Sum);
            Assert.IsTrue(ill.Delete(7));
            Assert.AreEqual(4, ill.Count);
            Assert.AreEqual(28, ill.Sum);
            Assert.IsFalse(ill.Delete(7));
            Assert.IsFalse(ill.Delete(10));

        }

        [TestMethod]
        public void TestRemoveDuplicates()
        {
            var ill = new IntegerLinkedList(3);
            ill.Append(5);
            ill.Append(3);
            ill.Append(5);
            ill.Append(7);
            Assert.AreEqual(5, ill.Count);
            Assert.AreEqual(23, ill.Sum);
            ill.RemoveDuplicates();
            Assert.AreEqual(3, ill.Count);
            Assert.AreEqual(15, ill.Sum);
        }

        [TestMethod]
        public void TestMerge()
        {
            var illOdd = new IntegerLinkedList();
            var illEven = new IntegerLinkedList();
            for(int i = 0; i < 10; ++i)
            {
                illEven.Append(i * 2);
                illOdd.Append(i * 2  + 1);
            }
            illEven.Merge(illOdd);
            Assert.AreEqual(20, illEven.Count);
            Assert.AreEqual(210, illEven.Sum);
        }
    }
}