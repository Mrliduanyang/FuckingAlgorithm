using System;
using System.Collections;
using System.Collections.Generic;
namespace FuckingAlgorithm {
    class Program {

        class DynamicProgram {
            public static int Fib(int N) {
                int[] dp = new int[N + 1];
                dp[1] = dp[2] = 1;
                for (int i = 3; i <= N; i++) {
                    dp[i] = dp[i - 1] + dp[i - 2];
                }
                return dp[N];
            }

            public static int CoinChange(int[] coins, int amount) {
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

            public static List<int[]> Permute(int[] nums) {
                // 存储全排列结果
                List<int[]> res = new List<int[]>();
                void backtrack(int[] nums, List<int> track) {
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

                // 回溯路径
                List<int> track = new List<int>();
                backtrack(nums, track);
                return res;
            }

            public static int FindTargetSumWays(int[] nums, int target) {
                int res;
                Dictionary<string, int> memo = new Dictionary<string, int>();
                void backtrack(int[] nums, int i, int rest) {
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

                int dp(int[] nums, int i, int rest) {
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
                // backtrack(nums, 0, target);
                // return res;
                return dp(nums, 0, target);
            }

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

            public static int MaxSubArray(int[] nums) {
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

            public static bool CanPartition(int[] nums) {

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

            public static int Change(int amount, int[] coins) {
                int n = coins.Length;
                int[, ] dp = new int[n + 1, amount + 1];
                // base不用任何硬币，凑不去任何金额，当要凑出0，只有一种方案
                for (int i = 0; i <= n; i++) {
                    dp[i, 0] = 1;
                }
                for (int i = 1; i <= n; i++) {
                    for (int j = 1; j <= amount; j++) {
                        if (j - coins[i - 1] >= 0) {
                            // 目标金额减去当前硬币金额大于硬币金额，可以使用该硬币，也可以不使用
                            dp[i, j] = dp[i - 1, j] + dp[i, j - coins[i - 1]];
                        } else {
                            // 不能使用该硬币
                            dp[i, j] = dp[i - 1, j];
                        }
                    }
                }
                return dp[n, amount];
            }

            public static int MinDistance(string s1, string s2) {
                int m = s1.Length, n = s2.Length;
                int[, ] dp = new int[m + 1, n + 1];
                // base，“”到m的编辑距离为0-m，“”到n的编辑距离为0-n
                for (int i = 0; i <= m; i++) {
                    dp[i, 0] = i;
                }
                for (int i = 0; i <= n; i++) {
                    dp[0, i] = i;
                }
                for (int i = 1; i <= m; i++) {
                    for (int j = 1; j <= n; j++) {
                        if (s1[i - 1] == s2[j - 1]) {
                            // 如果两个字符串当前位置字符一样，跳过
                            dp[i, j] = dp[i - 1, j - 1];
                        } else {
                            // 如果不一致，需要选择操作数最少的操作
                            dp[i, j] = Min(
                                // 把s[i]这个字符删掉，前移i，继续跟j对比
                                dp[i - 1, j] + 1,
                                // s1[i]后面插入一个和s2[j]一样的字符，因为i没变，所以前移j
                                dp[i, j - 1] + 1,
                                // 替换，把s1[i] 替换成s2[j]，然后同时前进
                                dp[i - 1, j - 1] + 1
                            );
                        }
                    }
                }
                return dp[m, n];
            }

            private static int Min(int a, int b, int c) {
                return Math.Min(Math.Min(a, b), c);
            }
        }

        class DataStructure {
            class Node {
                public Node(int k, int v) {
                    key = k;
                    val = v;
                }
                public int key, val;
                public Node next, prev;

            }

            class DoubleList {
                private Node head, tail;
                private int size;
                public DoubleList() {
                    head = new Node(0, 0);
                    tail = new Node(0, 0);
                    head.next = tail;
                    tail.prev = head;
                    size = 0;
                }
                public void AddLast(Node x) {
                    // 把x插入到tail之前
                    x.prev = tail.prev;
                    x.next = tail;
                    tail.prev.next = x;
                    tail.prev = x;
                    size++;
                }

                public void Remove(Node x) {
                    x.prev.next = x.next;
                    x.next.prev = x.prev;
                    size--;
                }

                public Node RemoveFirst() {
                    if (head.next == tail) {
                        return null;
                    }
                    Node first = head.next;
                    Remove(first);
                    return first;
                }

                public int Size() {
                    return size;
                }
            }
            // 最近最少使用
            // public static LRU
        }

        static void Main(string[] args) {
            List<int[]> res = DynamicProgram.Permute(new int[] { 1, 2, 3, 4 });
            System.Console.WriteLine(res);
        }
    }
}