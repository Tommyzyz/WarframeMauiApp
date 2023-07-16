using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarframeMauiApp.Models;

public class sortie
{
    public string id
    {
        get; set;
    }
    public DateTime activation
    {
        get; set;
    }
    public string startString
    {
        get; set;
    }
    public DateTime expiry
    {
        get; set;
    }
    public bool active
    {
        get; set;
    }
    public string rewardPool
    {
        get; set;
    }
    public List<Variant> variants
    {
        get; set;
    }
    public List<object> missions
    {
        get; set;
    }
    public string boss
    {
        get; set;
    }
    public string faction
    {
        get; set;
    }
    public bool expired
    {
        get; set;
    }
    public string eta
    {
        get; set;
    }
}

public class Variant
{
    public string missionType
    {
        get; set;
    }
    public string modifier
    {
        get; set;
    }
    public string modifierDescription
    {
        get; set;
    }
    public string node
    {
        get; set;
    }
}
