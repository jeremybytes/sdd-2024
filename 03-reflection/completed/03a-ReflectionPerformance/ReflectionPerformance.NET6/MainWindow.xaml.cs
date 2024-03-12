using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace ReflectionPerformance.NET6;

public partial class MainWindow : Window
{
    private const int iterations = 10000000;

    #region Create Buttons

    private void StaticCreateButton_Click(object sender, RoutedEventArgs e)
    {
        var elapsed = TimeThis(() =>
        {
            for (int i = 0; i < iterations; i++)
            {
                List<int> list = new();
            }
        });

        ShowDuration(elapsed, StaticCreateDuration);
    }

    private void ReflectionCreateButton_Click(object sender, RoutedEventArgs e)
    {
        // TODO: Get Type
        Type listType = typeof(List<int>);

        var elapsed = TimeThis(() =>
        {
            for (int i = 0; i < iterations; i++)
            {
                // TODO: Create Instances
                var list = Activator.CreateInstance(listType);
            }
        });

        ShowDuration(elapsed, ReflectionCreateDuration);
    }

    #endregion

    #region Method Buttons

    private void StaticMethodButton_Click(object sender, RoutedEventArgs e)
    {
        List<int> list = new();

        var elapsed = TimeThis(() =>
        {
            for (int i = 0; i < iterations; i++)
            {
                list.Add(i);
            }
        });

        ShowDuration(elapsed, StaticMethodDuration);
    }

    private void ReflectionMethodButton_Click(object sender, RoutedEventArgs e)
    {
        var list = new List<int>();

        //TODO: Get MethodInfo for "Add"
        Type listType = typeof(List<int>);
        MethodInfo? addMethod = listType.GetMethod("Add");

        var elapsed = TimeThis(() =>
        {
            for (int i = 0; i < iterations; i++)
            {
                // TODO: Invoke "Add" method
                addMethod!.Invoke(list, new object[] { i });
            }
        });

        ShowDuration(elapsed, ReflectionMethodDuration);
    }

    #endregion

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
}
