# Old Phone Pad Prototype

This Old Phone Pad Prototype is responsible to process pre-formatted inputted strings of Old Phone Pad input data,
and it will transform the data into human readable ASCII text strings.

## Requirments

.NET 8.0 or higher

## Usage

```csharp
using IronSoftware.OldPhonePad;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string exampleInput = "8 88777444666*664#";
            string output = LegacyReader.OldPhonePad(exampleInput);
            Console.WriteLine(output);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

```