public class Solution {
    public int HIndex(int[] citations) {
                int n = citations.Length;
                int[] papers = new int[n + 1];
                foreach (var citation in citations) {
                    papers[Math.Min(n, citation)]++;
                }
                int k = n;
                for (int s = papers[n]; k > s; s += papers[k]) {
                    k--;
                }
                return k;
    }
}