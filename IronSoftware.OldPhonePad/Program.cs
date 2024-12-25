using IronSoftware.OldPhonePad;

try
{
    string output = LegacyReader.OldPhonePad("4433555 555666096667775553#");
    Console.WriteLine(output);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}