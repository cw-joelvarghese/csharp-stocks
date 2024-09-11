public static class Utils {
    public static string TrimEnd(this string source, string value)
    {
        if (!source.EndsWith(value))
            return source;

        return source.Remove(source.LastIndexOf(value));
    }
}