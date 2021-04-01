public class Solution {
    public IList<int> PartitionLabels(string S) {
                int[] last = new int[26];
                int length = S.Length;
                for (int i = 0; i < length; i++) {
                    last[S[i] - 'a'] = i;
                }
                var partition = new List<int>();
                int start = 0, end = 0;
                for (int i = 0; i < length; i++) {
                    end = Math.Max(end, last[S[i] - 'a']);
                    if (i == end) {
                        partition.Add(end - start + 1);
                        start = end + 1;
                    }
                }
                return partition;
    }
}