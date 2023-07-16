using System.Timers;


namespace WarframeMauiApp.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    private WarfrmeClinetServices services;

    public MainViewModel(WarfrmeClinetServices services)
    {
        Services = services;
        GetAllWorldStateAsync();
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
            if (Services.earthCyclestate.isDay) EarthimageSource = "sunriseovermountains.png";
            else EarthimageSource = "shootingstar.png";
        }
        if (_cetusTimeLeft <= 0)
        {
            await GetCetusStateAsync();
            CetusstateString = Services.cetusCyclestate.state;
            if (Services.cetusCyclestate.isDay) CetusimageSource = "sunriseovermountains.png";
            else CetusimageSource = "shootingstar.png";

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
            if (Services.vallisCyclestate.isWarm) VallisimageSource = "warm.png";
            else VallisimageSource = "cold.png";
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


    }


    #region 

    [ObservableProperty]
    private archonHunt archonHuntData;

    [ObservableProperty]
    private sortie sortieData;
    #endregion


    
    public async void GetAllWorldStateAsync()
    {
        await GetArchonHuntDataAsync();
        await GetSortieDataAsync();

    }
    //执行官
    public async Task GetArchonHuntDataAsync()
    {
        await Services.UpdateArchonHuntdata();
        ArchonHuntData = Services.archonHuntdata;
    }
    //突击
    public async Task GetSortieDataAsync()
    {
        await Services.UpdateSortiedata();
        SortieData = Services.sortiedata;
    }

    //sortie

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
    private string _earthimageSource = "sunriseovermountains.png";

    [ObservableProperty]
    private string _cetusstateString;

    [ObservableProperty]
    private string _cetusimageSource = "sunriseovermountains.png";

    [ObservableProperty]
    private string _vallisstateString;

    [ObservableProperty]
    private string _vallisimageSource = "warm.png";

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
        _zarimanTimeLeft = TimeConverter.getLiftSeconds(Services.zarimanCyclestate.expiry);
    }

    public async Task GetVallisStateAsync()
    {
        await Services.UpdateVallisState();
        _vallisTimeLeft = TimeConverter.getLiftSeconds(Services.vallisCyclestate.expiry);
    }

    public async Task GetEarthStateAsync()
    {
        await Services.UpdateEarthState();
        _earthTimeLeft = TimeConverter.getLiftSeconds(Services.earthCyclestate.expiry);
    }

    public async Task GetCetusStateAsync()
    {
        await Services.UpdateCetusState();
        _cetusTimeLeft = TimeConverter.getLiftSeconds(Services.cetusCyclestate.expiry);
    }

    public async Task GetCambionStateAsync()
    {
        await Services.UpdateCambionState();
        _cambionTimeLeft = TimeConverter.getLiftSeconds(Services.cambionCyclestate.expiry);
    }
    #endregion
}
