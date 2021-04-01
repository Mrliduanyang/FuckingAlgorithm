public class Solution {
    public bool CanJump(int[] nums) {
        var n = nums.Length;
        var farthest = 0;
        for (var i = 0; i < n - 1; i++) {
            // 每一步都计算一下从当前位置最远能够跳到哪里。因为只要数组元素不为0，就肯定可以向前走，所以只需求得在位置i上能不能跳过终点。
            farthest = Math.Max(farthest, i + nums[i]);
            // 最远距离比当前位置还小，永远到不了最后。
            if (farthest <= i) return false;
        }

        return farthest >= n - 1;
    }
}