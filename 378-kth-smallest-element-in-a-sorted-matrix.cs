public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        var heap = new SortedList(new KthSmallestComparer(), k);
        foreach (var row in matrix)
        foreach (var num in row) {
            heap.Add(num, num);
            if (heap.Count > k) heap.RemoveAt(k);
        }

        return (int) heap.GetValueList()[k - 1];
    }

    private class KthSmallestComparer : IComparer {
        public int Compare(object x, object y) {
            var x1 = (int) x;
            var y1 = (int) y;
            // 小顶堆比较器，小于返回-1
            return x1 < y1 ? -1 : 1;
        }
    }
}