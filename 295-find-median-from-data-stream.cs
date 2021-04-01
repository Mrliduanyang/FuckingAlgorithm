public class MedianFinder {
class MinHeapComparer : IComparer {
                    public int Compare(object item1, object item2) {
                        var x1 = (int) item1;
                        var x2 = (int) item2;
                        return x1 <= x2 ? -1 : 1;
                    }
                }

                class MaxHeapComparer : IComparer {
                    public int Compare(object item1, object item2) {
                        var x1 = (int) item1;
                        var x2 = (int) item2;
                        return x1 >= x2 ? -1 : 1;
                    }
                }

                SortedList min;
                SortedList max;
                public MedianFinder() {
                    max = new SortedList(new MinHeapComparer()); // 存大的
                    min = new SortedList(new MaxHeapComparer()); // 存小的
                }

                public void AddNum(int num) {
                    // 不能保证num一定在min中，所以需要调整两次，保证num被插入到正确的堆中
                    min.Add(num, 0);
                    max.Add(min.GetKey(0), 0);
                    min.RemoveAt(0);
                    if (min.Count < max.Count) {
                        min.Add(max.GetKey(0), 0);
                        max.RemoveAt(0);
                    }
                }

                public double FindMedian() {
                return min.Count > max.Count ? (int) min.GetKey(0) : ((int) min.GetKey(0) + (int) max.GetKey(0)) * 0.5;

                }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */