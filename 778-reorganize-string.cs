using System;

public class Solution {
    public string ReorganizeString(string S) {
        // 出现次数最多的字母有没有超过一半
        var mid = (S.Length + 1) / 2;
        // 计数
        var dict = S.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .ToDictionary(x => x.Key, x => x.Count());

        if (dict.Values.All(x => x <= mid)) {
            var arr = new char[S.Length];
            Action<int> action = i => {
                var key = dict.Keys.First();
                arr[i] = key;
                dict[key]--;
                if (dict[key] <= 0) dict.Remove(key);
            };
            Func<int, int, int> a = (x, y) => {
                return 0;
            };
            // 交替生成
            for (var i = 0; i < arr.Length; i += 2) action(i);
            for (var i = 1; i < arr.Length; i += 2) action(i);

            return new string(arr);
        }

        return "";
    }
}