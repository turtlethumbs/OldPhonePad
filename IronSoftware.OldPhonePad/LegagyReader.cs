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
    }
}
