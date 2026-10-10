public class Solution {
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2) {
        long k = (long)k1 + k2;
        int n = nums1.Length;

        long sum = 0;
        for (int i = 0; i < n; i++) {
            nums1[i] = Math.Abs(nums1[i] - nums2[i]);
            sum += nums1[i];
        }
        if (sum <= k) {
            return 0;
        }

        Array.Sort(nums1);
        Array.Reverse(nums1);
        Array.Resize(ref nums1, n + 1);

        for (int i = 1; i <= n; i++) {
            long cost = (long)(nums1[i - 1] - nums1[i]) * i;
            if (cost > k) {
                long q = k / i, r = k % i, hi = nums1[i - 1] - q;
                long ans = hi * hi * (i - r) + (hi - 1) * (hi - 1) * r;
                for (int j = i; j < n; j++) {
                    ans += (long)nums1[j] * nums1[j];
                }
                return ans;
            }
            k -= cost;
        }
        return 0;
    }
}