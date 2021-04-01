public class Solution {
    public int[] NumsSameConsecDiff(int n, int k) {
                // BFS，第一层个数为1，第二层个数为2，依次类推
                var res = new HashSet<int>();
                int depth = 0;
                var queue = new Queue<List<int>>();
                for (int i = 1; i <= 9; i++) {
                    queue.Enqueue(new List<int> { i });
                }
                while (queue.Count != 0) {
                    int count = queue.Count;
                    depth++;
                    if (depth == n) {
                        for (int i = 0; i < count; i++) {
                            res.Add(int.Parse(string.Join("", queue.Dequeue())));
                        }
                    } else {
                        for (int i = 0; i < count; i++) {
                            var num = queue.Dequeue();
                            var tail = num.Last();
                            if (tail - k >= 0) {
                                var tmp = new List<int>(num);
                                tmp.Add(tail - k);
                                queue.Enqueue(tmp);
                            }
                            if (tail + k <= 9) {
                                var tmp = new List<int>(num);
                                tmp.Add(tail + k);
                                queue.Enqueue(tmp);
                            }
                        }
                    }

                }
                return res.ToArray();
    }
}