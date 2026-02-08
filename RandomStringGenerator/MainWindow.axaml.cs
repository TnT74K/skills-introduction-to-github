using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RandomStringGenerator;

public partial class MainWindow : Window
{
    private const string HistoryFile = "string_history.txt";
    private const int StringLength = 10;
    private static readonly Random random = new Random();
    
    // Characters to use for random string generation
    private const string Numbers = "0123456789";
    private const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
    private const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string SpecialCharacters = "!@#$%^&*()_+-=[]{}|;:,.<>?";
    private static readonly string AllCharacters = Numbers + LowercaseLetters + UppercaseLetters + SpecialCharacters;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void GenerateButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            var existingStrings = LoadHistory();
            string newString;
            int attempts = 0;
            const int maxAttempts = 1000;

            // Generate a unique string
            do
            {
                newString = GenerateRandomString();
                attempts++;
                
                if (attempts >= maxAttempts)
                {
                    ShowMessage("Warning", "Unable to generate a unique string after many attempts. The generated string may not be unique.");
                    break;
                }
            }
            while (existingStrings.Contains(newString));

            // Display the generated string
            GeneratedStringTextBox.Text = newString;

            // Save to history
            SaveToHistory(newString);
        }
        catch (Exception ex)
        {
            ShowMessage("Error", $"An error occurred: {ex.Message}");
        }
    }

    private void HistoryButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            var history = LoadHistory();
            
            if (history.Count == 0)
            {
                ShowMessage("History", "No strings generated yet.");
                return;
            }

            var historyWindow = new HistoryWindow(history);
            historyWindow.ShowDialog(this);
        }
        catch (Exception ex)
        {
            ShowMessage("Error", $"An error occurred: {ex.Message}");
        }
    }

    private string GenerateRandomString()
    {
        var stringBuilder = new StringBuilder(StringLength);
        
        for (int i = 0; i < StringLength; i++)
        {
            int index = random.Next(AllCharacters.Length);
            stringBuilder.Append(AllCharacters[index]);
        }
        
        return stringBuilder.ToString();
    }

    private HashSet<string> LoadHistory()
    {
        var history = new HashSet<string>();
        
        if (File.Exists(HistoryFile))
        {
            var lines = File.ReadAllLines(HistoryFile);
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    history.Add(line.Trim());
                }
            }
        }
        
        return history;
    }

    private void SaveToHistory(string value)
    {
        File.AppendAllText(HistoryFile, value + Environment.NewLine);
    }

    private async void ShowMessage(string title, string message)
    {
        var messageBox = new Window
        {
            Title = title,
            Width = 400,
            Height = 150,
            Background = Avalonia.Media.Brushes.White,
            Content = new StackPanel
            {
                Margin = new Avalonia.Thickness(20),
                Spacing = 15,
                Children =
                {
                    new TextBlock
                    {
                        Text = message,
                        TextWrapping = Avalonia.Media.TextWrapping.Wrap,
                        Foreground = Avalonia.Media.Brushes.Black
                    },
                    new Button
                    {
                        Content = "OK",
                        Width = 100,
                        Height = 35,
                        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                        Background = Avalonia.Media.Brushes.Black,
                        Foreground = Avalonia.Media.Brushes.White
                    }
                }
            }
        };

        var okButton = (Button)((StackPanel)messageBox.Content).Children[1];
        okButton.Click += (s, e) => messageBox.Close();

        await messageBox.ShowDialog(this);
    }
}