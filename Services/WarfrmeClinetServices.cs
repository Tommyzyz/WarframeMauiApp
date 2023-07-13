

namespace WarframeMauiApp.Services;


public class WarfrmeClinetServices

{
    /*public WarfrmeClinetServices(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }*/
    public readonly HttpClient httpClient = new();

    public earthCycle earthCyclestate;
    public cetusCycle cetusCyclestate;
    public cambionCycle cambionCyclestate;
    public vallisCycle vallisCyclestate;
    public zarimanCycle zarimanCyclestate;
    public archonHunt archonHuntdata;

    public async Task UpdateArchonHuntdata()
    {
        archonHuntdata = await GetWorframeDateAsync<archonHunt>(WarframeAPIUri.archonHuntUri);
    }

    public async Task UpdateZarimanState()
    {
        zarimanCyclestate = await GetWorframeDateAsync<zarimanCycle>(WarframeAPIUri.zarimanCycleUri);
    }

    public async Task UpdateVallisState()
    {
        vallisCyclestate = await GetWorframeDateAsync<vallisCycle>(WarframeAPIUri.vallisCycleUri);
    }

    public async Task UpdateEarthState()
    {
        earthCyclestate = await GetWorframeDateAsync<earthCycle>(WarframeAPIUri.earthUri);
    }

    public async Task UpdateCetusState()
    {
        cetusCyclestate = await GetWorframeDateAsync<cetusCycle>(WarframeAPIUri.cetusUri);
    }

    public async Task UpdateCambionState()
    {
        cambionCyclestate = await GetWorframeDateAsync<cambionCycle>(WarframeAPIUri.cambionUri);
    }


    private async Task<T> GetWorframeDateAsync<T>(Uri uri)
    {

        var responseData = await httpClient.GetAsync(uri);

        responseData.EnsureSuccessStatusCode();

        var content = await responseData.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(content);

    }

}
