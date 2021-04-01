public class Solution {
            public List<bool> PrefixesDivBy5(int[] A) {
                var list = new List<bool>();
                int prefix = 0;
                int length = A.Length;
                for (int i = 0; i < length; i++) {
                    prefix = ((prefix << 1) + A[i]) % 5;
                    list.Add(prefix == 0);
                }
                return list;
            }
}