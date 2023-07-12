using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarframeMauiApp.Models;


public class zarimanCycle
{
    public string id
    {
        get; set;
    }
    public DateTime bountiesEndDate
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
    public bool isCorpus
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
    public string shortString
    {
        get; set;
    }
}