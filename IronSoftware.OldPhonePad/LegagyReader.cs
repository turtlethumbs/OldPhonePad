using System.Data;

namespace IronSoftware.OldPhonePad
{
    public class LegacyReader
    {
        public static String OldPhonePad(string input)
        {
            LegacyReader.ValidateInputIsNotEmpty(input);
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
    }
}
