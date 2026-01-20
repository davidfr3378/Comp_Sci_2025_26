using System;
using System.Diagnostics;

/*
 * A culminating activity: Searching & Sorting 
 * - sorting algos: bubbleSort, mergeSort, heapSort
 * - searching algos used: Linear Search and Binary Search
 * - It generates a random array (20-40 ints) and provides a menu to pick a sort and a search ##
 */
class Culminating_SearchingSorting
{
    public static void bubbleSort(int[] arr)
    {
        // Simple bubble sort with counters for comparisons and swaps
        int n = arr.Length;
        long comparisons = 0;
        long swaps = 0;

        bool swapped;
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - 1 - i; j++)
            {
                comparisons++; // compare arr[j] and arr[j+1]
                if (arr[j] > arr[j + 1])
                {
                    // swap
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swaps++;
                    swapped = true;
                }
            }
            // If no swaps this pass, array is already sorted
            if (!swapped) break;
        }

        Console.WriteLine($"[BubbleSort] Comparisons: {comparisons}, Swaps: {swaps}");
    }

    public static void mergeSort(int[] arr, int left, int right)
    {
        // Divide-and-conquer merge sort. Recursively split and merge.
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            mergeSort(arr, left, mid);
            mergeSort(arr, mid + 1, right);
            merge(arr, left, mid, right);
        }
    }

    private static void merge(int[] arr, int left, int mid, int right)
    {
        // Merge two sorted subarrays 
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++) L[i] = arr[left + i];
        for (int j = 0; j < n2; j++) R[j] = arr[mid + 1 + j];

        int ii = 0, jj = 0, k = left;
        while (ii < n1 && jj < n2)
        {
            if (L[ii] <= R[jj])
            {
                arr[k++] = L[ii++];
            }
            else
            {
                arr[k++] = R[jj++];
            }
        }
        while (ii < n1) arr[k++] = L[ii++];
        while (jj < n2) arr[k++] = R[jj++];
    }

    public static void heapSort(int[] arr)
    {
        // Build heap then repeatedly extract max to sort in ascending order
        int n = arr.Length;

        // Build max heap
        for (int i = n / 2 - 1; i >= 0; i--) heapify(arr, n, i);

        // One by one extract elements from heap
        for (int i = n - 1; i >= 0; i--)
        {
            // Move current root (largest) to end
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // call max heapify on the reduced heap
            heapify(arr, i, 0);
        }
    }

    private static void heapify(int[] arr, int heapSize, int rootIndex)
    {
        int largest = rootIndex;
        int left = 2 * rootIndex + 1;
        int right = 2 * rootIndex + 2;

        if (left < heapSize && arr[left] > arr[largest]) largest = left;
        if (right < heapSize && arr[right] > arr[largest]) largest = right;

        if (largest != rootIndex)
        {
            int swap = arr[rootIndex];
            arr[rootIndex] = arr[largest];
            arr[largest] = swap;

            // Recursively heapify the affected sub-tree
            heapify(arr, heapSize, largest);
        }
    }

    public static int linearSearch(int[] arr, int target)
    {
        // Loop through array and return first index where value equals target
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target) return i;
        }
        return -1;
    }

    public static int binarySearch(int[] arr, int target)
    {
        // binary search on a sorted array
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (arr[mid] == target) return mid;
            else if (arr[mid] < target) low = mid + 1;
            else high = mid - 1;
        }
        return -1;
    }

    // --- HELPER METHODS TO HELP ---
    private static void printArray(string label, int[] arr)
    {
        Console.Write(label + ": [");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
            if (i < arr.Length - 1) Console.Write(", ");
        }
        Console.WriteLine("]");
    }

    private static int[] copyArray(int[] arr)
    {
        int[] copy = new int[arr.Length];
        Array.Copy(arr, copy, arr.Length);
        return copy;
    }

    // --- MAIN METHOD AND I/O ---
    static void Main(string[] args)
    {
        Random rnd = new Random();

        int size = 20 + rnd.Next(21); // random size between 20 and 40 inclusive
        int[] data = new int[size];
        for (int i = 0; i < size; i++) data[i] = rnd.Next(100); // values 0..99

        Console.WriteLine($"Generated array of {size} random integers.");
        printArray("Unsorted", data);

        Console.WriteLine();
        Console.WriteLine("Choose a sorting algorithm:");
        Console.WriteLine("1 - Bubble Sort");
        Console.WriteLine("2 - Merge Sort");
        Console.WriteLine("3 - Heap Sort");
        Console.Write("Enter choice (1-3): ");
        string sortLine = Console.ReadLine();
        int sortChoice = 2;
        if (!int.TryParse(sortLine, out sortChoice)) sortChoice = 2;

        // copy the original unsorted array so we can show timings on that exact data if needed
        int[] toSort = copyArray(data);

        var sw = Stopwatch.StartNew();
        switch (sortChoice)
        {
            case 1:
                bubbleSort(toSort);
                break;
            case 2:
                mergeSort(toSort, 0, toSort.Length - 1);
                break;
            case 3:
                heapSort(toSort);
                break;
            default:
                Console.WriteLine("Invalid choice bro. Defaulting to Merge Sort.");
                mergeSort(toSort, 0, toSort.Length - 1);
                break;
        }
        sw.Stop();

        printArray("Sorted", toSort);
        Console.WriteLine($"Sort time: {sw.Elapsed.TotalMilliseconds:F3} ms"); //chatGPT helped me with this timing thing ngl

        Console.WriteLine();
        Console.Write("Enter a target integer to search for: ");
        string targetLine = Console.ReadLine();
        int target = 0;
        if (!int.TryParse(targetLine, out target)) target = 0;

        Console.WriteLine("Choose a search method:");
        Console.WriteLine("1 - Linear Search");
        Console.WriteLine("2 - Binary Search (requires sorted array)");
        Console.Write("Enter choice (1-2): ");
        string searchLine = Console.ReadLine();
        int searchChoice = 1;
        if (!int.TryParse(searchLine, out searchChoice)) searchChoice = 1;

        int resultIndex = -1;
        var sSw = Stopwatch.StartNew();
        if (searchChoice == 1)
        {
            resultIndex = linearSearch(toSort, target);
        }
        else
        {
            resultIndex = binarySearch(toSort, target);
        }
        sSw.Stop();

        if (resultIndex >= 0) Console.WriteLine("Number found at index " + resultIndex + ".");
        else Console.WriteLine("Number not found.");

        Console.WriteLine($"Search time: {sSw.Elapsed.TotalMilliseconds:F3} ms");
    }
}
