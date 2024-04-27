using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace ReflectionPerformance.NET8;

public partial class MainWindow : Window
{
    private const int iterations = 10000000;

    public MainWindow()
    {
        InitializeComponent();
    }

    private TimeSpan TimeThis(Action timedItem)
    {
        var stopwatch = Stopwatch.StartNew();
        timedItem?.Invoke();
        stopwatch.Stop();
        return stopwatch.Elapsed;
    }

    private void ShowDuration(TimeSpan elapsedTime, TextBlock outputTextBlock)
    {
        outputTextBlock.Text = $"{elapsedTime.TotalMilliseconds:F0}";
    }

    private void StaticAddButton_Click(object sender, RoutedEventArgs e)
    {
        List<int> list = new();

        var elapsed = TimeThis(() =>
        {
            for (int i = 0; i < iterations; i++)
            {
                list.Add(i);
            }
        });

        ShowDuration(elapsed, StaticAddDuration);
    }

    private void ReflectionAddButton_Click(object sender, RoutedEventArgs e)
    {
        List<int> list = new();

        Type listType = typeof(List<int>);
        MethodInfo? addMethod = listType.GetMethod("Add");

        var elapsed = TimeThis(() =>
        {
            for (int i = 0; i < iterations; i++)
            {
                addMethod!.Invoke(list, new object[] { i });
            }
        });

        ShowDuration(elapsed, ReflectionAddDuration);
    }

    private void InterfaceAddButton_Click(object sender, RoutedEventArgs e)
    {
        // TODO: Get Instance of IList<int>

        var elapsed = TimeThis(() =>
        {
            for (int i = 0; i < iterations; i++)
            {
                // TODO: Call IList<int>.Add
            }
        });

        ShowDuration(elapsed, InterfaceAddDuration);
    }

    private delegate void ListAddDelegate(List<int> list, int value);

    private void DelegateAddButton_Click(object sender, RoutedEventArgs e)
    {
        List<int> list = new();

        // TODO: Get MethodInfo

        // TODO: Create Delegate

        var elapsed = TimeThis(() =>
        {
            for (int i = 0; i < iterations; i++)
            {
                // TODO: Invoke Delegate
            }
        });

        ShowDuration(elapsed, DelegateAddDuration);
    }
}
