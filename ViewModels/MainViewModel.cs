using System.Timers;


namespace WarframeMauiApp.ViewModels;

public partial class MainViewModel : BaseViewModel
{

    private WorldStateServices Services { get; set; }

    public MainViewModel(WorldStateServices services)
    {
        Services = services;
        //GetAllWorldStateAsync();
        var timer = new System.Timers.Timer();
        timer.Interval = 1000;
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
    }

    private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (_earthTimeLeft <= 0)
        {
            await GetEarthStateAsync();
        }
        if (_cetusTimeLeft <= 0)
        {
            await GetCetusStateAsync();
        }
        if (_cambionTimeLeft <= 0)
        {
            await GetCambionStateAsync();
        }
        if (_vallisTimeLeft <= 0)
        {
            await GetVallisStateAsync();
        }
        if (_zarimanTimeLeft <= 0)
        {
            await GetZarimanStateAsync();
        }
        EarthTimeLeftString = TimeConverter.UpdateTimeLift(ref _earthTimeLeft);
        CetusTimeLeftString = TimeConverter.UpdateTimeLift(ref _cetusTimeLeft);
        CambionTimeLeftString = TimeConverter.UpdateTimeLift(ref _cambionTimeLeft);
        VallisTimeLeftString = TimeConverter.UpdateTimeLift(ref _vallisTimeLeft);
        ZarimanTimeLeftString = TimeConverter.UpdateTimeLift(ref _zarimanTimeLeft);

    }
    /*
    private string UpdateTimeLift(ref int TimeLeft)
    {
        TimeLeft--;
        return TimeConverter.SecondstoTimesString(TimeLeft);
    }
    */
    /// <summary>
    /// 属性和字段
    /// </summary>
    #region 
    private int _earthTimeLeft;

    private int _cetusTimeLeft;

    private int _cambionTimeLeft;

    private int _vallisTimeLeft;

    private int _zarimanTimeLeft;

    [ObservableProperty]
    private string _zarimanTimeLeftString;

    [ObservableProperty]
    private string _earthTimeLeftString;

    [ObservableProperty]
    private string _vallisTimeLeftString;

    [ObservableProperty]
    private string _cetusTimeLeftString;

    [ObservableProperty]
    private string _cambionTimeLeftString;

    #endregion

    /// <summary>
    /// 方法
    /// </summary>
    #region
    /*
    public async Task GetAllWorldStateAsync()
    {
        await Services.UpdateEarthState();
        await Services.UpdateCetusState();
        await Services.UpdateCambionState();

        _earthTimeLeft = TimeConverter.getliftSeconds(Services.earthCyclestate.timeLeft);
        _cetusTimeLeft = TimeConverter.getliftSeconds(Services.cetusCyclestate.timeLeft);
        _cambionTimeLeft = TimeConverter.getliftSeconds(Services.cambionCyclestate.timeLeft);

    }*/

    public async Task GetZarimanStateAsync()
    {
        await Services.UpdateZarimanState();
        _zarimanTimeLeft = TimeConverter.getliftSeconds(Services.zarimanCyclestate.timeLeft);
    }

    public async Task GetVallisStateAsync()
    {
        await Services.UpdateVallisState();
        _vallisTimeLeft = TimeConverter.getliftSeconds(Services.vallisCyclestate.timeLeft);
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

    public async Task GetCambionStateAsync()
    {
        await Services.UpdateCambionState();
        _cambionTimeLeft = TimeConverter.getliftSeconds(Services.cambionCyclestate.timeLeft);
    }
    #endregion
}
