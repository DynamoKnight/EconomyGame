using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject coins;

    public bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        shopMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            TogglePause();
            ToggleShop();
        }
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
}
