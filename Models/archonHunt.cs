using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarframeMauiApp.Models;
public class Mission
{
    public string node
    {
        get; set;
    }
    public string nodeKey
    {
        get; set;
    }
    public string type
    {
        get; set;
    }
    public string typeKey
    {
        get; set;
    }
    public bool nightmare
    {
        get; set;
    }
    public bool archwingRequired
    {
        get; set;
    }
    public bool isSharkwing
    {
        get; set;
    }
    public List<object> advancedSpawners
    {
        get; set;
    }
    public List<object> requiredItems
    {
        get; set;
    }
    public List<object> levelAuras
    {
        get; set;
    }
}

public class archonHunt
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
    public List<object> variants
    {
        get; set;
    }
    public List<Mission> missions
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