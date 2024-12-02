public static class StringExtensions
{
    public static bool TryParseToLong(this string input, out long result)
        => long.TryParse(input, out result);
}