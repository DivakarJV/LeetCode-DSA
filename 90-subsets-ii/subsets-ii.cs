public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        Array.Sort(nums);
        Solve(0, nums, [], result);
        return result;
    }

    public void Solve(int start, int[] nums, List<int> subset, IList<IList<int>> result)
    {
        if (start == nums.Length)
        {
            result.Add([..subset]);
            return;
        }
                
        var currentNumber = nums[start];
        var i = start + 1;
        for (; i < nums.Length; i++)
        {
            if (nums[i] != currentNumber)
            {
                break;
            }
        }
        int nextStart = i;
        var cnt = nextStart - start;
        Solve(nextStart, nums, subset, result);
        for (var j = 0; j < cnt; j++)
        {
            subset.Add(currentNumber);
            Solve(nextStart, nums, subset, result);
        }
        subset.RemoveRange(subset.Count - cnt, cnt);
    }
}