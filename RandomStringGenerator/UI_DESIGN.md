# Random String Generator - Application Overview

## User Interface

The application features a clean, modern black and white theme:

```
┌─────────────────────────────────────────────────────┐
│         Random String Generator                      │
├─────────────────────────────────────────────────────┤
│                                                       │
│       Random String Generator                        │
│                                                       │
│  ┌─────────────────────────────────────────────┐   │
│  │                                              │   │
│  │         [Generated string appears here]     │   │
│  │                                              │   │
│  └─────────────────────────────────────────────┘   │
│                                                       │
│      ┌──────────┐          ┌──────────────┐        │
│      │ Generate │          │ View History │        │
│      └──────────┘          └──────────────┘        │
│                                                       │
└─────────────────────────────────────────────────────┘
```

### Main Window Features:
- **Title**: "Random String Generator"
- **Background**: White
- **Dimensions**: 500x300 pixels

### UI Components:

1. **Header Text**
   - Text: "Random String Generator"
   - Font Size: 24pt
   - Font Weight: Bold
   - Color: Black
   - Position: Centered at top

2. **Generated String Display**
   - Black bordered box
   - White background
   - Read-only text field
   - Large, bold font (18pt)
   - Centered text
   - Placeholder: "Generated string will appear here"

3. **Generate Button**
   - Text: "Generate"
   - Size: 150x40 pixels
   - Background: Black
   - Text Color: White
   - Font Size: 16pt

4. **View History Button**
   - Text: "View History"
   - Size: 150x40 pixels
   - Background: Black
   - Text Color: White
   - Font Size: 16pt

## History Window

```
┌─────────────────────────────────────────────────────┐
│              String History                          │
├─────────────────────────────────────────────────────┤
│                                                       │
│       Generated Strings History                      │
│                                                       │
│  ┌─────────────────────────────────────────────┐   │
│  │ 1. aB3$xY9#mP                                │   │
│  │ 2. Qw!8Rt@5Lz                                │   │
│  │ 3. 7Mn&Vb2^Ks                                │   │
│  │ 4. Hj*4Dc%9Fw                                │   │
│  │ 5. ...                                        │   │
│  │                                               │   │
│  │                                               │   │
│  └─────────────────────────────────────────────┘   │
│                                                       │
│              ┌──────────┐                           │
│              │  Close   │                           │
│              └──────────┘                           │
│                                                       │
└─────────────────────────────────────────────────────┘
```

### History Window Features:
- **Title**: "String History"
- **Background**: White
- **Dimensions**: 600x400 pixels
- Black bordered list box
- Monospace font for strings (Consolas/Courier New)
- Numbered list (newest first)
- Black "Close" button

## Example Generated Strings

Here are some examples of strings that the application generates:

1. `G]TwNAGnAk` - Mix of uppercase, special characters
2. `Lboi48BKwe` - Letters and numbers
3. `.Hp%KA!OmK` - Special characters, letters, uppercase
4. `cORi{68|pu` - Braces, numbers, mixed case
5. `CR<QG2lyj]` - Angle brackets, numbers, letters
6. `NmL:4)|eNL` - Parentheses, pipe, mixed case
7. `Kw=rr)[$|>` - Multiple special characters
8. `;)v{.Ai;qZ` - Semicolons, braces, mixed case
9. `&7ahhN{gIt` - Ampersand, numbers, letters
10. `qcgaRJUo=@` - At sign, equals, mixed case

## Character Set Details

The application uses 88 total characters:

- **Numbers**: `0123456789` (10 characters)
- **Lowercase Letters**: `abcdefghijklmnopqrstuvwxyz` (26 characters)
- **Uppercase Letters**: `ABCDEFGHIJKLMNOPQRSTUVWXYZ` (26 characters)
- **Special Characters**: `!@#$%^&*()_+-=[]{}|;:,.<>?` (26 characters)

## How It Works

### String Generation Process:
1. User clicks "Generate" button
2. Application loads existing history from `string_history.txt`
3. Generates a random 10-character string
4. Checks if the string already exists in history
5. If duplicate, generates a new one (max 1000 attempts)
6. Displays the unique string in the text box
7. Appends the string to the history file

### History Viewing:
1. User clicks "View History" button
2. Application reads all strings from `string_history.txt`
3. Opens a new window displaying all strings
4. Strings shown in reverse order (newest first)
5. Each entry numbered for easy reference

### Data Persistence:
- All generated strings saved to `string_history.txt`
- One string per line
- File created automatically on first generation
- Persistent across application restarts

## Technical Implementation

- **Framework**: Avalonia UI 11.3.11
- **Language**: C# 10 (.NET 10.0)
- **Platform**: Cross-platform (Windows, Linux, macOS)
- **UI Pattern**: Code-behind with event handlers
- **Data Storage**: Plain text file (UTF-8)
- **Uniqueness**: HashSet-based validation
