public class Solution {
    public string DigitSum(string s, int k) {
        while (s.Length > k) {
            string tmp = "";  // The string after each round
            int n = s.Length;
            for (int i = 0; i < n; i += k) {
                int val = 0;
                for (int j = i; j < Math.Min(i + k, n); ++j) {
                    val += s[j] - '0';
                }
                tmp += val.ToString();
            }
            s = tmp;
        }
        return s;
    }
}