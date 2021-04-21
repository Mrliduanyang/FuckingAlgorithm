public class Solution {
    public int[] GetLeastNumbers(int[] arr, int k) {
        var nums = arr;

        void Swap(int i, int j) {
            var tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        void MinHeapify(int i, int heapSize) {
            int l = 2 * i + 1, r = 2 * i + 2, smallest = i;
            if (l < heapSize && nums[l] < nums[smallest]) smallest = l;
            if (r < heapSize && nums[r] < nums[smallest]) smallest = r;
            if (smallest != i) {
                Swap(i, smallest);
                MinHeapify(smallest, heapSize);
            }
        }

        void BuildMinHeap(int heapSize) {
            for (var i = heapSize / 2; i >= 0; --i) {
                MinHeapify(i, heapSize);
            }
        }

        var heapSize = nums.Length;
        BuildMinHeap(heapSize);
        for (var i = nums.Length - 1; i >= nums.Length - k; --i) {
            Swap(0, i);
            --heapSize;
            MinHeapify(0, heapSize);
        }

        return nums[^k..];
    }
}