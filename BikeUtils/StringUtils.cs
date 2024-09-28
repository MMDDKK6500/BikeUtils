namespace BikeUtils;

public static class StringUtils
{
    /// <summary>
    /// Generate Automatically generates line breaks for lazy peoples.
    /// </summary>
    /// <param name="quantity">It's the number of line breaks it will generate.</param>
    /// <returns>Returns a string with the number of line breaks supplied.</returns>
    public static string GenerateLineBreak(int quantity) {
        string linebreak = "";
        for (int i = 0; i < quantity; i++) {
            linebreak += "\n";
        }
        return linebreak;
    }
}
