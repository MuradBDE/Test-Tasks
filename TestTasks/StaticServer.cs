using System;
using System.Threading;

namespace TestTasks
{
    public class StaticServer
    {
        private static int count;
        public static int readCount = 0;
        public static int writeCount = 0;
        private static ReaderWriterLock rwLock = new ReaderWriterLock();

       

        // Метод для записи
        public static int GetCount()
        {
            rwLock.AcquireReaderLock(100);
            try
            {
                readCount++;
                return count;
            }
            finally
            {
                rwLock.ReleaseReaderLock();
            }
        }

        // Метод для чтения
        public static void AddToCount(int value)
        {
            rwLock.AcquireWriterLock(100);
            try
            {
                checked
                {
                    writeCount++;
                    count += value;
                }
            }
            finally
            {
                rwLock.ReleaseWriterLock();
            }
        }
    }
}
