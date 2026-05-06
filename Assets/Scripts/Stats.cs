using UnityEngine;
using System.Collections.Generic;

class Stats {
    public int coins {get; set;} = 0;

    public static List<SwordData> swordList{get; set;} = new List<SwordData>{
        new SwordData("Wooden Sword", 25, 0, Color.brown),
        new SwordData("Stone Sword", 50, 4, Color.grey),
        new SwordData("Iron Sword", 50, 4, Color.white),
        new SwordData("Diamond Sword", 50, 4, Color.turquoise)
    }; 
}