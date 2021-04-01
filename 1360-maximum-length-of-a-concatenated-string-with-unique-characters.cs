public class Solution {
    public int MaxLength(IList<string> arr) {
                int res = 0;
                var path = new List<string>();

                bool Check() {
                    var mask = new int[26];
                    foreach (var str in path) {
                        foreach (var ch in str) {
                            if (mask[ch - 'a'] == 1) {
                                return false;
                            }
                            ++mask[ch - 'a'];
                        }
                    }
                    return true;
                }

                void Helper(int idx) {
                    var pathStr = string.Join("", path);
                    if (Check()) {
                        res = Math.Max(res, pathStr.Length);
                    }
                    for (int i = idx; i < arr.Count; ++i) {
                        path.Add(arr[i]);
                        Helper(i + 1);
                        path.RemoveAt(path.Count - 1);
                    }
                }
                Helper(0);
                return res;
    }
}