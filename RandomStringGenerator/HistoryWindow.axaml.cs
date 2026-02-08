using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;

namespace RandomStringGenerator;

public partial class HistoryWindow : Window
{
    public HistoryWindow()
    {
        InitializeComponent();
    }

    public HistoryWindow(HashSet<string> history) : this()
    {
        // Display history in reverse order (newest first)
        var items = history.Reverse().ToList();
        
        for (int i = 0; i < items.Count; i++)
        {
            var listItem = new TextBlock
            {
                Text = $"{i + 1}. {items[i]}",
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
