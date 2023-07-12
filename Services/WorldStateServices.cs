using WarframeMauiApp.Models;

namespace WarframeMauiApp.Services;


public class WorldStateServices
{

    public readonly HttpClient httpClient;

    public earthCycle earthCyclestate;
    public cetusCycle cetusCyclestate;
    public cambionCycle cambionCyclestate;



    public WorldStateServices(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }


    public async Task UpdateEarthState()
    {
        earthCyclestate = await GetWorldDateAsync<earthCycle>(WarframeAPIUri.earthUri);
    }

    public async Task UpdateCetusState()
    {
        cetusCyclestate = await GetWorldDateAsync<cetusCycle>(WarframeAPIUri.cetusUri);
    }

    public async Task UpdatecambionState()
    {
        cambionCyclestate = await GetWorldDateAsync<cambionCycle>(WarframeAPIUri.cambionUri);
    }


    private async Task<T> GetWorldDateAsync<T>(Uri uri)
    {

        var responseData = await httpClient.GetAsync(uri);

        responseData.EnsureSuccessStatusCode();

        var content = await responseData.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(content);

    }

}
