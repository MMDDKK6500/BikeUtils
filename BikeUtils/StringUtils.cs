namespace BikeUtils;

using Exiled.API.Features;
using System.Text;

/// <summary>
/// A class containing utilities for strings.
/// </summary>
public static class StringUtils
{
    /// <summary>
    /// A enum containing the types of modifications that can be applied to a string.
    /// </summary>
    public enum StrModiType
    {
        /// <summary>
        /// Type to align the string.
        /// </summary>
        Align,
        /// <summary>
        /// Type to change the string's position.
        /// </summary>
        Pos,
        /// <summary>
        /// Type to change the vertical offset of the string.
        /// </summary>
        Voffset,
        /// <summary>
        /// Type to change the position and voffset.
        /// </summary>
        PosVoffset,
        /// <summary>
        /// Type to change position and align the text.
        /// </summary>
        PosAlign,
        /// <summary>
        /// Type to change the voffset and alignment.
        /// </summary>
        VoffsetAlign,
        /// <summary>
        /// Type to change all modifiers.
        /// </summary>
        PosVoffsetAlign
    }

    /// <summary>
    /// Generate Automatically generates line breaks for lazy people.
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

    /// <summary>
    /// Makes it easy to modify text with multiple lines.
    /// </summary>
    /// <param name="text">It's the text that's going to be changed.</param>
    /// <param name="modify">The type of change that will be made to the text. Using <see cref="StrModiType"/> to choose the type of modification.</param>
    /// <param name="quant">Defines the amount of change to be made to the text.</param>
    /// <returns>Returns the text with the changes applied.</returns>
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

    /// <summary>
    /// Makes it easy to modify text with multiple lines.
    /// </summary>
    /// <param name="text">It's the text that's going to be changed.</param>
    /// <param name="modify">The type of change that will be made to the text. Using <see cref="StrModiType"/> to choose the type of modification.</param>
    /// <param name="quant1">Defines the quantity that will be applied to the Pos.</param>
    /// <param name="quant2">Defines the amount that will be applied to Vofsset.</param>
    /// <param name="direction">Defines the direction of the alignment.</param>
    /// <returns>Returns the text with the changes applied.</returns>
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

    /// <summary>
    /// Makes it easy to modify text with multiple lines.
    /// </summary>
    /// <param name="text">It's the text that's going to be changed.</param>
    /// <param name="modify">The type of change that will be made to the text. Using <see cref="StrModiType"/> to choose the type of modification.</param>
    /// <param name="quant">Defines the amount of change to be made to the text.</param>
    /// <param name="direction">Defines the direction of the alignment.</param>
    /// <returns>Returns the text with the changes applied.</returns>
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

    /// <summary>
    /// Makes it easy to modify text with multiple lines.
    /// </summary>
    /// <param name="text">It's the text that's going to be changed.</param>
    /// <param name="modify">The type of change that will be made to the text. Using <see cref="StrModiType"/> to choose the type of modification.</param>
    /// <param name="direction">Defines the direction of the alignment.</param>
    /// <returns>Returns the text with the changes applied.</returns>
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
