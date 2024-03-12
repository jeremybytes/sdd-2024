using CachingAssembly;
using System.Reflection;
using System.Windows;

namespace ReflectionDangers.WPF;

public partial class MainWindow : Window
{
    CachingClass safeCacher;
    CachingClass dangerousCacher;

    public MainWindow()
    {
        InitializeComponent();
        safeCacher = new CachingClass();
        dangerousCacher = new CachingClass();
    }

    private void PublicMembersButton_Click(object sender, RoutedEventArgs e)
    {
        List<string> cacheValue = safeCacher.CachedItems;

        string cacheTime = safeCacher.DataTime;

        UpdatePublicUI(cacheValue, cacheTime);
    }

    private void PrivateMembersButton_Click(object sender, RoutedEventArgs e)
    {
        Type cachingType = typeof(CachingClass);
        FieldInfo? cacheField = cachingType.GetField("cachedItems",
                                          BindingFlags.NonPublic | BindingFlags.Instance);
        List<string>? cacheValue = cacheField?.GetValue(dangerousCacher) as List<string>;

        string cacheTime = dangerousCacher.DataTime;

        UpdatePrivateUI(cacheValue, cacheTime);
    }

    private void UpdatePublicUI(List<string>? cacheValue, string cacheTime)
    {
        PublicListBox.ItemsSource = null;
        PublicListBox.ItemsSource = cacheValue;
        PublicDataTime.Text = cacheTime;
        CurrentTimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
    }

    private void UpdatePrivateUI(List<string>? cacheValue, string cacheTime)
    {
        PrivateListBox.ItemsSource = null;
        PrivateListBox.ItemsSource = cacheValue;
        PrivateDataTime.Text = cacheTime;
        CurrentTimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
    }
}
