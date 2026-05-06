using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject coins;
    private GameObject gOPlayer;

    public bool isPaused = false;

    public Player pPlayer;
    public TMP_Text pointsText;

    public List<TMP_Text> damageTexts;
    public List<TMP_Text> costTexts;
    public List<TMP_Text> nameTexts;

    void Awake(){

        // SwordData(Name, Damage, Cost, Color)
        Stats.swordList.Add(new SwordData("Wooden Sword",  CalculateDamage(0), 0, Color.brown)); // 27 dmg
        Stats.swordList.Add(new SwordData("Stone Sword",   CalculateDamage(200), 5, Color.gray)); // 40 dmg
        Stats.swordList.Add(new SwordData("Iron Sword",    CalculateDamage(400), 15, Color.white)); // 58 dmg
        Stats.swordList.Add(new SwordData("Gold Sword",    CalculateDamage(1200), 25, Color.yellow)); // 65 dmg (THE TRAP)
        Stats.swordList.Add(new SwordData("Diamond Sword", CalculateDamage(2500), 35, Color.cyan)); // 98 dmg
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        shopMenu.SetActive(false);
        gOPlayer = GameObject.Find("Player");
        gOPlayer.GetComponent<Player>().SetSword(Stats.swordList[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            TogglePause();
            ToggleShop();
        }
        pointsText.text = "Points: " + Stats.points;
        UpdateShopUI();
    }

    void ToggleShop(){
        shopMenu.SetActive(!shopMenu.activeInHierarchy);
    }

    void TogglePause(){
        // Unpause
        if (Time.timeScale == 0){
            isPaused = false;
            Time.timeScale = 1;
        }
        // Pause
        else {
            isPaused = true;
            Time.timeScale = 0;
        }
    }

    // Calculates damage based on cost. 
    public int CalculateDamage(int cost){
        // Uses a double sigmoid curve.
        float baseDmg = 25f;
        float w1 = 35f / (1.0f + Mathf.Exp(-0.01f * (cost - 250f)));  // First hump
        float w2 = 40f / (1.0f + Mathf.Exp(-0.005f * (cost - 1600f))); // Second hump
        
        return Mathf.RoundToInt(baseDmg + w1 + w2);
    }

    public void BuySword(int swordIndex)
    {
        SwordData swordToBuy = Stats.swordList[swordIndex];

        if (Stats.points >= swordToBuy.cost)
        {
            Stats.points -= swordToBuy.cost;
            gOPlayer.GetComponent<Player>().SetSword(swordToBuy);

            Debug.Log("Bought " + swordToBuy.name);
        }
        else
        {
            Debug.Log("Not enough points!");
        }
    }
    void UpdateShopUI()
    {
        for (int i = 1; i < Stats.swordList.Count; i++)
        {
            SwordData sword = Stats.swordList[i];

            nameTexts[i - 1].text = sword.name;
            damageTexts[i - 1].text = "Damage: " + sword.damage;
            costTexts[i - 1].text = "Cost: " + sword.cost;
        }
    }
}
