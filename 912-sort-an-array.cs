using System;
using System.Linq;

public class Solution {
    public int[] BubbleSort(int[] nums) {
        for (var i = 0; i < nums.Length - 1; ++i) {
            for (var j = 0; j < nums.Length - 1 - i; ++j) {
                if (nums[j] > nums[j + 1]) {
                    Swap(j, j + 1);
                }
            }
        }

        return nums;
    }

    public int[] BubbleSortWithFlag(int[] nums) {
        void Swap(int i, int j) {
            nums[i] = nums[i] ^ nums[j];
            nums[j] = nums[i] ^ nums[j];
            nums[i] = nums[i] ^ nums[j];
        }

        var swapped = true;
        for (var i = 0; i < nums.Length - 1; ++i) {
            if (!swapped) break;
            swapped = false;
            for (var j = 0; j < nums.Length - 1 - i; ++j) {
                if (nums[j] > nums[j + 1]) {
                    Swap(j, j + 1);
                    swapped = true;
                }
            }
        }

        return nums;
    }

    public void SelectionSort(int[] nums) {
        for (var i = 0; i < nums.Length - 1; i++) {
            var minIndex = i;
            for (var j = i + 1; j < nums.Length; j++) {
                if (nums[minIndex] > nums[j]) {
                    minIndex = j;
                }
            }

            Swap(nums, i, minIndex);
        }
    }

    public void SelectionSort2(int[] nums) {
        for (var i = 0; i < nums.Length / 2; i++) {
            var minIndex = i;
            var maxIndex = i;
            for (var j = i + 1; j < nums.Length - i; j++) {
                if (nums[minIndex] > nums[j]) minIndex = j;
                if (nums[maxIndex] < nums[j]) maxIndex = j;
            }

            if (minIndex == maxIndex) break;
            Swap(nums, i, minIndex);
            if (maxIndex == i) maxIndex = minIndex;
            var lastIndex = nums.Length - 1 - i;
            Swap(nums, lastIndex, maxIndex);
        }
    }

    public int[] InsertSort(int[] nums) {
        void Swap(int i, int j) {
            nums[i] = nums[i] ^ nums[j];
            nums[j] = nums[i] ^ nums[j];
            nums[i] = nums[i] ^ nums[j];
        }

        for (var i = 1; i < nums.Length; i++) {
            var j = i;
            while (j >= 1 && nums[j] < nums[j - 1]) {
                Swap(j, j - 1);
                j--;
            }
        }

        return nums;
    }

    public int[] InsertSortWithMove(int[] nums) {
        for (var i = 1; i < nums.Length; i++) {
            var curNum = nums[i];
            var j = i - 1;
            while (j >= 0 && curNum < nums[j]) {
                nums[j + 1] = nums[j];
                j--;
            }

            nums[j + 1] = curNum;
        }

        return nums;
    }

    public ListNode InsertionSortList(ListNode head) {
        if (head == null) {
            return head;
        }

        var dummy = new ListNode(0);
        dummy.next = head;
        var last = head;
        var cur = head.next;
        while (cur != null) {
            if (last.val <= cur.val) {
                last = last.next;
            }
            else {
                var prev = dummy;
                while (prev.next.val <= cur.val) {
                    prev = prev.next;
                }

                last.next = cur.next;
                cur.next = prev.next;
                prev.next = cur;
            }

            cur = last.next;
        }

        return dummy.next;
    }

    public int[] HeapSort(int[] nums) {
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
            for (var i = heapSize / 2; i >= 0; --i) {
                MaxHeapify(i, heapSize);
            }
        }

        var heapSize = nums.Length;
        BuildMaxHeap(heapSize);
        for (var i = nums.Length - 1; i >= 0; --i) {
            Swap(0, i);
            --heapSize;
            MaxHeapify(0, heapSize);
        }

        return nums;
    }

    public int[] QuickSort(int[] nums) {
        var rand = new Random();

        void Swap(int i, int j) {
            var tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        int Partition(int left, int right) {
            Swap(left, rand.Next(right - left + 1) + left);

            var pivot = nums[left];
            while (left < right) {
                while (left < right && nums[right] >= pivot) --right;
                nums[left] = nums[right];
                while (left < right && nums[left] <= pivot) ++left;
                nums[right] = nums[left];
            }

            nums[left] = pivot;
            return left;
        }

        void Quick(int left, int right) {
            if (left >= right) return;
            var mid = Partition(left, right);
            Quick(left, mid - 1);
            Quick(mid + 1, right);
        }

        Quick(0, nums.Length - 1);
        return nums;
    }

    public int[] MergeSort(int[] nums) {
        var tmp = new int[nums.Length];

        void Merge(int left, int mid, int right) {
            int i = left, j = mid + 1;
            for (var k = left; k <= right; ++k) tmp[k] = nums[k];
            for (var k = left; k <= right; ++k) {
                if (i > mid) nums[k] = tmp[j++];
                else if (j > right) nums[k] = tmp[i++];
                else if (tmp[i] < tmp[j]) nums[k] = tmp[i++];
                else nums[k] = tmp[j++];
            }
        }

        void Sort(int left, int right) {
            if (left >= right) return;
            var mid = left + (right - left) / 2;
            Sort(left, mid);
            Sort(mid + 1, right);
            Merge(left, mid, right);
        }

        Sort(0, nums.Length - 1);
        return nums;
    }

    public void Merge(int[] A, int m, int[] B, int n) {
        int i = m - 1, j = n - 1;
        for (var k = m + n - 1; k >= 0; --k) {
            if (i < 0) A[k] = B[j--];
            else if (j < 0) A[k] = A[i--];
            else if (A[i] > A[j]) A[k] = A[i--];
            else A[k] = B[j--];
        }
    }

    public int[] RadixSort(int[] nums) {
        var n = nums.Length;
        long exp = 1;
        var buf = new int[n];
        var maxVal = nums.Max();
        while (exp <= maxVal) {
            var cnt = new int[10];
            foreach (var num in nums) {
                var digit = (num / exp) % 10;
                ++cnt[digit];
            }

            for (var i = 1; i < 10; ++i) {
                cnt[i] += cnt[i - 1];
            }

            for (var i = n - 1; i >= 0; i--) {
                var digit = (nums[i] / exp) % 10;
                buf[cnt[digit] - 1] = nums[i];
                --cnt[digit];
            }

            buf.CopyTo(nums, 0);
            exp *= 10;
        }

        return nums;
    }

    public int[] SortArray(int[] nums) {
        return new int[] { };
    }
}