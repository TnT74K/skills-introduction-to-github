using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace RandomStringGenerator;

public partial class HistoryWindow : Window
{
    public HistoryWindow()
    {
        InitializeComponent();
    }

    public HistoryWindow(List<string> history) : this()
    {
        // Display history in chronological order (oldest first)
        for (int i = 0; i < history.Count; i++)
        {
            var listItem = new TextBlock
            {
                Text = $"{i + 1}. {history[i]}",
                Margin = new Avalonia.Thickness(5),
                Foreground = Avalonia.Media.Brushes.Black
            };
            HistoryListBox.Items.Add(listItem);
        }
    }

    private void CloseButton_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
