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
            List<string> inputList = new List<string>()
            {
                "33#", // E
                "227*#", // B
                "4433555 555666#", // HELLO
                "8 88777444666*664#" // TBD???
            };
            List<string> expectResult = new List<string>()
            {
                "E",
                "B",
                "HELLO",
                "TBD???"
            };
            List<string> actualResult = new List<string>();

            foreach (string input in inputList) actualResult.Add(LegacyReader.OldPhonePad(input));

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