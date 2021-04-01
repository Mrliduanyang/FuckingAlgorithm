// public class MovingAverage {

//     /** Initialize your data structure here. */
//     public MovingAverage(int size) {

//     }

//     public double Next(int val) {

//     }
// }

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */
internal class MovingAverage {
    private LinkedList<int> deque = new LinkedList<int>();
    private readonly int size;
    private int windowSum, count;

    public MovingAverage(int size) {
        this.size = size;
    }

    public double Next(int val) {
        ++count;
        deque.AddLast(val);
        int tail;
        if (count > size) {
            tail = deque.First();
            deque.RemoveFirst();
        }
        else {
            tail = 0;
        }

        windowSum = windowSum - tail + val;
        return windowSum * 1.0 / Math.Min(size, count);
    }
}