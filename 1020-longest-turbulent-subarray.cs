public class Solution {
    public int MaxTurbulenceSize(int[] arr) {
        var res = 1;
        int left = 0, right = 0;
        var window = new List<int>();
        while (right < arr.Length - 1) {
            if (left == right) {
                if (arr[left] == arr[left + 1]) left++;
                right++;
            }
            else {
                if (arr[right - 1] < arr[right] && arr[right] > arr[right + 1])
                    right++;
                else if (arr[right - 1] > arr[right] && arr[right] < arr[right + 1])
                    right++;
                else
                    left = right;
            }

            res = Math.Max(res, right - left + 1);
        }

        return res;
    }
}