public class Solution {
public int[] RelativeSortArray(int[] arr1, int[] arr2) {
                int upper = arr1.Max();
                int[] frequency = new int[upper + 1];
                foreach (var x in arr1) {
                    frequency[x]++;
                }
                int[] ans = new int[arr1.Length];
                int index = 0;
                foreach (var x in arr2) {
                    for (int i = 0; i < frequency[x]; ++i) {
                        ans[index++] = x;
                    }
                    frequency[x] = 0;
                }
                for (int x = 0; x <= upper; ++x) {
                    for (int i = 0; i < frequency[x]; ++i) {
                        ans[index++] = x;
                    }
                }
                return ans;
            }
}