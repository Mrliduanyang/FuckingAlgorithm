public class Solution {
                class StoneComparer : IComparer {
                public int Compare(object x, object y) {
                    var x1 = (int) x;
                    var y1 = (int) y;
                    // 大顶堆比较器，大于返回-1
                    return x1 > y1 ? -1 : 1;

                }
            }
    public int LastStoneWeight(int[] stones) {
                var heap = new SortedList(new StoneComparer());
                foreach (var stone in stones) {
                    heap.Add(stone, stone);
                }
                while (heap.Count > 1) {
                    var fisrt = (int) heap.GetByIndex(0);
                    heap.RemoveAt(0);
                    var second = (int) heap.GetByIndex(0);
                    heap.RemoveAt(0);
                    var residual = fisrt - second;
                    if (residual > 0) {
                        heap.Add(residual, residual);
                    }
                }
                return heap.Count == 0 ? 0 : (int) heap.GetByIndex(0);
    }
}