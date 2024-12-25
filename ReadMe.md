# Old Phone Pad Prototype

This Old Phone Pad Prototype processes pre-formatted data strings from Old Phone Pad input devices.

## Features

- Transforms pre-formatted old phone pad data strings into human readable ASCII text strings.
- Input validation raises catchable exceptions for blank, null, or malformed input data.
- Auto-replaces subsequently found '(' characters with ')' to mimic parenthesis closing behavior.
- Replays erase button presses as specified in the input as the '*' character to remove previous character.
- Explicit line endings by strict requirement to specify a '#' character at the end of each line.

## Requirments

.NET 8.0 or higher (MS Visual Studio 2022)

## Quick Start

1. Clone this repo: `git clone https://github.com/turtlethumbs/OldPhonePad.git`
2. Navigate into the cloned repo and then open 'IronSoftware.OldPhonePad.sln' with MS Visual Studio 2022
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

## Data Format

- 