using UnityEngine;
using UnityEngine.UI;

public class TurboIcon : MonoBehaviour
{
    public Megaphone megaphone;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        image.color = megaphone.IsComboCooldown() ? new Color(1, 1, 1, 0.5f) : Color.white;
    }
}