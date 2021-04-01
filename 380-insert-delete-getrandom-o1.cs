public class RandomizedSet {

                Dictionary<int, int> idx;
                List<int> nums;
                Random random;
                public RandomizedSet() {
                    idx = new Dictionary<int, int>();
                    nums = new List<int>();
                    random = new Random();
                }

                public bool Insert(int val) {
                    if (idx.ContainsKey(val)) {
                        return false;
                    } else {
                        nums.Add(val);
                        idx[val] = nums.Count - 1;
                        return true;
                    }
                }

                public bool Remove(int val) {
                    if (!idx.ContainsKey(val)) {
                        return false;
                    }
                    var valIdx = idx[val];
                    if (valIdx != nums.Count - 1) {
                        var lastNum = nums.Last();
                        nums[valIdx] = lastNum;
                        idx[lastNum] = valIdx;
                    }
                    idx.Remove(val);
                    nums.RemoveAt(nums.Count - 1);
                    return true;
                }

                public int GetRandom() {
                    return nums[random.Next(nums.Count)];
                }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */