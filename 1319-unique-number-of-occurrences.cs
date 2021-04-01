public class Solution {
    public bool UniqueOccurrences(int[] arr) {
        var dict = new Dictionary<int, int>();
        foreach (var i in arr) {
            if (!dict.ContainsKey(i))
                dict.Add(i, 0);
            dict[i]++;
        }

        var hashSet = new HashSet<int>();
        foreach (var pair in dict) {
            if (hashSet.Contains(pair.Value))
                return false;
            hashSet.Add(pair.Value);
        }

        return true;
    }
}