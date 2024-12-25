using System.Collections.Generic;
using IronSoftware.OldPhonePad;
using Xunit;

namespace IronSoftware.OldPhonePad.Tests
{
    public class OldPhonePadTests
    {
        [Fact]
        public void LegacyReader_OldPhonePad_ReturnValidOutput()
        {
            Dictionary<string, string> testCases = new Dictionary<string, string>();
            testCases.Add("33#", "E");
            testCases.Add("227*#", "B");
            testCases.Add("4433555 555666#", "HELLO");
            testCases.Add("4433555 555666096667775553#", "HELLO WORLD");
            testCases.Add("8 88777444666*664#", "TURING");
            testCases.Add("62 22212224433 33777733#", "MAC&CHEESE");
            testCases.Add("1177778277711#", "'STAR'");
            testCases.Add("11*77778277711#", "STAR'");
            testCases.Add("11184426655111011199966688111#", "(THANK) (YOU)");
            testCases.Add("111*84426655111011199966688111#", "THANK( )YOU(");
            testCases.Add("***#", "");
            testCases.Add("62 2221*0*2224433 33777733*#", "MACCHEES");
            List<string> expectResult = new List<string>();
            foreach (var input in testCases) expectResult.Add(input.Value);
            List<string> actualResult = new List<string>();

            foreach (var input in testCases) actualResult.Add(LegacyReader.OldPhonePad(input.Key));

            Assert.Equal(expectResult, actualResult);
        }

        [Fact]
        public void LegacyReader_OldPhonePad_ReturnExceptionDueToEmptyInput()
        {
            string input = ""; // empty input
            string expectResult = "Input cannot be empty (Parameter 'input')";

            var exception = Assert.Throws<ArgumentException>(() => LegacyReader.OldPhonePad(input));

            Assert.Equal(expectResult, exception.Message);
        }

        [Fact]
        public void LegacyReader_OldPhonePad_ReturnExceptionDueToInvalidCharInputted()
        {
            string input = " 1234567890*#$";
            string expectResult = "Input cannot be processed due to illegal char '$' (Parameter 'input')";

            var exception = Assert.Throws<ArgumentException>(() => LegacyReader.OldPhonePad(input));

            Assert.Equal(expectResult, exception.Message);
        }

        [Fact]
        public void LegacyReader_OldPhonePad_ReturnExceptionDueToMultiplePoundSymbols()
        {
            string input = " 1234567890*#1#";
            string expectResult = "Input cannot be processed due to existence of multiple '#' symbol chars (Parameter 'input')";

            var exception = Assert.Throws<ArgumentException>(() => LegacyReader.OldPhonePad(input));

            Assert.Equal(expectResult, exception.Message);
        }

        [Fact]
        public void LegacyReader_OldPhonePad_ReturnExceptionDueToPoundSymbolCharNotFound()
        {
            string input = " 1234567890*";
            string expectResult = "Input cannot be processed due to '#' symbol char not found (Parameter 'input')";

            var exception = Assert.Throws<ArgumentException>(() => LegacyReader.OldPhonePad(input));

            Assert.Equal(expectResult, exception.Message);
        }

        [Fact]
        public void LegacyReader_OldPhonePad_ReturnExceptionDueToMissingTrailingPoundSymbol()
        {
            string input = " 1234567890*#1";
            string expectResult = "Input cannot be processed due to '#' symbol char not properly placed at end of input (Parameter 'input')";

            var exception = Assert.Throws<ArgumentException>(() => LegacyReader.OldPhonePad(input));

            Assert.Equal(expectResult, exception.Message);
        }
    }
}