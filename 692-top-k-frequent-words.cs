public class Solution {
                class MaxHeapComparer : IComparer {
                public int Compare(object item1, object item2) {
                    var x1 = (KeyValuePair<string, int>) item1;
                    var x2 = (KeyValuePair<string, int>) item2;
                    // 对比较器的理解，本来的顺序是x，y；如果保持这个顺序就返回-1，交换顺序就返回1，什么都不做就返回0；
                    return x1.Value == x2.Value ? x1.Key.CompareTo(x2.Key) : x1.Value >= x2.Value ? -1 : 1;
                }
            }
    public IList<string> TopKFrequent(string[] words, int k) {
                var countDict = words.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                var heap = new SortedList(new MaxHeapComparer());
                foreach (var item in countDict) {
                    heap.Add(item, 0);
                    if (heap.Count > k) {
                        heap.RemoveAt(heap.Count - 1);
                    }
                }
                var res = new List<string>();
                foreach (var item in heap.GetKeyList()) {
                    var tmp = (KeyValuePair<string, int>) item;
                    res.Add(tmp.Key);
                }
                return res;
    }
}