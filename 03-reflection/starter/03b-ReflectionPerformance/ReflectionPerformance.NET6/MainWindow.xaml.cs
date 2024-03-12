using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace ReflectionPerformance.NET6;

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

        ShowDuration(elapsed, ReflectionAddDuration);
    }

    private void InterfaceAddButton_Click(object sender, RoutedEventArgs e)
    {
        Type listType = typeof(List<int>);
        IList<int>? list = Activator.CreateInstance(listType) as IList<int>;

        var elapsed = TimeThis(() =>
        {
            for (int i = 0; i < iterations; i++)
            {
                list!.Add(i);
            }
        });

        ShowDuration(elapsed, InterfaceAddDuration);
    }

    private delegate void ListAddDelegate(List<int> list, int value);

    private void DelegateAddButton_Click(object sender, RoutedEventArgs e)
    {
        List<int> list = new();

        Type listType = typeof(List<int>);
        MethodInfo? addMethod = listType.GetMethod("Add");

        var addDelegate = (ListAddDelegate)Delegate.CreateDelegate(
                                typeof(ListAddDelegate), addMethod!);

        var elapsed = TimeThis(() =>
        {
            for (int i = 0; i < iterations; i++)
            {
                addDelegate(list, i);
            }
        });

        ShowDuration(elapsed, DelegateAddDuration);
    }
}
