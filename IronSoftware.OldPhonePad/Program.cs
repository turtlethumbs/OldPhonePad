using IronSoftware.OldPhonePad;

try
{
    string output = LegacyReader.OldPhonePad("8 88777444666*664#");
    Console.WriteLine(output);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}