using System.Data;

namespace IronSoftware.OldPhonePad
{
    public class LegacyReader
    {
        private static string legalChars = " 0123456789*#";

        public static String OldPhonePad(string input)
        {
            LegacyReader.ValidateInputIsNotEmpty(input);
            LegacyReader.ValidateInputHasLegalCharsOnly(input);
            LegacyReader.ValidateInputHasPoundSymbolAsFinalChar(input);
            foreach (char c in input)
            {
                Console.WriteLine("test");
            }
            return "";
        }

        private static void ValidateInputIsNotEmpty(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be empty", nameof(input));
            }
        }

        private static void ValidateInputHasLegalCharsOnly(string input)
        {
            foreach (char c in input)
            {
                if (!legalChars.Contains(c))
                {
                    throw new ArgumentException("Input cannot be processed due to illegal char '" + c + "'", nameof(input));
                }
            }
        }

        private static void ValidateInputHasPoundSymbolAsFinalChar(string input)
        {
            char poundSymbol = '#';
            int poundSymbolCount = input.Count(c => c == poundSymbol);
            if (poundSymbolCount >= 2)
                throw new ArgumentException("Input cannot be processed due to existence of multiple '#' symbol chars", nameof(input));
            if (poundSymbolCount == 0)
                throw new ArgumentException("Input cannot be processed due to '#' symbol char not found", nameof(input));
            if (input.IndexOf(poundSymbol) != input.Length - 1)
                throw new ArgumentException("Input cannot be processed due to '#' symbol char not properly placed at end of input", nameof(input));
        }
    }
}
