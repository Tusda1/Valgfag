using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ScrobDatabase
{
    public static List<Sword> swords = new List<Sword>();
    
    public static void Initialize()
    {
        swords = Resources.LoadAll<Sword>("Swords").ToList();
    }
}
