namespace BikeUtils;

using Exiled.API.Features;
using System.Text;

/// <summary>
/// A class containing utilities for strings.
/// </summary>
public static class StringUtils
{
    public enum StrModiType
    {
        Align,
        Pos,
        Voffset,
        PosVoffset,
        PosAlign,
        VoffsetAlign,
        PosVoffsetAlign
    }

    /// <summary>
    /// Generate Automatically generates line breaks for lazy peoples.
    /// </summary>
    /// <param name="quantity">The number of line breaks it will generate.</param>
    /// <returns>Returns a string with the number of line breaks supplied.</returns>
    public static string GenerateLineBreak(int quantity)
    {
        string linebreak = "";
        for (int i = 0; i < quantity; i++)
        {
            linebreak += "\n";
        }
        return linebreak;
    }

    public static string AdjustString(string text, StrModiType modify, int quant)
    {
        StringBuilder result = new StringBuilder();
        string[] textArray = text.Split('\n');
        string[] modifyString = new string[] { "", "" };

        switch (modify)
        {
            case StrModiType.Pos:
                modifyString[0] = $"<pos={quant}>";
                modifyString[1] = $"</pos>";
                break;
            case StrModiType.Voffset:
                modifyString[0] = $"</voffset>";
                modifyString[1] = $"<voffset={quant}em>";
                break;
        }

        foreach (string str in textArray)
        {
            result.AppendLine(modifyString[0] + str + modifyString[1]);
        }

        return result.ToString();
    }

    public static string AdjustString(string text, StrModiType modify, int quant1, int quant2, string direction = "")
    {
        StringBuilder result = new StringBuilder();
        string[] textArray = text.Split('\n');
        string[] modifyString = new string[] { "", "" };

        switch (modify)
        {
            case StrModiType.PosVoffset:
                modifyString[0] = $"<pos={quant1}></voffset>";
                modifyString[1] = $"</pos><voffset={quant2}em>";
                break;
            case StrModiType.PosVoffsetAlign:
                modifyString[0] = $"<pos={quant1}></voffset><align={direction}>";
                modifyString[1] = $"</pos></align><voffset={quant2}em>";
                break;
        }

        foreach (string str in textArray)
        {
            result.AppendLine(modifyString[0] + str + modifyString[1]);
        }

        return result.ToString();
    }
    public static string AdjustString(string text, StrModiType modify, int quant, string direction)
    {
        StringBuilder result = new StringBuilder();
        string[] textArray = text.Split('\n');
        string[] modifyString = new string[] { "", "" };

        switch (modify)
        {
            case StrModiType.PosAlign:
                modifyString[0] = $"<pos={quant}><align={direction}>";
                modifyString[1] = $"</pos></align>";
                break;
            case StrModiType.VoffsetAlign:
                modifyString[0] = $"<pos={quant}><align={direction}></voffset>";
                modifyString[1] = $"</pos></align><voffset={quant}em>";
                break;
        }

        foreach (string str in textArray)
        {
            result.AppendLine(modifyString[0] + str + modifyString[1]);
        }

        return result.ToString();
    }
    public static string AdjustString(string text, StrModiType modify, string direction)
    {
        StringBuilder result = new StringBuilder();
        string[] textArray = text.Split('\n');
        string[] modifyString = new string[] { "", "" };

        if (modify == StrModiType.Align)
        {
            modifyString[0] = $"<align={direction}>";
            modifyString[1] = $"</align>";
        }

        foreach (string str in textArray)
        {
            result.AppendLine(modifyString[0] + str + modifyString[1]);
        }

        return result.ToString();
    }
}
