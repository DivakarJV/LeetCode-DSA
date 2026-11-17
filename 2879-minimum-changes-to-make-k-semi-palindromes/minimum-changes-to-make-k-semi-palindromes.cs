public class Solution {
    private int SegmentCost(string s, int l, int m, List<int>[] factors) {
        int best = m;
        foreach (int d in factors[m]) {
            int groups = m / d;  // Each group contains groups characters
            int changes = 0;
            for (int offset = 0; offset < d; offset++) {
                for (int t = 0; t < groups / 2;
                     t++) {  // Pair characters from opposite ends of the group
                    if (s[l + offset + t * d] !=
                        s[l + offset + (groups - 1 - t) * d]) {
                        changes++;
                    }
                }
            }
            best = Math.Min(best, changes);
        }
        return best;
    }

    private int Solve(int seg, int start, int n, int[][] cost, int[][] memo) {
        if (seg == 1) {  // Only one segment remains
            return cost[start][n - 1];
        }
        if (memo[seg][start] != -1) {  // Already computed
            return memo[seg][start];
        }
        int best = n;
        int limit =
            n - 1 -
            2 * (seg -
                 1);  // Leave room for seg-1 segments after the first segment
        for (int e = start + 1; e <= limit; e++) {
            best = Math.Min(
                best, cost[start][e] + Solve(seg - 1, e + 1, n, cost, memo));
        }
        memo[seg][start] = best;
        return best;
    }

    public int MinimumChanges(string s, int k) {
        int n = s.Length;
        List<int>[] factors = new List<int>[n + 1];
        for (int i = 0; i <= n; i++) {
            factors[i] = new List<int>();
        }
        // Precompute the proper divisors of each number
        for (int d = 1; d <= n / 2; d++) {
            for (int m = d * 2; m <= n; m += d) {
                factors[m].Add(d);
            }
        }
        int[][] cost = new int [n][];
        for (int i = 0; i < n; i++) {
            cost[i] = new int[n];
        }
        for (int l = 0; l + 1 < n; l++) {
            for (int r = l + 1; r < n;
                 r++) {  // Each substring must have length at least 2
                cost[l][r] = SegmentCost(s, l, r - l + 1, factors);
            }
        }
        int[][] memo = new int [k + 1][];
        for (int seg = 0; seg <= k; seg++) {
            memo[seg] = new int[n];
            Array.Fill(memo[seg], -1);
        }
        return Solve(k, 0, n, cost, memo);
    }
}