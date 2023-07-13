

namespace WarframeMauiApp.Models;

// cambionCycle: 火卫二平原

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class cambionCycle
{
    public string id
    {
        get; set;
    }
    public DateTime activation
    {
        get; set;
    }
    public DateTime expiry
    {
        get; set;
    }
    public string timeLeft
    {
        get; set;
    }
    public string state
    {
        get; set;
    }
    public string active
    {
        get; set;
    }
}
