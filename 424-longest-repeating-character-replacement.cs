public class Solution {
public int CharacterReplacement(string s, int k)
        {
            //存放窗口内各大写字母出现的最大次数
            var t = new int[26];
            //左右指针
            int left = 0, right = 0;
            //窗口内出现过的字母最大重复次数
            int maxlen = 0;
            //左指针不变，右指针右移时，窗口扩展
            while (right < s.Length)
            {
                //右指针所在字母的出现次数加一
                t[s[right] - 'A']++;
                //更新字母最大重复次数
                maxlen = Math.Max(maxlen, t[s[right] - 'A']);
                //右指针右移指向下一个字母，方便计算窗口长度
                right++;
                //扩展后的窗口长度大于字母最大重复次数加允许更改次数
                if (right - left > maxlen + k)
                {
                    //扩展后的窗口过大不满足要求，需要窗口滑动
                    //左指针所指的字母将离开窗口，出现次数减一
                    t[s[left] - 'A']--;
                    //窗口不能扩展，左指针右移，窗口滑动
                    left++;
                }
            }
            //窗口移动到最后，返回长度
            return right - left;
        }

}