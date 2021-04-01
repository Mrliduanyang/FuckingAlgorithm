public class Solution {
public int VideoStitching(int[][] clips, int T) {
        var max = 0;
        var last = -1;
        var counter = 0;

        for (; max < T; counter++)
        {
            var choose = clips.Where(x => x[0] > last && x[0] <= max).ToList();
            if (choose.Any())
            {
                last = max;
                max = choose.Max(x => x[1]); 
                if (max > last) continue;
            }
            return -1;
        }

        return counter;
    }

}