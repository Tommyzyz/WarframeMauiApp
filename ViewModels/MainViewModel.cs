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
        if (_earthTimeLeft <= 0)
        {
            GetEarthStateAsync();
        }
        if (_cetusTimeLeft <= 0)
        {
            GetCetusStateAsync();
        }
        EarthTimeLeftString = UpdateTimeLift(ref _earthTimeLeft);
        CetusTimeLeftString = UpdateTimeLift(ref _cetusTimeLeft);

        //EarthTimeLeft--;
        //CetusTimeLeft--;

        //EarthTimeLiftString = TimeConverter.SecondstoTimesString(EarthTimeLeft);
        //CetusTimeLiftString = TimeConverter.SecondstoTimesString(CetusTimeLeft);


    }

    private string UpdateTimeLift(ref int TimeLeft)
    {
        TimeLeft--;
        return TimeConverter.SecondstoTimesString(TimeLeft);
    }


    private int _earthTimeLeft;

    private int _cetusTimeLeft;

    [ObservableProperty]
    public string _earthTimeLeftString;

    [ObservableProperty]
    public string _cetusTimeLeftString;



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
