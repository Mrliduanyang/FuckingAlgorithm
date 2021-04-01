public class Solution {
    public string OriginalDigits(string s) {
                char[] count = new char[26 + (int)
                    'a'];
                foreach (var letter in s.ToCharArray()) {
                    count[letter]++;
                }

                int[] nums = new int[10];
                nums[0] = count['z'];
                nums[2] = count['w'];
                nums[4] = count['u'];
                nums[6] = count['x'];
                nums[8] = count['g'];
                nums[3] = count['h'] - nums[8];
                nums[5] = count['f'] - nums[4];
                nums[7] = count['s'] - nums[6];
                nums[9] = count['i'] - nums[5] - nums[6] - nums[8];
                nums[1] = count['n'] - nums[7] - 2 * nums[9];

                StringBuilder output = new StringBuilder();
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < nums [i]; j++)
                        output.Append(i);
                return output.ToString();
    }
}