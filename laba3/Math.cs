namespace Lab3
{
    public static class Math
    {
        public static bool IsTriangleCanExist(float a, float b, float c)
        {
            return ((a + b > c) && (b + c > a) && (a + c > b));
        }
    }
}
