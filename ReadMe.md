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
5. Optionally - review the source code of OldPhonePad method within the LegacyReader.cs class file.
6. Run the solution to view example usage in command line.

# Highlights

1. The LegacyReader.cs class file is fully coverage by unit tests which are located in the 'IronSoftware.OldPhonePad.Tests' project folder. I.e. LegacyReaderTests.cs
2. Main project folder configured to be referenced by Tests project, so that Tests > Run All Tests may be executed already.
3. Both happy path and unhappy path test scenarios have been covered with unit tests.

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

### Method - OldPhonePad

`string LegacyReader.OldPhonePad(string input)`

#### Params

input as a String 

#### Format

The input must follow specific rules to pass validation logic with the class method.

1) The input may consist of only the following chracters '0123456789*#' and black space ' '. 
2) The input must always be terminated with a '#' character that only appears once.
3) The input may contain a ' ' (space) between each character as a pause indication to proceed with character selection.
4) The '*' character may be specified to erase a previously typed character.

### Output

The method's output is in UPPERCASE ASCII text format, and the final output is given by the function upon processing the '#' character.

## Finished.