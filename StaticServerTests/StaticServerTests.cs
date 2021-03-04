using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestTasks.Tests
{
    [TestClass()]
    public class StaticServerTests
    {
        [TestMethod()]
        public void GetCountTest()
        {
            //arrange
            int readCount = 10000;
            int writeCount = 1000;
            var tasks = new List<Task>();

            //act
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tasks.Add(
                        Task.Factory.StartNew((() => StaticServer.GetCount())));
                }
                tasks.Add(
                    Task.Factory.StartNew(() => StaticServer.AddToCount(1)));
            }
            Task.WaitAll(tasks.ToArray());

            //assert
            Assert.AreEqual(1000, StaticServer.GetCount());
        }
    }
}