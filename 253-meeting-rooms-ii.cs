public class Solution {
            class MinMeetingRoomsComparer : IComparer {
                public int Compare(object item1, object item2) {
                    var x = (int) item1;
                    var y = (int) item2;
                    // 比较器，原顺序-1，交换顺序1，不做0
                    return x <= y ? -1 : 1;
                }
            }
            public int MinMeetingRooms(int[][] intervals) {
                if (intervals.Length == 0) return 0;
                // 按照会议开始时间升序排列，最小堆中记录每个房间的结束之间。这样堆顶房间的结束时间是最小的，当有新的会议到来时，直接选择最早结束的房间即可。
                Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
                var heap = new SortedList(new MinMeetingRoomsComparer());
                heap.Add(intervals[0][1], 0);
                for (int i = 1; i < intervals.Length; i++) {
                    if (intervals[i][0] >= (int) heap.GetKey(0)) {
                        heap.RemoveAt(0);
                    }
                    heap.Add(intervals[i][1], 0);
                }
                return heap.Count;
            }
}