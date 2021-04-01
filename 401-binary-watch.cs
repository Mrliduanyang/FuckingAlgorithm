public class Solution {
    public IList<string> ReadBinaryWatch(int num) {
        List<string> res = new List<string>();
        int[] data = {1, 2, 4, 8, 1, 2, 4, 8, 16, 32};

        void FindHour(int idx, int n, int hour, int minute) {
            if (hour > 11 || minute > 59) return;

            if (n == 0) {
                var m = $"{minute}".PadLeft(2, '0');
                res.Add($"{hour}:{m}");
                return;
            }

            if (hour > 11 || minute > 59) return;

            if (n == 0) {
                var m = $"{minute}".PadLeft(2, '0');
                res.Add($"{hour}:{m}");
            }
            else if (n > 0) {
                for (var i = idx; i < data.Length; i++) {
                    if (i < 4)
                        hour += data[i];
                    else
                        minute += data[i];
                    FindHour(i + 1, n - 1, hour, minute);
                    if (i < 4)
                        hour -= data[i];
                    else
                        minute -= data[i];
                }
            }
        }

        FindHour(0, num, 0, 0);
        return res;
    }
}