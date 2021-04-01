public class Solution {
    public IList<string> RemoveComments(string[] source) {
bool inBlock = false;
                var newline = new StringBuilder();
                var res = new List<string>();
                foreach (var line in source) {
                    int i = 0;
                    if (!inBlock) newline = new StringBuilder();
                    while (i < line.Length) {
                        if (!inBlock && i + 1 < line.Length && line[i] == '/' && line[i + 1] == '*') {
                            inBlock = true;
                            i++;
                        } else if (inBlock && i + 1 < line.Length && line[i] == '*' && line[i + 1] == '/') {
                            inBlock = false;
                            i++;
                        } else if (!inBlock && i + 1 < line.Length && line[i] == '/' && line[i + 1] == '/') {
                            break;
                        } else if (!inBlock) {
                            newline.Append(line[i]);
                        }
                        i++;
                    }
                    if (!inBlock && newline.Length > 0) {
                        res.Add(newline.ToString());
                    }
                }
                return res;
    }
}