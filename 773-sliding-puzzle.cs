using System.Collections.Generic;
using System.Text;

public class Solution {
    public int SlidingPuzzle(int[][] board) {
        var neighbors = new int[6][]
            {new[] {1, 3}, new[] {0, 2, 4}, new[] {1, 5}, new[] {0, 4}, new[] {1, 3, 5}, new[] {2, 4}};

        var sb = new StringBuilder();
        for (var i = 0; i < 2; i++) {
            for (var j = 0; j < 3; j++) {
                sb.Append(board[i][j]);
            }
        }

        List<string> Get(string status) {
            var res = new List<string>();
            var array = status.ToCharArray();
            var x = status.IndexOf('0');
            foreach (var y in neighbors[x]) {
                Swap(array, x, y);
                res.Add(new string(array));
                Swap(array, x, y);
            }

            return res;
        }

        void Swap(char[] array, int x, int y) {
            var temp = array[x];
            array[x] = array[y];
            array[y] = temp;
        }

        var initial = sb.ToString();
        if (initial == "123450") return 0;
        var step = 0;
        var queue = new Queue<string>();
        var vis = new HashSet<string> {initial};
        queue.Enqueue(initial);

        while (queue.Count != 0) {
            ++step;
            var count = queue.Count;
            for (var i = 0; i < count; ++i) {
                var status = queue.Dequeue();
                foreach (var next in Get(status)) {
                    if (!vis.Contains(next)) {
                        if (next == "123450") {
                            return step;
                        }

                        queue.Enqueue(next);
                        vis.Add(next);
                    }
                }
            }
        }

        return -1;
    }
}