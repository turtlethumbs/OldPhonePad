using System.Data;

namespace IronSoftware.OldPhonePad
{
    /// <summary>
    /// A Legacy Reader class.
    /// </summary>
    /// <remarks>
    /// This class exposes the public static method OldPhonePad used to process old phone data input strings.
    /// </remarks>
    public class LegacyReader
    {
        private static String LEGAL_INPUT_CHARS = " 0123456789*#";

        /// <summary>
        /// Accepts a single input param as a pre-formatted old phone pad data string.
        /// </summary>
        /// <param name="input">A pre-formatted data value ending with an '#' as a String.</param>
        /// <returns>Old phone pad data transformed into UPPERCASE ASCII text as a String.</returns>
        public static String OldPhonePad(string input)
        {
            ValidateInputIsNotEmpty(input);
            ValidateInputHasLegalCharsOnly(input);
            ValidateInputHasPoundSymbolAsFinalChar(input);
            Dictionary<char, string> mapping = CreateKeypadMapping();
            int counter = -1;
            int maxCount = counter;
            const char PAUSE_CHAR = ' ';
            const char ERASE_CHAR = '*';
            char nextChar = input[0];
            char prevChar = nextChar;
            string transformedString = "";
            foreach (char c in input)
            {
                nextChar = c;
                if (nextChar != prevChar)
                {
                    counter = 0;
                    transformedString += (prevChar != PAUSE_CHAR && prevChar != ERASE_CHAR) ? mapping[prevChar][maxCount] : "";
                    transformedString = ReplaceParenthesisChar(transformedString);
                    maxCount = counter;
                    if (nextChar == PAUSE_CHAR)
                    {
                        prevChar = nextChar;
                        continue;
                    }
                    if (nextChar == '#') break;
                } else {
                    maxCount = ++counter;
                }
                if (nextChar == ERASE_CHAR && transformedString.Length > 0)
                    transformedString = transformedString.Substring(0, transformedString.Length - 1);
                prevChar = nextChar;
            }
            return transformedString;
        }

        private static void ValidateInputIsNotEmpty(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be empty", nameof(input));
        }

        private static void ValidateInputHasLegalCharsOnly(string input)
        {
            foreach (char c in input)
                if (!LEGAL_INPUT_CHARS.Contains(c))
                    throw new ArgumentException("Input cannot be processed due to illegal char '" + c + "'", nameof(input));
        }

        private static void ValidateInputHasPoundSymbolAsFinalChar(string input)
        {
            char poundSymbol = '#';
            int poundSymbolCount = input.Count(c => c == poundSymbol);
            if (poundSymbolCount >= 2)
                throw new ArgumentException("Input cannot be processed due to existence of multiple '" + poundSymbol + "' symbol chars", nameof(input));
            if (poundSymbolCount == 0)
                throw new ArgumentException("Input cannot be processed due to '" + poundSymbol + "' symbol char not found", nameof(input));
            if (input.IndexOf(poundSymbol) != input.Length - 1)
                throw new ArgumentException("Input cannot be processed due to '" + poundSymbol + "' symbol char not properly placed at end of input", nameof(input));
        }

        private static Dictionary<char, string> CreateKeypadMapping()
        {
            Dictionary<char, string> mapping = new Dictionary<char, string>();
            mapping.Add('1', "&'(");
            mapping.Add('2', "ABC");
            mapping.Add('3', "DEF");
            mapping.Add('4', "GHI");
            mapping.Add('5', "JKL");
            mapping.Add('6', "MNO");
            mapping.Add('7', "PQRS");
            mapping.Add('8', "TUV");
            mapping.Add('9', "WXYZ");
            mapping.Add('0', " ");
            return mapping;
        }

        private static string ReplaceParenthesisChar(string transformedString)
        {
            if (transformedString.Length <= 0) return transformedString;
            char lastChar = transformedString[transformedString.Length - 1];
            const char PARENTHESIS_L = '(';
            const char PARENTHESIS_R = ')';
            if (lastChar != PARENTHESIS_L) return transformedString;
            transformedString = transformedString.Substring(0, transformedString.Length - 1);
            for (int i = transformedString.Length - 1; i >= 0; i--)
            {
                if (transformedString[i] == PARENTHESIS_R)
                {
                    transformedString += PARENTHESIS_L;
                    return transformedString;
                }
                if (transformedString[i] == PARENTHESIS_L)
                {
                    transformedString += PARENTHESIS_R;
                    return transformedString;
                }
            }
            transformedString += PARENTHESIS_L;
            return transformedString;
        }
    }
}
