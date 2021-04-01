public class RandomizedCollection {
    private Dictionary<int, SortedSet<int>> idx;
    private List<int> nums;
    private Random random;

    public RandomizedCollection() {
        idx = new Dictionary<int, SortedSet<int>>();
        nums = new List<int>();
        random = new Random();
    }

    public bool Insert(int val) {
        nums.Add(val);
        var set = idx.GetValueOrDefault(val, new SortedSet<int>());
        set.Add(nums.Count - 1);
        idx[val] = set;
        return set.Count == 1;
    }

    public bool Remove(int val) {
        if (!idx.ContainsKey(val)) return false;
        // 从val的索引集合中选择一个，换到最后，以实现O（1）的删除
        int i = idx[val].First();
        idx[val].Remove(i);

        if (i == nums.Count - 1) {
            // 如果要删除的正好是最后一个元素，直接从集合中删除索引
            idx[val].Remove(i);
        }
        else {
            // 否则，从val的索引集合中删除索引i，从lastNum的索引集合中删除最后一个，并添加i
            int lastNum = nums.Last();
            idx[lastNum].Remove(nums.Count - 1);
            idx[lastNum].Add(i);
            nums[i] = lastNum;
        }

        if (idx[val].Count == 0) idx.Remove(val);
        nums.RemoveAt(nums.Count - 1);
        return true;
    }

    public int GetRandom() {
        return nums[random.Next(nums.Count)];
    }
}

/**
 * Your RandomizedCollection object will be instantiated and called as such:
 * RandomizedCollection obj = new RandomizedCollection();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */