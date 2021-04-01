public class Solution {
            public bool IsValidSerialization(string preorder) {
                int slots = 1;
                int n = preorder.Length;
                for (int i = 0; i < n; ++i) {
                    if (preorder[i] == ',') {
                        --slots;
                        if (slots < 0) return false;
                        if (preorder[i - 1] != '#') slots += 2;
                    }
                }
                slots = (preorder[n - 1] == '#') ? slots - 1 : slots + 1;
                return slots == 0;
            }
}