﻿using System;
using System.Collections.Generic;

public class TimeMap {
    Dictionary<string, IList<Tuple<int, string>>> dictionary;

    public TimeMap() {
        dictionary = new Dictionary<string, IList<Tuple<int, string>>>();
    }

    public void Set(string key, string value, int timestamp) {
        if (dictionary.ContainsKey(key)) {
            dictionary[key].Add(new Tuple<int, string>(timestamp, value));
        }
        else {
            IList<Tuple<int, string>> tuples = new List<Tuple<int, string>>();
            tuples.Add(new Tuple<int, string>(timestamp, value));
            dictionary.Add(key, tuples);
        }
    }

    public string Get(string key, int timestamp) {
        IList<Tuple<int, string>> tuples =
            dictionary.ContainsKey(key) ? dictionary[key] : new List<Tuple<int, string>>();
        // 使用一个大于所有 value 的字符串，以确保在 pairs 中含有 timestamp 的情况下也返回大于 timestamp 的位置
        Tuple<int, string> tuple = new Tuple<int, string>(timestamp, ((char) 127).ToString());
        int i = BinarySearch(tuples, tuple);
        if (i > 0) {
            return tuples[i - 1].Item2;
        }

        return "";
    }

    private int BinarySearch(IList<Tuple<int, string>> tuples, Tuple<int, string> target) {
        int low = 0, high = tuples.Count - 1;
        if (high < 0 || Compare(tuples[high], target) <= 0) {
            return high + 1;
        }

        while (low < high) {
            int mid = (high - low) / 2 + low;
            Tuple<int, string> tuple = tuples[mid];
            if (Compare(tuple, target) <= 0) {
                low = mid + 1;
            }
            else {
                high = mid;
            }
        }

        return low;
    }

    private int Compare(Tuple<int, string> tuple1, Tuple<int, string> tuple2) {
        if (tuple1.Item1 != tuple2.Item1) {
            return tuple1.Item1 - tuple2.Item1;
        }
        else {
            return string.CompareOrdinal(tuple1.Item2, tuple2.Item2);
        }
    }
}