using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int swordIndex;
    public GameManager gameManager;

    private Image image;
    private Color normalColor;
    public Color highlightColor = Color.yellow;

    void Start()
    {
        image = GetComponent<Image>();
        normalColor = image.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = highlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = normalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.BuySword(swordIndex);
    }
}
