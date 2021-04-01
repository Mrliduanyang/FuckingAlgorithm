public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var dict = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        // [val, key]，大顶堆，先比较val大，key大的在堆顶
        var heap = new SortedSet<int[]>(Comparer<int[]>.Create((x, y) => x[0] != y[0] ? y[0] - x[0] : y[1] - x[1]));
        foreach (var (key, val) in dict) {
            heap.Add(new[] {val, key});
            if (heap.Count > k) heap.Remove(heap.Last());
        }

        var res = heap.Select(x => x[1]).ToArray();
        return res;
    }
}