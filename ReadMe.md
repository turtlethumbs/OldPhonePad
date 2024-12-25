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

[Download MS Visual Studio](https://visualstudio.microsoft.com/downloads/)

## Quick Start

1. Clone this repo: `git clone https://github.com/turtlethumbs/OldPhonePad.git`
2. Navigate into the cloned repo and then open 'IronSoftware.OldPhonePad.sln' with MS Visual Studio 2022
3. Expand the IronSoftware.OldPhonePad project folder.
4. Double-click the Program.cs file to view source code of main program.
5. Optionally - review the source code of OldPhonePad method within the LegacyReader.cs class file.
6. Run the solution to view example usage in command line.

# Highlights

1. The LegacyReader.cs class file is fully coverage by unit tests in 'IronSoftware.OldPhonePad.Tests' project.
2. The Main project folder has been referenced by the Tests project. Try running `Tests > Run All Tests`
3. Both happy path and unhappy path test scenarios have been covered with test cases.
4. Test driven development (TDD) approach was used to write failing tests first and then make them pass.
5. GitHub Actions runs the unit tests for every push / pull into the master branch.
6. A test coverage report is produced as a build artifact for this software repository via Actions.

## Usage

Make a new source code program file, and then use the IronSoftware.OldPhonePad namespace. Simply provide valid Old Phone Pad data input to the static public method LegacyReader.OldPhonePad exposed by the LegacyReader class file. Returned output is in string format.

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

## Method - OldPhonePad

`string LegacyReader.OldPhonePad(string input)`

### Input Params

`input` as a String 

### Output

This method's output is in UPPERCASE ASCII text format.

### Format

The input must follow specific rules to pass validation logic within the class method.

1) The input may consist of only the following characters '0123456789*#' and blank spaces ' '
2) The input must always be terminated with a '#' character that only appears once.
3) The input may contain a ' ' (space) between each character as a pause indication to proceed with the previously typed character selection. 
4) The '*' character may be specified to erase a previously typed character selection.

### Mapping

Each number on the keypad of an old phone pad may be pressed X number of times to select a character. Please review the below mapping to understanding that 2 pressed one time is 'A' and 2 pressed three times is 'C'. Also, 7 pressed four times is 'S'. Note that a single button is dedicated to typing a space, erasing the previous inputted character, and sending / entering as (0, '*', and '#') respectively.

1) `& - ' - (`
2) `A - B - C`
3) `D - E - F`
4) `G - H - I`
5) `J - K - L`
6) `M - N - O`
7) `P - Q - R - S`
8) `T - U - V`
9) `W - X - Y - Z`
0) ` `
*) <Erase>
#) <Send/Enter>

**Note:** ' ' characters in the input data are treated as 1 second pauses that confirm the user's most recent previous selection.

### Example Input / Outputs

| Input | Output |
|-------|--------|
| 33#   | E      |
| 227*# | B      |
| 4433555 555666# | HELLO |
| 4433555 555666096667775553# | HELLO WORLD |
| 62 22212224433 33777733# | MAC&CHEESE |
| 11184426655111011199966688111# | (THANK) (YOU) |
| 111*84426655111011199966688111# | THANK( )YOU( |

## Finished.