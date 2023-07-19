

using WarframeMauiApp.Models;

namespace WarframeMauiApp.Services;


public class WarfrmeClinetServices

{

    public readonly HttpClient httpClient = new();

    public earthCycle earthCyclestate;
    public cetusCycle cetusCyclestate;
    public cambionCycle cambionCyclestate;
    public vallisCycle vallisCyclestate;
    public zarimanCycle zarimanCyclestate;

    public archonHunt archonHuntdata;
    public sortie sortiedata;

    public ObservableCollection<news> newsdata;



    public async Task UpdateNewsdata()
    {
        newsdata = await GetWarframeDateAsync<ObservableCollection<news>>(WarframeAPIUri.newsUri);
    }

    public async Task UpdateSortiedata()
    {
        sortiedata = await GetWarframeDateAsync<sortie>(WarframeAPIUri.sortieUri);
    }

    public async Task UpdateArchonHuntdata()
    {
        archonHuntdata = await GetWarframeDateAsync<archonHunt>(WarframeAPIUri.archonHuntUri);
    }

    public async Task UpdateZarimanState()
    {
        zarimanCyclestate = await GetWarframeDateAsync<zarimanCycle>(WarframeAPIUri.zarimanCycleUri);
    }

    public async Task UpdateVallisState()
    {
        vallisCyclestate = await GetWarframeDateAsync<vallisCycle>(WarframeAPIUri.vallisCycleUri);
    }

    public async Task UpdateEarthState()
    {
        earthCyclestate = await GetWarframeDateAsync<earthCycle>(WarframeAPIUri.earthUri);
    }

    public async Task UpdateCetusState()
    {
        cetusCyclestate = await GetWarframeDateAsync<cetusCycle>(WarframeAPIUri.cetusUri);
    }

    public async Task UpdateCambionState()
    {
        cambionCyclestate = await GetWarframeDateAsync<cambionCycle>(WarframeAPIUri.cambionUri);
    }


    private async Task<T> GetWarframeDateAsync<T>(Uri uri)
    {

        var responseData = await httpClient.GetAsync(uri);

        var content = await responseData.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(content);

    }

    private async Task<ObservableCollection<T>> GetWarframeDateListAsync<T>(Uri uri)
    {

        var responseData = await httpClient.GetAsync(uri);

        var content = await responseData.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<ObservableCollection<T>>(content);

    }

}
