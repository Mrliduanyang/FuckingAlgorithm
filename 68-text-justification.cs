using System;
using System.Collections.Generic;
using System.Text;

public class Solution {
    public IList<string> FullJustify(string[] words, int maxWidth) {
        string Helper(int start, int end, int len) {
            var sb = new StringBuilder();
            if (start == end) {
                sb.Append(words[start]);
                while (sb.ToString().Length < maxWidth) {
                    sb.Append(' ');
                }

                return sb.ToString();
            }
            else {
                var modeN = (maxWidth - len) % (end - start);
                var spaceN = (int) Math.Truncate(1m * (maxWidth - len) / (end - start));
                while (start < end) {
                    sb.Append(words[start]);
                    if (modeN > 0) {
                        sb.Append(' ');
                    }

                    for (var i = 0; i < spaceN; i++) {
                        sb.Append(' ');
                    }

                    start++;
                    modeN--;
                }

                sb.Append(words[end]);
            }

            return sb.ToString();
        }

        var list = new List<string>();
        int start = 0, end = 1, len = words[0].Length;
        while (end < words.Length) {
            if (len + words[end].Length + end - start <= maxWidth) {
                len += words[end].Length;
                end++;
            }
            else {
                list.Add(Helper(start, end - 1, len));
                len = words[end].Length;
                start = end;
                end++;
            }
        }

        var sb = new StringBuilder();
        while (start < words.Length - 1) {
            sb.Append(words[start]).Append(' ');
            start++;
        }

        sb.Append(words[^1]);
        while (sb.ToString().Length < maxWidth) {
            sb.Append(' ');
        }

        list.Add(sb.ToString());
        return list;
    }
}