using IronSoftware.OldPhonePad;

try
{
    string exampleInput = "11184426655111011199966688111#";
    string output = LegacyReader.OldPhonePad(exampleInput);
    Console.WriteLine(output);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}