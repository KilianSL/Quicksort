using System;

namespace QuickSort
{
    class BasicRecursiveQuicksort : sorter
    {
        public BasicRecursiveQuicksort() : base("quicksort") { }
        public override void sort(int[] tosort)
        {
            sortRecursive(ref tosort, 0, tosort.Length - 1);
            Console.WriteLine($"{this.name} properly sorted: {verifySorted(tosort)}");
        }

        private void sortRecursive(ref int[] arr, int lo, int hi) //lo = start index, hi = end index for partition. Using indexes like this allows the algorithm to work in-place
        { // This method controls the recursion and flow of the sort  
            if (lo < hi)
            {
                // pi is the partition index i.e. the point on which the array pivots
                int pi = partition(ref arr, lo, hi); //Passes array by reference: less memory overhead

                sortRecursive(ref arr, lo, pi - 1); // Sorts lower sub-list
                sortRecursive(ref arr, pi + 1, hi); // Sorts higher sub-list

            }
        }

        private int partition(ref int[] arr, int lo, int hi)
        { //This method performs the actual sort - it pivots around a certain point and ensures all values within range lo and hi sit at the right side of the point

            int pi = arr[hi]; //Gets element to pivot on
            int i = (lo - 1);

            for (int j = lo; j < hi; j++)
            {
                if (arr[j] < pi) // Comparison -> is the selected element lower than the pivot?
                {
                    i++; // Increment index of smallest element
                    int _x = arr[i];
                    arr[i] = arr[j];
                    arr[j] = _x; // Swaps the element in the wrong place with the smallest element
                }
            }
            int _ = arr[i + 1];
            arr[i + 1] = arr[hi];
            arr[hi] = _;

            return (i + 1);
        }
    }

}
