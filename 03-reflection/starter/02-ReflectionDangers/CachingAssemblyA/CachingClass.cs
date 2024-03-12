namespace CachingAssembly;

public class CachingClass
{
    private DateTime dataDate;
    private List<string> cachedItems = new();

    public string DataTime => dataDate.ToString("HH:mm:ss");

    public List<string> CachedItems
    {
        get
        {
            if (cachedItems.Count == 0 || DateTime.Now - dataDate > TimeSpan.FromSeconds(5))
                RefreshCache();
            return cachedItems;
        }
    }

    public CachingClass()
    {
        RefreshCache();
    }

    private void RefreshCache()
    {
        dataDate = DateTime.Now;
        cachedItems.Add(string.Format("Time: {0}", DataTime));
    }
}
