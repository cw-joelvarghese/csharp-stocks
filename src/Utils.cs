using csharp_stocks.Models;

public static class Utils {
    public static string TrimEnd(this string source, string value)
    {
        if (!source.EndsWith(value))
            return source;

        return source.Remove(source.LastIndexOf(value));
    }

    public static string FormatNumber(int number)
    {
        // Return number as is if it's less than 1 lakh
        if (number < 100000)
        {
            return number.ToString("N0"); // Format with thousand separators
        }
        // Convert to Lakhs if less than 1 crore
        else if (number < 10000000)
        {
            double lakhs = number / 100000.0;
            return $"{lakhs:0.##} Lakhs";
        }
        // Convert to Crore if greater than or equal to 1 crore
        else
        {
            double crores = number / 10000000.0;
            return $"{crores:0.##} Crore";
        }
    }

    public static bool IsValueForMoney(Stock stock) {
        return stock.Price <= 200000 && stock.Km < 10000;
    }
}