public class Solution {
                class KSmallComparer : IComparer {
                public int Compare(object x, object y) {
                    var x1 = (long) x;
                    var y1 = (long) y;
                    return x1 < y1 ? -1 : 1;
                }
            }
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k) {
                var heap = new SortedList(new KSmallComparer());
                foreach (var num1 in nums1) {
                    foreach (var num2 in nums2) {
                        long sum = num1 + num2;
                        heap.Add(sum, new List<int> { num1, num2 });
                        if (heap.Count > k) {
                            heap.RemoveAt(heap.Count - 1);
                        }
                    }
                }
                var res = new List<IList<int>>();
                foreach (var item in heap.GetValueList()) {
                    res.Add((IList<int>) item);
                }
                return res;
    }
}