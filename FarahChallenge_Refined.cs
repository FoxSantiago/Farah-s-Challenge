using System;
using System.Text;

class Program
{
    // Entry point of the program with test cases
    static void Main()
    {
        Console.WriteLine("==== Old Phone Pad Decoder Test Cases ====");
        
        // Basic test cases from the assignment
        Console.WriteLine("Test Case 1: Single letter");
        Console.WriteLine("Input: 33#");
        Console.WriteLine("Expected: E");
        Console.WriteLine("Result: " + OldPhonePad("33#"));
        
        Console.WriteLine("\nTest Case 2: Letter with backspace");
        Console.WriteLine("Input: 227*#");
        Console.WriteLine("Expected: B");
        Console.WriteLine("Result: " + OldPhonePad("227*#"));
        
        Console.WriteLine("\nTest Case 3: Word with spaces");
        Console.WriteLine("Input: 4433555 555666#");
        Console.WriteLine("Expected: HELLO");
        Console.WriteLine("Result: " + OldPhonePad("4433555 555666#"));
        
        Console.WriteLine("\nTest Case 4: Complex input with spaces and backspace");
        Console.WriteLine("Input: 8 88777444666*664#");
        Console.WriteLine("Expected: TURING");
        Console.WriteLine("Result: " + OldPhonePad("8 88777444666*664#"));
    }

    /// <summary>
    /// Converts input from an old phone keypad format into readable text.
    /// </summary>
    /// <param name="input">String containing keypad input with # as end marker</param>
    /// <returns>Decoded text message</returns>
    /// <exception cref="ArgumentNullException">Thrown when input is null</exception>
    /// <exception cref="ArgumentException">Thrown when input doesn't end with #</exception>
    public static string OldPhonePad(string input)
    {
        // Input validation
        if (input == null)
            throw new ArgumentNullException(nameof(input), "Input cannot be null");
            
        if (!input.EndsWith("#"))
            throw new ArgumentException("Input must end with # character", nameof(input));
            
        StringBuilder result = new StringBuilder(); // More efficient for string manipulation
        StringBuilder group = new StringBuilder();  // Group of repeated digits
        
        // Process each character in the input
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            
            if (c == '#')
            {
                // End of input - process any remaining group
                if (group.Length > 0)
                    result.Append(ProcessGroup(group.ToString()));
                break;
            }
            else if (c == ' ')
            {
                // Space means pause between characters
                if (group.Length > 0)
                {
                    result.Append(ProcessGroup(group.ToString()));
                    group.Clear();
                }
            }
            else if (c == '*')
            {
                // Backspace - process current group then delete last character
                if (group.Length > 0)
                {
                    result.Append(ProcessGroup(group.ToString()));
                    group.Clear();
                }
                
                if (result.Length > 0)
                    result.Length--; // More efficient than Substring
            }
            else if (char.IsDigit(c))
            {
                // If same digit is pressed again, add to current group
                if (group.Length > 0 && group[0] == c)
                {
                    group.Append(c);
                }
                else
                {
                    // Different digit - process previous group and start new one
                    if (group.Length > 0)
                        result.Append(ProcessGroup(group.ToString()));
                    
                    group.Clear();
                    group.Append(c);
                }
            }
            // Ignore any other characters that aren't valid inputs
        }
        
        return result.ToString();
    }

    /// <summary>
    /// Converts a group of repeated digits into a single letter
    /// </summary>
    /// <param name="group">String containing repeated digits (e.g. "222")</param>
    /// <returns>The corresponding letter or empty string if invalid</returns>
    private static string ProcessGroup(string group)
    {
        if (string.IsNullOrEmpty(group)) 
            return string.Empty;
            
        char digit = group[0];              // First digit in the group
        int count = group.Length;           // How many times it was pressed
        string letters = GetLetters(digit); // Letters associated with that digit
        
        if (string.IsNullOrEmpty(letters)) 
            return string.Empty;
            
        // Get the appropriate letter based on press count
        int index = (count - 1) % letters.Length;
        return letters[index].ToString();
    }

    /// <summary>
    /// Maps digits to their corresponding letters on a phone keypad
    /// </summary>
    /// <param name="digit">The numeric digit (0-9)</param>
    /// <returns>String containing the letters for that digit</returns>
    private static string GetLetters(char digit)
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
            case '0': return " ";  // Added space character for completeness
            default: return "";    // Return empty string for non-mapped digits
        }
    }
}
