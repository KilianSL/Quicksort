using System;
using System.Linq;

namespace QuickSort
{
    abstract class sorter
    {
        protected String name { get; }
        public String GetName() { return name; }
        public sorter(String name) { this.name = name; }
        public abstract void sort(int[] tosort);
        protected static bool verifySorted(int[] arr) // Helper function to verify the sorting algo worked properly. 
        {
            var sorted = new int[arr.Length];
            arr.CopyTo(sorted, 0); // Creates copy of arr to compare to

            Array.Sort(sorted);

            return sorted.SequenceEqual(arr); // Checks implemented sort is equal to properly sorted array 
        }

    }

    class Program
    {
        

        

       



        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] tosort = new int[100000];
            for (int i = 0; i < tosort.Length; i++)
            {
                tosort[i] = rand.Next(0, 500000); //populates an array of 10000 random ints
            }

            var timer = new System.Diagnostics.Stopwatch();
            var sorters = new System.Collections.Generic.List<sorter>();
            sorters.Add(new BasicRecursiveQuicksort());
            sorters.Add(new OptimizedQuicksort());

            foreach (var s in sorters)
            {
                timer.Reset();
                timer.Start();
                s.sort(tosort);

                Console.WriteLine("{1} sort, Elapsed={0}", timer.Elapsed, s.GetName());
            }
        }
    }
}
