using System;

public class Solution {
    public int[] SmallestK(int[] arr, int k) {
        var rand = new Random();

        void Swap(int i, int j) {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

        int Partition(int left, int right) {
            Swap(left, rand.Next(right - left + 1) + left);
            var pivot = arr[left];
            while (left < right) {
                while (left < right && arr[right] >= pivot) --right;
                arr[left] = arr[right];
                while (left < right && arr[left] <= pivot) ++left;
                arr[right] = arr[left];
            }

            arr[left] = pivot;
            return left;
        }

        void Quick(int left, int right) {
            if (left >= right) return;
            var mid = Partition(left, right);
            if (mid == k) return;
            else if (mid > k) Quick(left, mid - 1);
            else Quick(mid + 1, right);
        }

        Quick(0, arr.Length - 1);
        return arr[..k];
    }
}