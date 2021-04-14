using System;

public class NumArray {
    private int[] tree;
    private int n;
    private int[] nums;

    int LowBit(int x) {
        return x & -x;
    }

    int Query(int idx) {
        var res = 0;
        while (idx > 0) {
            res += tree[idx];
            idx -= LowBit(idx);
        }

        return res;
    }

    void Add(int idx, int k) {
        while (idx <= n) {
            tree[idx] += k;
            idx += LowBit(idx);
        }
    }

    public NumArray(int[] nums) {
        this.nums = nums;
        n = nums.Length;
        tree = new int [n + 1];
        nums.CopyTo(tree, 1);
        for (var i = 1; i <= n; ++i) {
            var j = i + LowBit(i);
            if (j <= n) tree[j] += tree[i];
        }
    }

    public void Update(int index, int val) {
        Add(index + 1, val - nums[index]);
        nums[index] = val;
    }

    public int SumRange(int left, int right) {
        return Query(right + 1) - Query(left);
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */