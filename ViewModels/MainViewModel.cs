using System.Timers;


namespace WarframeMauiApp.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    private WarfrmeClinetServices services;

    public MainViewModel(WarfrmeClinetServices services)
    {
        Services = services;
        GetArchonHuntDataAsync();
        var timerSecond = new System.Timers.Timer(1000);
        timerSecond.Elapsed += Timer_Elapsed;
        timerSecond.Start();
    }

    private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (_earthTimeLeft <= 0)
        {
            await GetEarthStateAsync();
            EarthstateSource = Services.earthCyclestate.state;
            if (Services.earthCyclestate.isDay) EarthstateSource = "&#x1F505;";
            else EarthstateSource = "&#x1F319;";
        }
        if (_cetusTimeLeft <= 0)
        {
            await GetCetusStateAsync();
            CetusstateString = Services.cetusCyclestate.state;
            
        }
        if (_cambionTimeLeft <= 0)
        {
            await GetCambionStateAsync();
            if (Services.cambionCyclestate.state == "vome")
            {
                CambionimageSource = "vome.png";
                CambionstateString = "Vome";
            }
            else
            {
                CambionimageSource = "fass.png";
                CambionstateString = "Fass";
            }
        }
        if (_vallisTimeLeft <= 0)
        {
            await GetVallisStateAsync();
            VallisstateString = Services.vallisCyclestate.state;
        }
        if (_zarimanTimeLeft <= 0)
        {
            await GetZarimanStateAsync();
            if (Services.zarimanCyclestate.isCorpus)
            {
                ZarimanimageSource = "corpustheme.png";
                ZarimanstateString = "Corpus";
            }
            else
            {
                ZarimanimageSource = "grineertheme.png";
                ZarimanstateString = "Grineer";
            }
        }
        EarthTimeLeftString = TimeConverter.UpdateTimeLift(ref _earthTimeLeft);
        CetusTimeLeftString = TimeConverter.UpdateTimeLift(ref _cetusTimeLeft);
        CambionTimeLeftString = TimeConverter.UpdateTimeLift(ref _cambionTimeLeft);
        VallisTimeLeftString = TimeConverter.UpdateTimeLift(ref _vallisTimeLeft);
        ZarimanTimeLeftString = TimeConverter.UpdateTimeLift(ref _zarimanTimeLeft);
        //ZarimanimageSource = "corpustheme.png";

    }


    #region 

    [ObservableProperty]
    private archonHunt archonHuntData;  

    #endregion


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

    public async Task GetArchonHuntDataAsync()
    {
        await Services.UpdateArchonHuntdata();
        ArchonHuntData = Services.archonHuntdata;
    }




    //世界状态
    #region
    [ObservableProperty]
    private string _zarimanimageSource = "grineertheme.png";

    [ObservableProperty]
    private string _zarimanstateString = "grineer";

    [ObservableProperty]
    private string _cambionimageSource = "vome.png";

    [ObservableProperty]
    private string _cambionstateString = "Vome";

    [ObservableProperty]
    private string _earthstateSource;

    [ObservableProperty]
    private string _cetusstateString;

    [ObservableProperty]
    private string _vallisstateString;

    private int _earthTimeLeft = -1;

    private int _cetusTimeLeft = -1;

    private int _cambionTimeLeft = -1;

    private int _vallisTimeLeft = -1;

    private int _zarimanTimeLeft = -1;

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
