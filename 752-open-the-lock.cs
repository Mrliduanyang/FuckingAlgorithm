using System.Collections.Generic;

public class Solution {
    public int OpenLock(string[] deadends, string target) {
        char NumPrev(char x) {
            return x == '0' ? '9' : (char) (x - 1);
        }

        char NumSucc(char x) {
            return x == '9' ? '0' : (char) (x + 1);
        }

        List<string> Get(string status) {
            var res = new List<string>();
            var array = status.ToCharArray();
            for (var i = 0; i < 4; ++i) {
                var num = array[i];
                array[i] = NumPrev(num);
                res.Add(new string(array));
                array[i] = NumSucc(num);
                res.Add(new string(array));
                array[i] = num;
            }

            return res;
        }

        if (target == "0000") return 0;
        var dead = new HashSet<string>(deadends);
        if (dead.Contains("0000")) return -1;
        var step = 0;
        var queue = new Queue<string>();
        queue.Enqueue("0000");
        var vis = new HashSet<string>();
        vis.Add("0000");
        while (queue.Count != 0) {
            ++step;
            var count = queue.Count;
            for (var i = 0; i < count; ++i) {
                var cur = queue.Dequeue();
                foreach (var next in Get(cur)) {
                    if (!vis.Contains(next) && !dead.Contains(next)) {
                        if (next == target) {
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