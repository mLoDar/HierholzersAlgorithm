namespace HierholzersAlgorithm.Scripts
{
    internal class ColorConverter
    {
        internal string ColorToHex(Color colorToConvert)
        {
            string hexValue = $"#{colorToConvert.R:X2}{colorToConvert.G:X2}{colorToConvert.B:X2}";
            return hexValue;
        }

        internal Color HexToColor(string hexValue)
        {
            Color convertedColor = ColorTranslator.FromHtml(hexValue);
            return convertedColor;
        }
    }
}