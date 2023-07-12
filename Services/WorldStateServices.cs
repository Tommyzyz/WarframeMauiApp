using WarframeMauiApp.Models;

namespace WarframeMauiApp.Services;


public class WorldStateServices
{

    public readonly HttpClient httpClient;

    public earthCycle earthCyclestate;
    public cetusCycle cetusCyclestate;



    public WorldStateServices(HttpClient httpClient)
    {
        this.httpClient = httpClient;
        UpdateAllState();


    }


    private async Task UpdateAllState()
    {
        await UpdateEarthState();
        await UpdateCetusState();
    }

    public async Task UpdateEarthState()
    {
        earthCyclestate = await GetWorldDateAsync<earthCycle>(WarframeAPIUri.earthUri);
    }

    public async Task UpdateCetusState()
    {
        cetusCyclestate = await GetWorldDateAsync<cetusCycle>(WarframeAPIUri.cetusUri);
    }


    private async Task<T> GetWorldDateAsync<T>(Uri uri)
    {

        var responseData = await httpClient.GetAsync(uri);

        responseData.EnsureSuccessStatusCode();

        var content = await responseData.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(content);

    }

}
