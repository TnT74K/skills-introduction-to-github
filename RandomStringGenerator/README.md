# Random String Generator

A modern C# application with a graphical user interface to generate random 10-character strings and save them to a history file.

## Features

- Generate random 10-character strings using:
  - Numbers (0-9)
  - Lowercase letters (a-z)
  - Uppercase letters (A-Z)
  - Special characters (!@#$%^&*()_+-=[]{}|;:,.<>?)
- Ensures each generated string is unique (not in history)
- Save generated strings to a persistent history file
- View all previously generated strings
- Modern black and white UI theme (white background with black buttons)

## Requirements

- .NET 10.0 SDK or later
- Cross-platform (Windows, Linux, macOS)

## Building the Application

```bash
cd RandomStringGenerator
dotnet build
```

## Running the Application

```bash
cd RandomStringGenerator
dotnet run
```

## Usage

1. **Generate a String**: Click the "Generate" button to create a new random 10-character string. The string will appear in the text box and be automatically saved to history.

2. **View History**: Click the "View History" button to see all previously generated strings in a new window.

## Files

- `MainWindow.axaml` / `MainWindow.axaml.cs`: Main application window with UI and logic
- `HistoryWindow.axaml` / `HistoryWindow.axaml.cs`: History viewer window
- `string_history.txt`: File where generated strings are stored (created automatically)

## Architecture

The application uses Avalonia UI framework for cross-platform desktop application development. It features:

- Clean MVVM-like architecture
- File-based persistence
- Unique string validation
- User-friendly error handling
