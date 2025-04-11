using System; // Basic library for console and string operations

class Program
{
    // Entry point of the program
    static void Main()
    {
        // Test case 1: pressing "3" twice should return "E"
        Console.WriteLine("Input: 33#");
        Console.WriteLine("Expected: E");
        Console.WriteLine("Result: " + OldPhonePad("33#"));

        // Test case 2: "22" = B, then "7" = P, then "*" deletes last → result is "B"
        Console.WriteLine("\nInput: 227*#");
        Console.WriteLine("Expected: B");
        Console.WriteLine("Result: " + OldPhonePad("227*#"));

        // Test case 3: input with multiple characters, spaced → "HELLO"
        Console.WriteLine("\nInput: 4433555 555666#");
        Console.WriteLine("Expected: HELLO");
        Console.WriteLine("Result: " + OldPhonePad("4433555 555666#"));

        // Test case 4: uses space, backspace, and multiple digits → "TURING"
        Console.WriteLine("\nInput: 8 88777444666*664#");
        Console.WriteLine("Expected: TURING");
        Console.WriteLine("Result: " + OldPhonePad("8 88777444666*664#"));
    }

    // This method processes a keypad-style string and returns the decoded message
    public static string OldPhonePad(string input)
    {
        string result = ""; // Final decoded message
        string group = "";  // Group of repeated digits like "777"

        // Loop through each character in the input string
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i]; // Current character

            if (c == '#')
            {
                // End of input → process the last group before exiting
                result += ProcessGroup(group);
                break;
            }
            else if (c == ' ')
            {
                // A space means a pause between characters → convert current group
                result += ProcessGroup(group);
                group = ""; // Clear group after processing
            }
            else if (c == '*')
            {
                // Backspace → delete the last letter in the result
                result += ProcessGroup(group);
                group = ""; // Also clear the group
                if (result.Length > 0)
                    result = result.Substring(0, result.Length - 1); // Remove last letter
            }
            else if (char.IsDigit(c))
            {
                // If same digit is pressed again, continue the group
                if (group.Length > 0 && group[0] == c)
                {
                    group += c;
                }
                else
                {
                    // If digit changes, process the previous group
                    result += ProcessGroup(group);
                    group = "" + c; // Start new group
                }
            }
        }

        return result; // Return the final message
    }

    // Converts a group of repeated digits (e.g., "222") into a letter
    static string ProcessGroup(string group)
    {
        if (group.Length == 0) return ""; // No digits to process

        char digit = group[0]; // Which digit was pressed
        int count = group.Length; // How many times it was pressed
        string letters = GetLetters(digit); // Get the letters associated with that digit

        if (letters == "") return ""; // If digit has no letters, return nothing

        // Use modulo to wrap around if the count exceeds the number of letters
        int index = (count - 1) % letters.Length;
        return letters[index].ToString(); // Return the selected letter
    }

    // Returns the string of letters for each digit like on a traditional phone keypad
    static string GetLetters(char digit)
    {
        switch (digit)
        {
            case '2': return "ABC";
            case '3': return "DEF";
            case '4': return "GHI";
            case '5': return "JKL";
            case '6': return "MNO";
            case '7': return "PQRS";
            case '8': return "TUV";
            case '9': return "WXYZ";
            default: return ""; // If digit is invalid
        }
    }
}
