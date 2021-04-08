using System;
using System.Collections.Generic;

public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        int left = 0;
        int right = arr.Length - 1;

        while (right - left >= k) {
            if (Math.Abs(x - arr[left]) <= Math.Abs(arr[right] - x)) {
                right--;
            }
            else {
                left++;
            }
        }
        
        return arr[left..(right + 1)];
    }
}