public class Solution {
    public int[] FairCandySwap(int[] A, int[] B) {
                int diff = A.Sum() - B.Sum();
                var set = new HashSet<int>(A);
                foreach (var num in B) {
                    if (set.Contains((diff + 2 * num) / 2))
                        return new int[] {
                            (diff + 2 * num) / 2, num };
                }
                return new int[0];
    }
}