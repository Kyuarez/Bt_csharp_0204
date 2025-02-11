namespace bt_csharp_0211_customGC
{
    using System;
    using System.Collections.Generic;

    /* .NET GC 특징
     * 1. 관리된 힙 영역을 세대 별로 나뉘어서 관리한다.
     * 2. 큰 메모리, 작은 메모리 구분해서 별도의 힙에 정리한다. (SOH, LOH)
     * 3. 전용 쓰레드로 처리한다.    
     */
    public class SimpleVSGC
    {
        private List<object> gen0List = new List<object>();
        private List<object> gen1List = new List<object>();
        private List<object> gen2List = new List<object>();

        private Thread gcThread;
        private bool gcRequested = false;
    
        public SimpleVSGC()
        {
            gcThread = new Thread(CollectInBackground);
            gcThread.Start();
        }
        
        public void Allocate(object obj)
        {
            gen0List.Add(obj);
            if(gen0List.Count >= gen0LimitAmount)
            {
                RequestGarbageCollection(0);
            }
            if (gen0List.Count + gen1List.Count + gen2List.Count >= totalLimitAmount)
            {
                RequestGarbageCollection(2);
            }
        }

        private void Collect()
        {
            if(gen0List.Count + gen1List.Count + gen2List.Count >= totalLimitAmount)
            {
                UpdateGeneration(gen0List, gen1List);
                UpdateGeneration(gen1List, gen2List);
                UpdateGeneration(gen2List, null);
                return;
            }

            if(gen0List.Count >= gen0LimitAmount)
            {
                UpdateGeneration(gen0List, gen1List);
            }
        }

        private void UpdateGeneration(List<object> currentGen, List<object> nextGen)
        {
            for (int i = currentGen.Count - 1; i >= 0; i--)
            {
                if (true == IsGarbage(currentGen[i]))
                {
                    currentGen.RemoveAt(i);
                }
                else if(nextGen != null)
                {
                    nextGen.Add(currentGen[i]);
                    currentGen.RemoveAt(i);
                }
            }
        }

        private bool IsGarbage(object obj)
        {
            return obj == null;
        }

        #region Thread
        private void RequestGarbageCollection(int generation)
        {
            lock (this) 
            {
                gcRequested = true;
                Monitor.Pulse(this);
            }
        }

        private void CollectInBackground()
        {
            while (true)
            {
                lock (this)
                {
                    while (!gcRequested)
                    {
                        Monitor.Wait(this);
                    }
                    gcRequested = false;
                }
                Collect();
            }
        }
        #endregion

        private readonly int gen0LimitAmount = 10;
        private readonly int totalLimitAmount = 30;

    
    }


    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }


}
