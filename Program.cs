using System;
using System.Collections;
using System.Collections.Generic;
namespace FuckingAlgorithm {
    class Program {

        class Fib {
            static int fib(int N) {
                int[] dp = new int[N + 1];
                dp[1] = dp[2] = 1;
                for (int i = 3; i <= N; i++) {
                    dp[i] = dp[i - 1] + dp[i - 2];
                }
                return dp[N];
            }
        }

        class CoinChange {
            static int coinChange(int[] coins, int amount) {
                // 当目标金额为i时，至少需要dp[i]枚硬币凑出
                // 初始化dp，dp各元素设置为最大值
                int[] dp = new int[amount + 1];
                Array.Fill(dp, amount + 1);
                // base，金额为0，硬币为0
                dp[0] = 0;
                // 求dp中所有金额
                for (int i = 0; i < dp.Length; i++) {
                    // 遍历可用的硬币
                    foreach (var coin in coins) {
                        // 减去硬币面值后，金额小于0，无解跳过
                        if (i - coin < 0) continue;
                        // 选择硬币数最少的方案
                        dp[i] = Math.Min(dp[i], 1 + dp[i - coin]);
                    }
                }
                return (dp[amount] == amount + 1) ? -1 : dp[amount];
            }
        }

        class Permute {
            // 存储全排列结果
            static List<int[]> res = new List<int[]>();
            List<int[]> permute(int[] nums) {

                // 回溯路径
                List<int> track = new List<int>();
                backtrack(nums, track);
                return res;
            }
            static void backtrack(int[] nums, List<int> track) {
                if (track.Count == nums.Length) {
                    // 结束条件，如果nums中所有元素都在track中，找到一个全排列，添加进全排列结果里
                    res.Add(track.ToArray());
                    return;
                }
                // 做选择
                foreach (var num in nums) {
                    // 如果路径中已存在元素num，则跳过
                    if (track.Contains(num)) {
                        continue;
                    }
                    // 做选择
                    track.Add(num);
                    // 进入下一层选择
                    backtrack(nums, track);
                    // 回溯，撤销选择
                    track.RemoveAt(track.Count - 1);
                }
            }
        }

        class FindTargetSumWays {
            static int res;
            static Dictionary<string, int> memo = new Dictionary<string, int>();
            public static int findTargetSumWays(int[] nums, int target) {
                // backtrack(nums, 0, target);
                // return res;
                return dp(nums, 0, target);
            }
            static void backtrack(int[] nums, int i, int rest) {
                // base 用完所有数字，rest为0，说明凑出一个target
                if (i == nums.Length) {
                    if (rest == 0) {
                        res++;
                    }
                    return;
                }
                // 存在重叠子问题，如果nums[i] = 0，两个backtrack重复，用备忘录消除重叠子问题
                // 做选择，选择-号
                rest += nums[i];
                backtrack(nums, i + 1, rest);
                rest -= nums[i];

                // 做选择，选择+号
                rest -= nums[i];
                backtrack(nums, i + 1, rest);
                rest += nums[i];

            }

            static int dp(int[] nums, int i, int rest) {
                if (i == nums.Length) {
                    if (rest == 0) {
                        return 1;
                    }
                    return 0;
                }
                string key = i + "," + rest;
                if (memo.ContainsKey(key)) {
                    return memo[key];
                }
                // 加上或者减去当前元素后，有多少种方案能凑出新的target
                int result = dp(nums, i + 1, rest - nums[i]) + dp(nums, i + 1, rest + nums[i]);
                memo.Add(key, result);
                return result;
            }

        }

        class LIS {
            public static int LengthOfLIS(int[] nums) {
                int[] dp = new int[nums.Length];
                // base， 以nums[i]结尾的最长递增子序列起码包含自己
                Array.Fill(dp, 1);
                // 找到前面比nums[i]小的元素，将nums[i]加在该元素后面，并将长度+1
                for (int i = 0; i < nums.Length; i++) {
                    for (int j = 0; j < i; j++) {
                        if (nums[i] > nums[j]) {
                            dp[i] = Math.Max(dp[i], dp[j] + 1);
                        }
                    }
                }
                Array.Sort(dp);
                return dp[dp.Length - 1];
            }
        }

        class MaxSubArray {
            public static int maxSubArray(int[] nums) {
                if (nums.Length == 0) {
                    return 0;
                }
                // base第1个元素前面没有子数组，其本身就是最大
                int[] dp = new int[nums.Length];
                // 状态转移，元素nums[i]要么自己最大，要么和前面的子数组连起来后最大
                for (int i = 1; i < nums.Length; i++) {
                    dp[i] = Math.Max(nums[i], nums[i] + dp[i - 1]);
                }
                Array.Sort(dp);
                return dp[dp.Length - 1];
            }
        }
        class CanPartition {
            public static bool canPartition(int[] nums) {

                int sum = 0;
                foreach (var item in nums) {
                    sum += item;
                }
                // 如果和是奇数，没法等分，就不存在等和子集
                if (sum % 2 != 0) {
                    return false;
                }
                int n = nums.Length;
                sum = sum / 2;
                // 对于前i个物体，当背包容量为j时，是否可以装满
                bool[, ] dp = new bool[n + 1, sum + 1];
                // base当背包容量为0，肯定已经装满，当没有物体，肯定无法装满
                for (int i = 1; i <= n; i++) {
                    dp[i, 0] = true;
                }
                for (int i = 1; i <= n; i++) {
                    for (int j = 1; j <= sum; j++) {
                        if (j - nums[i - 1] < 0) {
                            // 背包容量不足，不能装入第 i 个物品
                            dp[i, j] = dp[i - 1, j];
                        } else {
                            // 能装，但可以选择装或者不装
                            dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i - 1]];
                        }
                    }
                }
                return dp[n, sum];
            }
        }
        static void Main(string[] args) {
            bool res = CanPartition.canPartition(new int[] { 1, 2, 2 });
            System.Console.WriteLine(res);
        }
    }
}