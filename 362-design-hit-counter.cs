public class HitCounter {

                Queue<int[]> queue;
                int count;
                public HitCounter() {
                    queue = new Queue<int[]>();
                    count = 0;
                }

                public void Hit(int timestamp) {
                    if (queue.Count != 0 && queue.First()[0] == timestamp) {
                        queue.First()[1]++;
                    } else {
                        queue.Enqueue(new[] { timestamp, 1 });
                    }
                    ++count;
                }

                public int GetHits(int timestamp) {
                    while(queue.Count != 0 && timestamp - queue.First()[0] >= 300){
                        count -= queue.First()[1];
                        queue.Dequeue();
                    }
                    return count;
                }
}

/**
 * Your HitCounter object will be instantiated and called as such:
 * HitCounter obj = new HitCounter();
 * obj.Hit(timestamp);
 * int param_2 = obj.GetHits(timestamp);
 */