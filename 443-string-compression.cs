public class Solution {
    public int Compress(char[] chars) {
        var length = chars.Length;
        int slow = 0, fast = 0, cur = 0;
        while (fast <= length) {
            if (fast == length || chars[fast] != chars[slow]) {
                chars[cur++] = chars[slow];
                if (fast - slow >= 2)
                    foreach (var ch in (fast - slow).ToString())
                        chars[cur++] = ch;
                slow = fast;
            }

            fast++;
        }

        return chars.Take(cur).Count();
    }
}