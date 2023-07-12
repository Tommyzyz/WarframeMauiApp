using System.Timers;
using WarframeMauiApp.Models;

namespace WarframeMauiApp.ViewModels;

public partial class MainViewModel : BaseViewModel
{

    WorldStateServices Services
    {
        get; set;
    }

    public MainViewModel(WorldStateServices services)
    {
        Services = services;
        GetAllWorldStateAsync();
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Interval = 1000;
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
    }

    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        EarthTimeLeft--;
        CetusTimeLeft--;
        if (EarthTimeLeft == 1)
        {
            GetEarthStateAsync();
        }
        if (CetusTimeLeft == 1)
        {
            GetCetusStateAsync();
        }
        EarthTimeLiftString = TimeConverter.SecondstoTimesString(EarthTimeLeft);
        CetusTimeLiftString = TimeConverter.SecondstoTimesString(CetusTimeLeft);

    }

    [ObservableProperty]
    private int _earthTimeLeft;

    [ObservableProperty]
    private int _cetusTimeLeft;

    [ObservableProperty]
    private string _earthTimeLiftString;

    [ObservableProperty]
    private string _cetusTimeLiftString;

    [ObservableProperty]
    private string cetusCycleState;

    [ObservableProperty]
    public string worldState;

    [ObservableProperty]
    string text = "Hello";

    public async Task GetAllWorldStateAsync()
    {
        await Services.UpdateEarthState();
        await Services.UpdateCetusState();

        _earthTimeLeft = TimeConverter.getliftSeconds(Services.earthCyclestate.timeLeft);
        _cetusTimeLeft = TimeConverter.getliftSeconds(Services.cetusCyclestate.timeLeft);

    }

    public async Task GetEarthStateAsync()
    {
        await Services.UpdateEarthState();
        _earthTimeLeft = TimeConverter.getliftSeconds(Services.earthCyclestate.timeLeft);
    }

    public async Task GetCetusStateAsync()
    {
        await Services.UpdateCetusState();
        _cetusTimeLeft = TimeConverter.getliftSeconds(Services.cetusCyclestate.timeLeft);
    }
}
