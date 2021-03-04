using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestTasks
{
    public class AsyncCaller
    {
        private EventHandler handler;

        public AsyncCaller(EventHandler handler)
        {
            this.handler = handler;
        }

        // Вызываемый метод
        public bool Invoke(int timeout, object sender, EventArgs args)
        {
            var task = Task.Factory.StartNew(() => handler.Invoke(sender, args));

            return task.Wait(timeout);
        }
    }
}
