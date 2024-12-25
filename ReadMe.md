# Old Phone Pad Prototype

This Old Phone Pad Prototype is responsible to process pre-formatted inputted strings of Old Phone Pad input data,
and it will transform the data into human readable ASCII text strings.

## Requirments

.NET 8.0 or higher (MS Visual Studio 2022)

## Quick Start

1. Clone this repo: `git clone https://github.com/turtlethumbs/OldPhonePad.git`
2. Navigate into the cloned repo and then open 'IronSoftware.OldPhonePad.sln' with MS Visual Studio
3. Expand the IronSoftware.OldPhonePad project folder.
4. Double-click the Program.cs file to view source code of main program.
5. Run the solution to view example usage in command line.

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