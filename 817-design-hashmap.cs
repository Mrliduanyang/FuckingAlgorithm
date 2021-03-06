public class MyHashMap {
    private List<KeyValuePair> list;

    /**
     * Initialize your data structure here.
     */
    public MyHashMap() {
        list = new List<KeyValuePair>();
    }

    /**
     * value will always be non-negative.
     */
    public void Put(int key, int value) {
        foreach (var kvp in list)
            if (kvp.Key == key) {
                kvp.ChangeValue(value);
                return;
            }

        list.Add(new KeyValuePair(key, value));
    }

    /**
     * Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key
     */
    public int Get(int key) {
        foreach (var kvp in list)
            if (kvp.Key == key)
                return kvp.Value;

        return -1;
    }

    /**
     * Removes the mapping of the specified value key if this map contains a mapping for the key
     */
    public void Remove(int key) {
        foreach (var kvp in list)
            if (kvp.Key == key) {
                list.Remove(kvp);
                return;
            }
    }
}

public class KeyValuePair //kvp类，储存了Key和Value
{
    public KeyValuePair(int key, int value) {
        Key = key;
        Value = value;
    }

    public int Key { get; }

    public int Value { get; private set; }

    public void ChangeValue(int value) {
        Value = value;
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */