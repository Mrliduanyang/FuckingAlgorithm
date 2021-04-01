public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
                int n = nums.Length;
                int[] res = new int[n - k + 1];
                LinkedList<int> deque = new LinkedList<int>();
                for (int i = 0; i < n; i++) {
                    if (deque.Count != 0 && deque.First.Value < (i - k + 1)) {
                        deque.RemoveFirst(); //超出窗口长度时删除队首
                    }
                    while (deque.Count != 0 && nums[i] >= nums[deque.Last.Value]) {
                        deque.RemoveLast(); //如果遍历的元素大于队尾元素就删除队尾
                    }
                    deque.AddLast(i); //添加
                    if (i >= k - 1) {
                        res[i - k + 1] = nums[deque.First.Value]; //结果
                    }
                }
                return res;
    }
}