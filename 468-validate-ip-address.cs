public class Solution {
    public string ValidIPAddress(string IP) {
        string ValidateIPv4(string IP) {
            var nums = IP.Split(".");
            foreach (var num in nums) {
                if (num.Length == 0 || num.Length > 3) return "Neither";
                if (num[0] == '0' && num.Length != 1) return "Neither";
                foreach (var ch in num)
                    if (!char.IsDigit(ch))
                        return "Neither";
                if (int.Parse(num) > 255) return "Neither";
            }

            return "IPv4";
        }

        string ValidateIPv6(String IP) {
            var nums = IP.Split(":");
            var hexdigits = "0123456789abcdefABCDEF";
            foreach (var num in nums) {
                if (num.Length == 0 || num.Length > 4) return "Neither";
                foreach (var ch in num)
                    if (hexdigits.IndexOf(ch) == -1)
                        return "Neither";
            }

            return "IPv6";
        }

        if (IP.Where(ch => ch == '.').Count() == 3)
            return ValidateIPv4(IP);
        if (IP.Where(ch => ch == ':').Count() == 7)
            return ValidateIPv6(IP);
        return "Neither";
    }
}