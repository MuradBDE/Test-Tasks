using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using TestTasks;

namespace UnitTests
{
    [TestClass]
    public class AsyncCallerTests
    {
        [TestMethod]
        public void Invoke_1000_ReturnTrue()
        {
            //arrange
            var h = new EventHandler((sender, args) => Thread.Sleep(1000));
            var ac = new AsyncCaller(h);

            //act
            bool completedOK = ac.Invoke(5000, null, EventArgs.Empty);

            //assert
            Assert.IsTrue(completedOK);
        }
        [TestMethod]
        public void Invoke_6000_ReturnFalse()
        {
            //arrange
            var h = new EventHandler((sender, args) => Thread.Sleep(6000));
            var ac = new AsyncCaller(h);

            //act
            bool completedOK = ac.Invoke(5000, null, EventArgs.Empty);

            //assert
            Assert.IsFalse(completedOK);
        }
    }
}
