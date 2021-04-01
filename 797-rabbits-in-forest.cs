public class Solution {
    public int NumRabbits(int[] answers) {
                int res = 0;
                var dict = new Dictionary<int, int>();
                foreach (var answer in answers) {
                    if (answer == 0) {
                        res += 1;
                    } else {
                        // 如果dict不存在answer，说明第一次出现，res+answer+1
                        if (!dict.ContainsKey(answer)) {
                            dict[answer] = answer;
                            res += (answer + 1);
                        } else {
                            dict[answer]--;
                            if (dict[answer] == 0) {
                                dict.Remove(answer);
                            }
                        }
                    }
                }
                return res;
    }
}