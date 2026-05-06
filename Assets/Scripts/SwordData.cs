using UnityEngine;

public class SwordData
{
    public string name;
    public int damage;
    public int cost;
    public Color color;

    public SwordData(string name, int dmg, int price, Color color){
        this.name = name;
        this.damage = dmg;
        this.cost = price;
        this.color = color;
    }
}