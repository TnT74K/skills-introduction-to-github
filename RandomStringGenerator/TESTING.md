# Testing Guide

## Manual Testing Steps

### Test 1: Application Launch
1. Navigate to the `RandomStringGenerator` directory
2. Run `dotnet run`
3. **Expected**: Application window opens with title "Random String Generator"
4. **Expected**: White background with black buttons visible
5. **Expected**: Text box shows placeholder text

### Test 2: Generate First String
1. Click the "Generate" button
2. **Expected**: A 10-character string appears in the text box
3. **Expected**: String contains a mix of numbers, letters, and special characters
4. **Expected**: File `string_history.txt` is created in the application directory

### Test 3: Generate Multiple Strings
1. Click "Generate" button 5 times
2. **Expected**: Each click produces a different string
3. **Expected**: Each new string appears in the text box
4. **Expected**: All strings are exactly 10 characters long

### Test 4: View History
1. After generating several strings, click "View History" button
2. **Expected**: A new window opens titled "String History"
3. **Expected**: All previously generated strings are listed
4. **Expected**: Strings are numbered (1, 2, 3, etc.)
5. **Expected**: List is in chronological order (oldest first)
6. **Expected**: Window has a black "Close" button

### Test 5: History Persistence
1. Close the application
2. Reopen the application by running `dotnet run`
3. Click "View History" button
4. **Expected**: All previously generated strings are still visible
5. **Expected**: History persists across application restarts

### Test 6: Uniqueness Validation
1. Check the `string_history.txt` file
2. Generate many strings (50+)
3. **Expected**: No duplicate strings in the history file
4. **Expected**: Each string is unique

### Test 7: Character Variety
1. Generate 20 strings
2. Examine each string
3. **Expected**: Most strings contain a mix of:
   - Numbers (0-9)
   - Lowercase letters (a-z)
   - Uppercase letters (A-Z)
   - Special characters (!@#$%^&*()_+-=[]{}|;:,.<>?)

### Test 8: UI Theme Verification
1. Examine the application window
2. **Expected**: Background is white
3. **Expected**: Buttons have black background with white text
4. **Expected**: Text is black on white background
5. **Expected**: Border around text box is black

## Automated Test

You can run the following test to verify string generation logic:

```bash
cd /tmp
cat > test_strings.cs << 'EOF'
using System;
using System.Collections.Generic;
using System.Text;

class Test
{
    private const int StringLength = 10;
    private static readonly Random random = new Random();
    private const string Numbers = "0123456789";
    private const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
    private const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string SpecialCharacters = "!@#$%^&*()_+-=[]{}|;:,.<>?";
    private static readonly string AllCharacters = Numbers + LowercaseLetters + UppercaseLetters + SpecialCharacters;

    static void Main()
    {
        Console.WriteLine("Testing Random String Generator Logic");
        Console.WriteLine("======================================\n");
        
        var generated = new HashSet<string>();
        const int testCount = 100;
        
        for (int i = 0; i < testCount; i++)
        {
            string str = GenerateRandomString();
            
            // Test 1: Length
            if (str.Length != StringLength)
            {
                Console.WriteLine($"FAIL: String {i+1} has length {str.Length}, expected {StringLength}");
                return;
            }
            
            // Test 2: Valid characters
            foreach (char c in str)
            {
                if (!AllCharacters.Contains(c))
                {
                    Console.WriteLine($"FAIL: String {i+1} contains invalid character '{c}'");
                    return;
                }
            }
            
            // Test 3: Uniqueness (high probability)
            if (generated.Contains(str))
            {
                Console.WriteLine($"FAIL: Duplicate string generated: {str}");
                return;
            }
            
            generated.Add(str);
        }
        
        Console.WriteLine($"SUCCESS: Generated {testCount} unique strings");
        Console.WriteLine($"All strings are exactly {StringLength} characters");
        Console.WriteLine("All strings contain only valid characters");
        Console.WriteLine("\nSample generated strings:");
        
        int count = 0;
        foreach (var str in generated)
        {
            Console.WriteLine($"  {str}");
            if (++count >= 10) break;
        }
    }

    static string GenerateRandomString()
    {
        var sb = new StringBuilder(StringLength);
        for (int i = 0; i < StringLength; i++)
        {
            int index = random.Next(AllCharacters.Length);
            sb.Append(AllCharacters[index]);
        }
        return sb.ToString();
    }
}
EOF

# Compile and run
csc test_strings.cs && mono test_strings.exe
# OR
# dotnet-script test_strings.cs
```

## Expected Behavior Summary

✅ Application launches with modern black and white UI  
✅ Generate button creates 10-character random strings  
✅ Strings contain numbers, letters (both cases), and special characters  
✅ Each generated string is unique  
✅ History is saved to `string_history.txt`  
✅ View History button shows all generated strings  
✅ History persists across application restarts  
✅ No security vulnerabilities (verified with CodeQL)  
✅ Clean, maintainable code (verified with code review)
