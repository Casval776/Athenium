namespace Athenium.Percentile
{
    public static class MathHelper
    {
        public static double Average(int x, int y)
        {
            var sum = x + y;
            return (double)sum / 2;
        }
    }
}
