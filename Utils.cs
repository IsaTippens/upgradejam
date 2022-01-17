namespace upgradejam;


public static class RNG
{
    public static Random Random = new Random();
    public static int Next(int min, int max)
    {
        return Random.Next(min, max);
    }

    public static float Next(float min, float max)
    {
        return (float)Random.NextDouble() * (max - min) + min;
    }

    public static float Next()
    {
        return (float)Random.NextDouble();
    }
}