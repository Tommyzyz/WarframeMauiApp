using WarframeMauiApp.Models;

namespace WarframeMauiApp.Services;


public class WorldStateServices
{

    public readonly HttpClient httpClient;

    public earthCycle earthCyclestate;
    public cetusCycle cetusCyclestate;
    private Uri earthUri = new("https://api.warframestat.us/pc/earthCycle/");
    private Uri cetusUri = new("https://api.warframestat.us/pc/cetusCycle/");

    public WorldStateServices(HttpClient httpClient)
    {
        this.httpClient = httpClient;

    }
    public async Task UpdateEarthState()
    {
        earthCyclestate = await GetWorldDateAsync<earthCycle>(earthUri);
    }

    public async Task UpdateCetusState()
    {
        cetusCyclestate = await GetWorldDateAsync<cetusCycle>(cetusUri);
    }


    public async Task<T> GetWorldDateAsync<T>(Uri uri)
    {

        var responseData = await httpClient.GetAsync(uri);

        responseData.EnsureSuccessStatusCode();

        var content = await responseData.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(content);

    }

}
