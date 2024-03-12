using System.ComponentModel;

namespace PeopleViewer;

internal partial class MainWindowViewModel : INotifyPropertyChanged
{
    private string? popupCaption;
    public string? PopupCaption
    {
        get => popupCaption;
        set { popupCaption = value; RaisePropertyChanged(); }
    }

    private string? popupText;
    public string? PopupText
    {
        get => popupText;
        set { popupText = value; RaisePropertyChanged(); }
    }

    public void ShowPopup(string caption, string message)
    {
        PopupCaption = caption;
        PopupText = message;
    }

    public void HidePopup()
    {
        PopupCaption = null;
        PopupText = null;
    }
}
