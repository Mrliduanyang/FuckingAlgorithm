public class Solution {
    public int FindKthLargest(int[] nums, int k) {
                void Swap(int i, int j) {
                    var tmp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = tmp;
                }
                void MaxHeapify(int i, int heapSize) {
                    int l = 2 * i + 1, r = 2 * i + 2, largest = i;
                    if (l < heapSize && nums[l] > nums[largest]) largest = l;
                    if (r < heapSize && nums[r] > nums[largest]) largest = r;
                    if (largest != i) {
                        Swap(i, largest);
                        MaxHeapify(largest, heapSize);
                    }
                }

                void BuildMaxHeap(int heapSize) {
                    // Floyd建堆，从最后一个内部节点开始（即末节点的父亲），依次执行下滤
                    for (int i = heapSize / 2; i >= 0; --i) {
                        MaxHeapify(i, heapSize);
                    }
                }

                // 原地堆排序
                int heapSize = nums.Length;
                BuildMaxHeap(heapSize);
                for (int i = nums.Length - 1; i >= nums.Length - k + 1; --i) {
                    Swap(0, i);
                    --heapSize;
                    MaxHeapify(0, heapSize);
                }
                return nums[0];
    }
}