using IronSoftware.OldPhonePad;

try
{
    string output = LegacyReader.OldPhonePad("");
    Console.WriteLine(output);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}