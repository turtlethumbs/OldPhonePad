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
            string transformedString = "";
            Dictionary<char, string> mapping = CreateKeypadMapping();
            int counter = -1;
            int maxCount = counter;
            const char PAUSE_CHAR = ' ';
            const char ERASE_CHAR = '*';
            char nextChar = input[0];
            char prevChar = nextChar;
            foreach (char c in input)
            {
                nextChar = c;
                if (nextChar != prevChar)
                {
                    counter = 0;
                    transformedString += (prevChar != PAUSE_CHAR && prevChar != ERASE_CHAR) ? mapping[prevChar][maxCount] : "";
                    transformedString = LegacyReader.ReplaceParenthesisChar(transformedString);
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
                throw new ArgumentException("Input cannot be processed due to existence of multiple '" + poundSymbol + "' symbol chars", nameof(input));
            if (poundSymbolCount == 0)
                throw new ArgumentException("Input cannot be processed due to '" + poundSymbol + "' symbol char not found", nameof(input));
            if (input.IndexOf(poundSymbol) != input.Length - 1)
                throw new ArgumentException("Input cannot be processed due to '" + poundSymbol + "' symbol char not properly placed at end of input", nameof(input));
        }
    }
}
