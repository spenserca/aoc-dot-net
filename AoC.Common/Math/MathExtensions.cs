namespace AoC.Common.Math;

public static class MathExtensions
{
    public static long LeastCommonMultiple(this IEnumerable<long> values) =>
        values.Aggregate(LeastCommonMultiple);

    private static long GreatestCommonFactor(long a, long b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    private static long LeastCommonMultiple(long a, long b)
    {
        return a / GreatestCommonFactor(a, b) * b;
    }
}
