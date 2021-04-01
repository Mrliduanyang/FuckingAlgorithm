            class NumArray {
                int[] sums;
                public NumArray(int[] nums) {
                    int n = nums.Length;
                    sums = new int[n + 1];
                    for (int i = 0; i < n; i++) {
                        sums[i + 1] = sums[i] + nums[i];
                    }
                }

                public int SumRange(int i, int j) {
                    return sums[j + 1] - sums[i];
                }
            }