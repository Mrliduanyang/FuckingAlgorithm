public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length) return false;
        var counter1 = new int[26];
        var counter2 = new int[26];
        for (var i = 0; i < s1.Length; i++) {
            counter1[s1[i] - 'a']++;
            counter2[s2[i] - 'a']++;
        }

        if (Enumerable.SequenceEqual(counter1, counter2)) return true;
        for (var i = s1.Length; i < s2.Length; i++) {
            counter2[s2[i] - 'a']++;
            counter2[s2[i - s1.Length] - 'a']--;
            if (Enumerable.SequenceEqual(counter1, counter2)) return true;
            ;
        }

        return false;
    }
}