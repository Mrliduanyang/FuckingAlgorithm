public class Solution {

                int[] _nums;
                int[] _shuffle;
                Random r = new Random();
                public Solution(int[] nums) {
                    _nums = nums;
                    _shuffle = nums.Clone() as int[];
                }
                public int[] Reset() {
                    return _nums;
                }

                public int[] Shuffle() {
                    for (int i = 0; i < _nums.Length; i++) {
                        // var index = r.Next(_nums.Length);
                        var index = r.Next(i, _nums.Length);
                        var tmp = _shuffle[i];
                        _shuffle[i] = _shuffle[index];
                        _shuffle[index] = tmp;
                    }
                    return _shuffle;
                }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */