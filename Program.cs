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

            public static double SuperEggDrop(int k, int n) {
                Dictionary<string, double> memo = new Dictionary<string, double>();
                double dp(int k, int n) {
                    // base如果只有1个鸡蛋，只能线性扫描
                    if (k == 1) {
                        return n;
                    }
                    // 如果是0层，尝试0次
                    if (n == 0) {
                        return 0;
                    }
                    // 备忘录
                    string key = k + "," + n;
                    if (memo.ContainsKey(key)) {
                        return memo[key];
                    }
                    var res = double.PositiveInfinity;
                    // 存在重叠子问题，比如n-i = i-1
                    // 如果在i层没碎，鸡蛋数k不变，搜索楼层变为i+1 - n，如果鸡蛋碎了，k减1，搜索楼层变为1 - i-1。
                    // 也很好理解，如果在i层还没碎，那么还需要多少次能找到楼层就取决于在i层之后的楼层区间内要试验多少次。
                    for (int i = 1; i < n + 1; i++) {
                        res = Math.Min(res, Math.Max(dp(k, n - i), dp(k - 1, i - 1)) + 1);
                    }
                    memo.Add(key, res);
                    return res;
                }
                return dp(k, n);
            }

            public static int SuperEggDrop_1(int k, int n) {
                // dp定义为给定k个鸡蛋，可以尝试扔m次鸡蛋，最坏情况下能确切测试一栋n层的楼
                // base dp[0][..] = 0 dp[..][0] = 0
                // m最大为n，线性扫描
                int[, ] dp = new int[k + 1, n + 1];
                int m = 0;
                while (dp[k, m] < n) {
                    m++;
                    for (int i = 1; i <= k; i++) {
                        // dp[i, m - 1]是楼上的楼层数，鸡蛋没碎，k不变，扔鸡蛋次数m-1，dp[k - 1, m - 1]是楼下楼层数，鸡蛋碎了k-1，扔鸡蛋次数m-1
                        dp[i, m] = dp[i, m - 1] + dp[k - 1, m - 1] + 1;
                    }
                }
                return m;
            }

            public static int Rob_1(int[] nums) {
                int n = nums.Length;
                // dp定义为从第i间房开始抢劫，最多能抢到的钱
                // base dp[n] = 0
                int[] dp = new int[n + 2];
                // 从n-1间房开始
                for (int i = n - 1; i >= 0; i--) {
                    // 
                    dp[i] = Math.Max(dp[i + 1], dp[i + 2] + nums[i]);
                }
                return dp[0];
            }

            public static int Rob_2(int[] nums) {
                int RobRange(int[] nums, int start, int end) {
                    int n = nums.Length;
                    int[] dp = new int[n + 2];
                    for (int i = end; i >= start; i--) {
                        dp[i] = Math.Max(dp[i + 1], dp[i + 2] + nums[i]);
                    }
                    return dp[0];
                }

                int n = nums.Length;
                if (n == 1) {
                    return nums[0];
                }
                return Math.Max(RobRange(nums, 1, n - 1), RobRange(nums, 0, n - 2));
            }

            public static int LongestPalindromeSubseq(string s) {
                int n = s.Length;
                // 涉及两个字符串，用二维dp数组
                // dp定义为在array[i..j]中，最长回文子序列的长度为dp[i][j]
                int[, ] dp = new int[n, n];
                // base如果只有一个字符，最长回文子序列长度为1
                for (int i = 0; i < n; i++) {
                    dp[i, i] = 1;
                }
                // 要求dp[0,n-1]，斜着遍历或者反着遍历
                for (int i = n - 1; i >= 0; i--) {
                    // j比i大
                    for (int j = i + 1; i < n; i++) {
                        if (s[i] == s[j]) {
                            // 如果s[i]和s[j]字符相同，最长回文子序列长度加2
                            dp[i, j] = dp[i + 1, j - 1] + 2;
                        } else {
                            // 反之，将两个字符分别添加上，比较长度
                            dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                        }
                    }
                }
                return dp[0, n - 1];
            }

            public static int IntervalSchedule(int[][] intvs) {
                if (intvs.Length == 0) {
                    return 0;
                }
                // 按结束时间升序排列
                Array.Sort(intvs, (a, b) => a[1].CompareTo(b[1]));
                int count = 1;
                int x_end = intvs[0][1];
                foreach (var item in intvs) {
                    int start = item[0];
                    if (start >= x_end) {
                        count++;
                        x_end = item[1];
                    }
                }
                return count;
            }

            public static int EraseOverlapIntervals(int[][] intvs) {
                int n = intvs.Length;
                return n - IntervalSchedule(intvs);
            }
        }

        class DataStructure {

            class LRU {
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

                class LRUCache {
                    private Dictionary<int, Node> map;
                    private DoubleList cache;
                    private int cap;
                    public LRUCache(int capacity) {
                        cap = capacity;
                        map = new Dictionary<int, Node>();
                        cache = new DoubleList();
                    }
                    // 将key对应node提升为最近使用的，也就是把node从表头删除，插入到表尾
                    private void MakeRecently(int key) {
                        Node x = map[key];
                        cache.Remove(x);
                        cache.AddLast(x);
                    }

                    // 添加最近使用的node，初始化一个node，并插入到表尾，同时在map中添加映射
                    private void AddRecently(int key, int val) {
                        Node x = new Node(key, val);
                        cache.AddLast(x);
                        map.Add(key, x);
                    }

                    // 删除某一个key，从表中删除，从map中删除
                    private void DeleteKey(int key) {
                        Node x = map[key];
                        cache.Remove(x);
                        map.Remove(key);
                    }

                    // 删除最久未使用的，即表头节点
                    private void RemoveLeastRecently() {
                        Node deleteNode = cache.RemoveFirst();
                        int key = deleteNode.key;
                        map.Remove(key);
                    }

                    public int get(int key) {
                        if (!map.ContainsKey(key)) {
                            return -1;
                        }
                        // 如果存在，将该节点提升为最近使用的
                        MakeRecently(key);
                        return map[key].val;
                    }

                    public void put(int key, int val) {
                        // 如果key存在，将key对应的val修改，并提到最近使用
                        if (map.ContainsKey(key)) {
                            map[key].val = val;
                            MakeRecently(key);
                        }
                        // 如果缓存满了，删除掉最近最少使用的元素
                        if (cap == cache.Size()) {
                            RemoveLeastRecently();
                        }
                        // 添加最近使用元素
                        AddRecently(key, val);
                    }
                }
            }
        }

        static void Main(string[] args) {
            int res = DynamicProgram.IntervalSchedule(new int[][] {
                new int[] { 2, 4 },
                    new int[] { 1, 3 },
                    new int[] { 3, 6 }
            });
            System.Console.WriteLine(res);
        }
    }
}