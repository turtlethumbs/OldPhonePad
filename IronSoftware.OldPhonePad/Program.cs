using IronSoftware.OldPhonePad;

try
{
    string output = LegacyReader.OldPhonePad("11184426655111011199966688111#");
    Console.WriteLine(output);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}