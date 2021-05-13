
public class Solution {
    public bool IsUnique(string astr) {
        var mask = 0;
        foreach (var ch in astr) {
            var offset = ch - 'a';
            var idx = 1 << offset;
            if ((mask & idx) != 0) {
                return false;
            }

            mask |= idx;
        }

        return true;
    }
}