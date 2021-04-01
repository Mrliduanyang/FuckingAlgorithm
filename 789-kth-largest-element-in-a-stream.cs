            public class KthLargest {

                class KthLargestComparer : IComparer {
                    public int Compare(object item1, object item2) {
                        var x1 = (int) item1;
                        var x2 = (int) item2;
                        // 对比较器的理解，本来的顺序是x，y；如果保持这个顺序就返回-1，交换顺序就返回1，什么都不做就返回0；
                        return x1 <= x2 ? -1 : 1;
                    }
                }

                SortedList heap;
                int k;
                public KthLargest(int k, int[] nums) {
                    this.k = k;
                    heap = new SortedList(new KthLargestComparer());
                    foreach (var num in nums) {
                        this.Add(num);
                    }
                }
                public int Add(int val) {
                    heap.Add(val, val);
                    if (heap.Count > k) {
                        heap.RemoveAt(0);
                    }
                    return (int) (heap.GetKeyList()) [0];
                }
            }