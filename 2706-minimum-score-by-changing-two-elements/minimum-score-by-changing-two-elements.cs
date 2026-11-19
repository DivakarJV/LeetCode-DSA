public class Solution {
    public int MinimizeSum(int[] nums) {
        int n = nums.Length;
        Array.Sort(nums);
        return Math.Min(nums[n - 1] - nums[2],
                        Math.Min(nums[n - 2] - nums[1], nums[n - 3] - nums[0]));
    }
}