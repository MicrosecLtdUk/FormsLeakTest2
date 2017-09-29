using System;
using System.Collections.Generic;
using System.Linq;

namespace FormsLeakTest
{
 public static class MemoryTracker
	{
		private static List<WeakReference> wrList = new List<WeakReference>();

		public static void Track(object reference)
		{
			WeakReference wr = new WeakReference(reference);
			wrList.Add(wr);
		}

		public static int GetAliveObjectsCount()
		{
			int count = wrList.Count(wr => wr.IsAlive);
			return count;
		}

        public static List<WeakReference> GetAliveObjects()
        {
            List<WeakReference> ReturnValue = new List<WeakReference>();
            foreach (var item in wrList.Where(x => x.IsAlive == true))
            {
                ReturnValue.Add(item);
            }
            return ReturnValue;
        }
	}

}

