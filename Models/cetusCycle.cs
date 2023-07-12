using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarframeMauiApp.Models;

//cetusCycle: 地球平原

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class cetusCycle
{
    public string id
    {
        get; set;
    }
    public DateTime expiry
    {
        get; set;
    }
    public DateTime activation
    {
        get; set;
    }
    public bool isDay
    {
        get; set;
    }
    public string state
    {
        get; set;
    }
    public string timeLeft
    {
        get; set;
    }
    public bool isCetus
    {
        get; set;
    }
    public string shortString
    {
        get; set;
    }
}
