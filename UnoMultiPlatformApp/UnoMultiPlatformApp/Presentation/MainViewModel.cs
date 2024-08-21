namespace UnoMultiPlatformApp.Presentation;


public partial class MainViewModel : ObservableObject
{
    private INavigator _navigator;

    [ObservableProperty]
    private int _count = 0;

    [ObservableProperty]
    private int _step = 1;

    [RelayCommand]
    private void Increment()
        => Count += Step;
    
    [ObservableProperty]
    private string? name;

    public MainViewModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
        GoToSecond = new AsyncRelayCommand(GoToSecondView);


    }
    public string? Title { get; }

    public ICommand GoToSecond { get; }

    private async Task GoToSecondView()
    {
        await _navigator.NavigateViewModelAsync<SecondViewModel>(this, data: new Entity(Name!));
    }

}
