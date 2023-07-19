using System.Timers;
using WarframeMauiApp.Models;

namespace WarframeMauiApp.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    private WarfrmeClinetServices services;

    public MainViewModel(WarfrmeClinetServices services)
    {
        Services = services;
        GetAllStateAsync();
        var timerSecond = new System.Timers.Timer(1000);
        timerSecond.Elapsed += Timer_Elapsed;
        timerSecond.Start();
    }

    private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (_earthTimeLeft <= 0)
        {
            await GetEarthStateAsync();
            EarthcycleStateSource = Services.earthCyclestate;
        }
        if (_cetusTimeLeft <= 0)
        {
            await GetCetusStateAsync();
            CetuscycleStateSource = Services.cetusCyclestate;

        }
        if (_cambionTimeLeft <= 0)
        {
            await GetCambionStateAsync();
            CambioncleStateSource = Services.cambionCyclestate;
        }
        if (_vallisTimeLeft <= 0)
        {
            await GetVallisStateAsync();
            ValliscleStateSource = Services.vallisCyclestate;
        }
        if (_zarimanTimeLeft <= 0)
        {
            await GetZarimanStateAsync();
            ZarimancycleStateSource = Services.zarimanCyclestate;
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


    [ObservableProperty]
    private ObservableCollection<news> newsData;
    #endregion



    public async void GetAllStateAsync()
    {
        await GetArchonHuntDataAsync();
        await GetSortieDataAsync();
        await GetNewsDataAsync();
    }
    //新闻
    public async Task GetNewsDataAsync()
    {
        await Services.UpdateNewsdata();
        NewsData = Services.newsdata;
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
    private zarimanCycle _zarimancycleStateSource;

    [ObservableProperty]
    private cambionCycle _cambioncleStateSource;

    [ObservableProperty]
    private earthCycle _earthcycleStateSource;

    [ObservableProperty]
    private cetusCycle _cetuscycleStateSource;

    [ObservableProperty]
    private vallisCycle _valliscleStateSource;

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
